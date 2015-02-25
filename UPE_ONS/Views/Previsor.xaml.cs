using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using UPE_ONS.Controllers;
using UPE_ONS.Model;
using UPE_ONS.Util;

namespace UPE_ONS.Views
{
    /// <summary>
    /// Interaction logic for CalibrarRedeNeural.xaml
    /// </summary>
    public partial class Previsor : System.Windows.Controls.UserControl
    {
        private ObservableCollection<ParqueEolico> ListaParquesEolicos;
        private ObservableCollection<ParqueEolico> ListaParquesEolicosSelecionados;

        public Previsor()
        {
            InitializeComponent();

            //this.btn1.IsEnabled = true;

            this.cmbBoxTipo.SelectionChanged += cmbBoxTipo_SelectionChanged;
            try
            {
                var worker = new BackgroundWorker();

                worker.DoWork += (sender, args) =>
                {
                    try
                    {
                        this.Dispatcher.Invoke(new Action(() =>
                        {

                            this.carregarParquesEolicos();
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
                        System.Windows.Forms.MessageBox.Show(args.Error.ToString());
                    this.BusyIndicatorCarregando.IsBusy = false;
                };

                worker.RunWorkerAsync();
            }
            catch (Exception e)
            {
                this.ShowInfoMessage(e.Message);
            }
        }

        void cmbBoxTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.carregarParquesEolicos();
        }

        private void carregarParquesEolicos()
        {
            if (((ComboBoxItem)cmbBoxTipo.SelectedItem).Tag.Equals("PP"))
                this.ListaParquesEolicos = new ObservableCollection<ParqueEolico>(FactoryController.getInstance().ParqueEolicoController.getParquesCalibrados("PP"));
            else
                this.ListaParquesEolicos = new ObservableCollection<ParqueEolico>(FactoryController.getInstance().ParqueEolicoController.getParquesCalibrados("TR"));

            this.lstViewParquesEolicos.ItemsSource = this.ListaParquesEolicos;

            this.ListaParquesEolicosSelecionados = new ObservableCollection<ParqueEolico>();
            this.lstViewParquesEolicosSelecionados.ItemsSource = this.ListaParquesEolicosSelecionados;

            Util.Util.parquesPrevistos = this.ListaParquesEolicosSelecionados;
        }

        private void ShowInfoMessage(string message)
        {
            this.txtMessage.Text = message;
            this.gridMessage.Visibility = Visibility.Visible;
            this.gridContent.Visibility = Visibility.Hidden;
        }

        private void RemoverTodosParquesEolicos_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListaParquesEolicosSelecionados.Count > 0)
            {
                foreach (ParqueEolico parque in this.ListaParquesEolicosSelecionados)
                    this.ListaParquesEolicos.Add(parque);

                this.ListaParquesEolicosSelecionados.Clear();
            }
            else
                System.Windows.Forms.MessageBox.Show("Todos os parques já foram removidos.", Constants.WARNNING_CAPTION);
        }

        private void RemoverParqueEolico_Click(object sender, RoutedEventArgs e)
        {
            if (this.lstViewParquesEolicosSelecionados.SelectedItems.Count > 0)
            {
                List<ParqueEolico> listaParquesTemp = new List<ParqueEolico>();
                foreach (var parqueSelecionado in this.lstViewParquesEolicosSelecionados.SelectedItems)
                {
                    listaParquesTemp.Add((ParqueEolico)parqueSelecionado);
                    this.ListaParquesEolicos.Add((ParqueEolico)parqueSelecionado);
                }

                for (int i = 0; i < listaParquesTemp.Count; i++)
                    this.ListaParquesEolicosSelecionados.Remove(listaParquesTemp[i]);
            }
            else
                System.Windows.Forms.MessageBox.Show("Por favor, selecione um ou mais parques eólicos.", Constants.WARNNING_CAPTION);
        }

        private void AdicionarTodosParquesEolicos_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListaParquesEolicos.Count > 0)
            {
                foreach (ParqueEolico parque in this.ListaParquesEolicos)
                    this.ListaParquesEolicosSelecionados.Add(parque);

                this.ListaParquesEolicos.Clear();
            }
            else
                System.Windows.Forms.MessageBox.Show("Todos os parques já foram adicionados.", Constants.WARNNING_CAPTION);
        }

        private void AdicionarParqueEolico_Click(object sender, RoutedEventArgs e)
        {
            if (this.lstViewParquesEolicos.SelectedItems.Count > 0)
            {
                List<ParqueEolico> listaParquesSelecionadosTemp = new List<ParqueEolico>();
                foreach (var parqueSelecionado in this.lstViewParquesEolicos.SelectedItems)
                {
                    listaParquesSelecionadosTemp.Add((ParqueEolico)parqueSelecionado);
                    this.ListaParquesEolicosSelecionados.Add((ParqueEolico)parqueSelecionado);
                }

                for (int i = 0; i < listaParquesSelecionadosTemp.Count; i++)
                    this.ListaParquesEolicos.Remove(listaParquesSelecionadosTemp[i]);
            }
            else
                System.Windows.Forms.MessageBox.Show("Por favor, selecione um ou mais parques eólicos.", Constants.WARNNING_CAPTION);
        }

        private void btnExecutarPrevisor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int qtdParquesSelecionados = this.ListaParquesEolicosSelecionados.Count;
                if (qtdParquesSelecionados > 0)
                {
                    string tipoSelecionado = ((ComboBoxItem)this.cmbBoxTipo.SelectedItem).Tag.ToString();
                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += (o, ea) =>
                                {
                                    try
                                    {
                                        int progressoPorAquivo = 100 / qtdParquesSelecionados;
                                        for (int i = 0; i < this.ListaParquesEolicosSelecionados.Count; i++)
                                        {
                                            this.Dispatcher.Invoke(new Action(() =>
                                            {
                                                this.txtProgressValue.Text = "Executando a previsão para o parque: " +
                                                    this.ListaParquesEolicosSelecionados[i].Nome + " (" + (i + 1) + "/" + qtdParquesSelecionados + ").";
                                            }));

                                            FactoryController.getInstance().PrevisorController.realizarPrevisao
                                                (this.ListaParquesEolicosSelecionados[i], tipoSelecionado);

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
                            System.Windows.Forms.MessageBox.Show(args.Error.ToString());
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
                    System.Windows.Forms.MessageBox.Show("Por favor, selecione um ou mais parques eólicos.", Constants.WARNNING_CAPTION);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnExibirGraficos_Click(object sender, RoutedEventArgs e)
        {
            Util.Util.activateGraphWindow();
           
            GraphForm graphs = new GraphForm();
            graphs.ShowDialog();
            //graphs.FormClosed += refreshList();
        }



        //private FormClosedEventHandler refreshList()
        //{

        //    PrevEolFileUtil reader = new PrevEolFileUtil();
        //    ArrayList tags = reader.readUsinasFile();
        //    tagsListBox.Sorted = true;
        //    tagsListBox.DataSource = tags;

        //    return null;
        //}
    }
}