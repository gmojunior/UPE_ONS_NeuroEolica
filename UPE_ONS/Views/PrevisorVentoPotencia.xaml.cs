using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using UPE_ONS.Controllers;
using UPE_ONS.Model;
using UPE_ONS.Util;

namespace UPE_ONS.Views
{
    /// <summary>
    /// Interaction logic for CalibrarRedeNeural.xaml
    /// </summary>
    public partial class PrevisorVentoPotencia : UserControl
    {
        private List<EntradaVentoPotencia> parquesSelecionados;

        public PrevisorVentoPotencia()
        {
            InitializeComponent();
            try
            {
                var worker = new BackgroundWorker();

                worker.DoWork += (sender, args) =>
                {
                    try
                    {
                        this.Dispatcher.Invoke(new Action(() =>
                        {
                            this.LoadTreeView();
                            this.parquesSelecionados = new List<EntradaVentoPotencia>();
                        }));
                    }
                    catch (Exception e)
                    {
                        this.Dispatcher.Invoke(new Action(() => { this.ShowInfoMessage(e.Message); }));
                    }
                };

                worker.RunWorkerCompleted += (sender, args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString());
                    this.BusyIndicatorCarregando.IsBusy = false;
                };

                worker.RunWorkerAsync();
            }
            catch (Exception e)
            {
                this.ShowInfoMessage(e.Message);
            }
        }

        private void ShowInfoMessage(string message)
        {
            this.txtMessage.Text = message;
            this.gridMessage.Visibility = Visibility.Visible;
            this.gridContent.Visibility = Visibility.Hidden;
        }

        private void LoadTreeView()
        {
            List<EntradaVentoPotencia> dados = FactoryController.getInstance().PrevisorController.GetInputPrevisaoVentoPotencia();

            for (int i = 0; i < dados.Count; i++)
            {
                TreeViewItem item = new TreeViewItem();
                item.Tag = dados[i];

                CheckBox chkBox = new CheckBox();
                chkBox.Checked += chkBox_Checked;
                chkBox.Unchecked += chkBox_Unchecked;
                chkBox.Content = dados[i].ParqueEolico.Nome;
                item.Header = chkBox;
                item.Margin = new Thickness(5);
                item.ItemsSource = new string[] 
                    { 
                        dados[i].Dia + "/" + dados[i].Mes + "/" + dados[i].Ano
                    };

                this.TreeViewParquesEolicos.Items.Add(item);
            }
        }

        void chkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.parquesSelecionados.Remove(((EntradaVentoPotencia)((TreeViewItem)((CheckBox)sender).Parent).Tag));
        }

        void chkBox_Checked(object sender, RoutedEventArgs e)
        {
            this.parquesSelecionados.Add(((EntradaVentoPotencia)((TreeViewItem)((CheckBox)sender).Parent).Tag));
        }

        private void PreverVentoPotencia_Click(object sender, RoutedEventArgs e)
        {
            int qtdParquesSelecionados = this.parquesSelecionados.Count;
            if (qtdParquesSelecionados  > 0)
            {
                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        int progressoPorAquivo = 100 / qtdParquesSelecionados;
                        for (int i = 0; i < qtdParquesSelecionados; i++)
                        {
                            this.Dispatcher.Invoke(new Action(() =>
                            {
                                this.txtProgressValue.Text = "Executando a previsão para o parque: " +
                                    this.parquesSelecionados[i].ParqueEolico.Nome + " (" + (i + 1) + "/" + qtdParquesSelecionados + ").";
                            }));

                            FactoryController.getInstance().PrevisorController.PreverVentoPotencia(this.parquesSelecionados[i]);

                            this.Dispatcher.Invoke(new Action(() =>
                            {
                                this.processBar.Value += progressoPorAquivo;
                            }));
                        }

                        this.Dispatcher.Invoke(new Action(() => { this.feedbackMessage.Visibility = Visibility.Visible; }));
                    }
                    catch (Exception ex)
                    {
                        this.Dispatcher.Invoke(new Action(() => { this.ShowInfoMessage(ex.Message); }));
                    }
                };

                worker.RunWorkerCompleted += (param, args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString());
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        this.gridPaternProgressBar.Visibility = Visibility.Collapsed;
                        this.GridProgressBar.Visibility = Visibility.Collapsed;
                    }));
                };

                this.Dispatcher.Invoke(new Action(() =>
                {
                    this.gridPaternProgressBar.Visibility = Visibility.Visible;
                    this.GridProgressBar.Visibility = Visibility.Visible;
                }));

                worker.RunWorkerAsync();
            }
            else
                MessageBox.Show("Por favor, selecione um ou mais parques eólicos.", Constants.WARNNING_CAPTION);
        }

        private void chkSelecionarTodos_Click(object sender, RoutedEventArgs e)
        {
            ItemCollection items = this.TreeViewParquesEolicos.Items;
            if (((CheckBox)sender).IsChecked == true)
            {
                foreach (TreeViewItem item in items)
                {
                    ((CheckBox)item.Header).IsChecked = true;
                }
            }
            else if (((CheckBox)sender).IsChecked == false)
            {
                foreach (TreeViewItem item in items)
                {
                    ((CheckBox)item.Header).IsChecked = false;
                }
            }
        }
    }
}