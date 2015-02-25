using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UPE_ONS.Controllers;
using UPE_ONS.Model;
using UPE_ONS.Util;

namespace UPE_ONS.Views
{
    /// <summary>
    /// Interaction logic for VisualizarDados.xaml
    /// </summary>
    public partial class VisualizarDados : UserControl
    {
        public int Limit { get; set; }

        public VisualizarDados()
        {
            InitializeComponent();

            try
            {
                this.DataContext = this;

                this.Limit = 100;

                this.cmbBoxParquesEolicos.ItemsSource = FactoryController.getInstance().ParqueEolicoController.getAll();
            }
            catch (Exception e)
            {
                this.txtMessage.Text = Constants.ERROR_OPEN_CONNECTION;
            }
        }

        private void cmbBoxParquesEolicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.radioCPTEC.IsChecked == true)
                this.UpdateDatagridItemsSourceCPTEC();
            else if (this.radioPrevEOL.IsChecked == true)
                this.UpdateDatagridItemsSourcePrevEOL();
        }

        private void UpdateDatagridItemsSourceCPTEC()
        {
            if (this.cmbBoxParquesEolicos.SelectedItem != null)
            {
                ParqueEolico parqueEolico = (ParqueEolico)this.cmbBoxParquesEolicos.SelectedItem;

                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        List<ParqueEolicoImportacaoCPTEC> dados = FactoryController.getInstance().
                            CPTEC_Controller.getDadosImportados(parqueEolico.Id, this.Limit);

                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            if (dados.Count > 0)
                                this.TreeViewDadosCPTEC.Items.Clear();

                            for (int i = 0; i < dados.Count; i++)
                            {
                                TreeViewItem item = new TreeViewItem();
                                item.Header = "Dia Previsto: " + (dados[i].diaPrevisto + 1).ToString().PadLeft(2,'0') +
                                    " | " + dados[i].dia.PadLeft(2, '0') + "/" + dados[i].mes.PadLeft(2, '0') + "/" + dados[i].ano;
                                item.Margin = new Thickness(5);

                                List<string> listVelocidadeDirecao = new List<string>();
                                List<string> listaVelocidades = dados[i].velocidades;
                                List<string> listaDirecoes = dados[i].direcoes;                                
                                for (int k = 0; k < listaVelocidades.Count; k++)
                                {
                                    listVelocidadeDirecao.Add("Hora: " + k.ToString().PadLeft(2,'0') + ": "+
                                        "| Velocidade: " + dados[k].velocidades[k].PadLeft(5, '0') + " " +
                                        "| Direção: " + dados[k].direcoes[k]);
                                }

                                item.ItemsSource = listVelocidadeDirecao;

                                this.TreeViewDadosCPTEC.Items.Add(item);
                            }
                            this.ShowTreeView();
                        }));

                    }
                    catch (Exception e)
                    {
                        this.Dispatcher.BeginInvoke(new Action(() => { this.txtMessage.Text = e.Message; }));
                    }
                };
                worker.RunWorkerCompleted += (param, args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString());
                    this.BusyIndicatorCarregando.IsBusy = false;
                };

                BusyIndicatorCarregando.IsBusy = true;
                worker.RunWorkerAsync();
            }
        }

        private void UpdateDatagridRowsAndColumns(bool verTodosOsAtributos)
        {
            if (this.cmbBoxParquesEolicos.SelectedItem != null)
            {
                ParqueEolico parqueEolico = (ParqueEolico)this.cmbBoxParquesEolicos.SelectedItem;
                String intervalo = ((ComboBoxItem)this.cmbBoxIntervalo.SelectedItem).Tag.ToString();

                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += (o, ea) =>
                {
                    try
                    {                        
                        List<ParqueEolicoImportacaoPrevEOL> listaDadosImportados = FactoryController.getInstance().
                            PrevEOL_Controller.getDadosImportados(parqueEolico.Id, this.Limit, verTodosOsAtributos,
                            intervalo);

                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            if (listaDadosImportados.Count > 0)
                            {
                                this.ShowDataGrid();
                                this.dataGridVisualizarDados.ItemsSource = listaDadosImportados;
                            }
                            else
                                this.ShowMessageEmptyData();
                        }));
                    }
                    catch (Exception e)
                    {
                        this.Dispatcher.BeginInvoke(new Action(() => { this.txtMessage.Text = e.Message; }));
                    }
                };
                worker.RunWorkerCompleted += (param, args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString());
                    this.BusyIndicatorCarregando.IsBusy = false;
                };

                BusyIndicatorCarregando.IsBusy = true;
                worker.RunWorkerAsync();
            }
        }

        private void ShowDataGrid()
        {
            this.dataGridVisualizarDados.Visibility = Visibility.Visible;
            this.chkBoxAllFields.Visibility = Visibility.Visible;
            this.txtMessage.Visibility = Visibility.Hidden;
            this.TreeViewDadosCPTEC.Visibility = Visibility.Hidden;
            this.gridFiltrar.Visibility = Visibility.Visible;
        }

        private void ShowTreeView()
        {
            this.dataGridVisualizarDados.Visibility = Visibility.Hidden;
            this.chkBoxAllFields.Visibility = Visibility.Hidden;
            this.txtMessage.Visibility = Visibility.Hidden;
            this.TreeViewDadosCPTEC.Visibility = Visibility.Visible;
            this.gridFiltrar.Visibility = Visibility.Visible;
        }

        private void ShowMessageEmptyData()
        {
            this.dataGridVisualizarDados.Visibility = Visibility.Hidden;
            this.chkBoxAllFields.Visibility = Visibility.Hidden;
            this.txtMessage.Visibility = Visibility.Visible;
            this.TreeViewDadosCPTEC.Visibility = Visibility.Hidden;
            this.txtMessage.Text = "Não existe nenhum dado importado para este parque.";
            this.gridFiltrar.Visibility = Visibility.Hidden;
        }

        private int _noOfErrorsOnScreen = 0;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private void Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(this.radioPrevEOL.IsChecked == true)
                this.UpdateDatagridItemsSourcePrevEOL();
            else if (this.radioCPTEC.IsChecked == true)
                this.UpdateDatagridItemsSourceCPTEC();
            e.Handled = true;
        }

        private void chkBoxAllFields_Checked(object sender, RoutedEventArgs e)
        {

            this.UpdateDatagridItemsSourcePrevEOL();
        }

        private void UpdateDatagridItemsSourcePrevEOL()
        {
            if (this.chkBoxAllFields.IsChecked != null)
                this.UpdateDatagridRowsAndColumns((bool)this.chkBoxAllFields.IsChecked);
            else
                this.UpdateDatagridRowsAndColumns(false);
        }

        private void radioPrevEOL_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateDatagridItemsSourcePrevEOL();
        }

        private void radioCPTEC_Checked(object sender, RoutedEventArgs e)
        {
            this.UpdateDatagridItemsSourceCPTEC();
        }

        private void cmbBoxIntervalo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.radioCPTEC != null && this.radioCPTEC.IsChecked == true)
                this.UpdateDatagridItemsSourceCPTEC();
            else if (this.radioPrevEOL != null && this.radioPrevEOL.IsChecked == true)
                this.UpdateDatagridItemsSourcePrevEOL();
        }
    }
}