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
    /// Interaction logic for Calibragem.xaml
    /// </summary>
    public partial class Calibrar : UserControl
    {
        private ObservableCollection<ParqueEolico> ListaParquesEolicos;
        private ObservableCollection<ParqueEolico> ListaParquesEolicosSelecionados;

        public Calibrar()
        {
            InitializeComponent();
            this.cmbBoxIntervalo.SelectionChanged += cmbBoxIntervalo_SelectionChanged;
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

        private void carregarParquesEolicos()
        {
            if (((ComboBoxItem)cmbBoxIntervalo.SelectedItem).Tag.Equals(Util.Util.DEZ_MINUTOS))
            {
                this.ListaParquesEolicos = new ObservableCollection<ParqueEolico>(FactoryController.getInstance().ParqueEolicoController.getAll_LEFT("TR"));
            }
            else
            {
                if (((ComboBoxItem)cmbBoxTipo.SelectedItem).Tag.Equals("PP"))
                {
                    this.ListaParquesEolicos = new ObservableCollection<ParqueEolico>(FactoryController.getInstance().ParqueEolicoController.getAll_LEFT("PP"));
                }
                else
                {
                    this.ListaParquesEolicos = new ObservableCollection<ParqueEolico>(FactoryController.getInstance().ParqueEolicoController.getAll_LEFT("VP"));
                }
            }
            this.lstViewParquesEolicos.ItemsSource = this.ListaParquesEolicos;

            this.ListaParquesEolicosSelecionados = new ObservableCollection<ParqueEolico>();
            this.lstViewParquesEolicosSelecionados.ItemsSource = this.ListaParquesEolicosSelecionados;
        }

        private void ShowInfoMessage(string message)
        {
            this.txtMessage.Text = message;
            this.gridMessage.Visibility = Visibility.Visible;
            this.gridContent.Visibility = Visibility.Hidden;
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
                MessageBox.Show("Por favor, selecione um ou mais parques eólicos.", Constants.WARNNING_CAPTION);
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
                MessageBox.Show("Por favor, selecione um ou mais parques eólicos.", Constants.WARNNING_CAPTION);
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
                MessageBox.Show("Todos os parques já foram removidos.", Constants.WARNNING_CAPTION);
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
                MessageBox.Show("Todos os parques já foram adicionados.", Constants.WARNNING_CAPTION);
        }

        private void cmbBoxIntervalo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBoxItem)cmbBoxIntervalo.SelectedItem).Tag.Equals("10min"))
                this.cmbBoxTipo.Visibility = Visibility.Hidden;
            else
                this.cmbBoxTipo.Visibility = Visibility.Visible;
            this.carregarParquesEolicos();
        }

        private void cmbBoxTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBoxItem)cmbBoxTipo.SelectedItem).Tag.Equals("PP"))
                this.cmbBoxIntervalo.Visibility = Visibility.Visible;
            else
                this.cmbBoxIntervalo.Visibility = Visibility.Hidden;

            this.carregarParquesEolicos();
        }

        #region Métodos de treinamento

        private void GerarArquivosTreinamento_Click(object sender, RoutedEventArgs e)
        {
            if (((ComboBoxItem)cmbBoxTipo.SelectedItem).Tag.Equals("PP"))
                this.GerarArquivosTreinamentoPotenciaPotencia();
            else
                this.GerarArquivosTreinamentoVentoPotencia();
        }

        private void GerarArquivosTreinamentoVentoPotencia()
        {
            try
            {
                this.feedbackMessage.Visibility = Visibility.Hidden;

                string strDataInicial = this.datePickerDataInicial.Text;
                string strDataFinal = this.datePickerDataFinal.Text;

                if (strDataInicial.Equals("") || strDataFinal.Equals(""))
                    MessageBox.Show("Preencha o período desejado para fazer a calibragem.", Constants.WARNNING_CAPTION);
                else
                {
                    int qtdParquesSelecionados = this.ListaParquesEolicosSelecionados.Count;
                    if (qtdParquesSelecionados > 0)
                    {
                        DateTime dataInicial = DateTime.Parse(strDataInicial);
                        DateTime dataFinal = DateTime.Parse(strDataFinal);

                        if (dataFinal < dataInicial)
                            MessageBox.Show("Desculpe, mas a data inicial tem que ser menor que a data final.", Constants.WARNNING_CAPTION);
                        else
                        {
                            BackgroundWorker worker = new BackgroundWorker();

                            String intervalo = ((ComboBoxItem)this.cmbBoxIntervalo.SelectedItem).Tag.ToString();
                            this.processBar.Value = 0;
                            worker.DoWork += (o, ea) =>
                            {
                                try
                                {
                                    int progressoPorAquivo = 100 / qtdParquesSelecionados;
                                    for (int i = 0; i < qtdParquesSelecionados; i++)
                                    {
                                        this.Dispatcher.Invoke(new Action(() =>
                                        {
                                            this.txtProgressValue.Text = "Calibrando " +
                                                this.ListaParquesEolicosSelecionados[i].Nome + " (" + (i + 1) + "/" + qtdParquesSelecionados + ").";
                                        }));
                                        FactoryController.getInstance().CalibradorController.gerarArquivoTreinamentoVentoPotencia(this.ListaParquesEolicosSelecionados[i],
                                            dataInicial, dataFinal, intervalo);

                                        FactoryController.getInstance().CalibradorController.calibrarVentoPotencia(this.ListaParquesEolicosSelecionados[i]);
                                        this.ListaParquesEolicosSelecionados[i].Calibracao.FoiCalibrado = 1;
                                        this.ListaParquesEolicosSelecionados[i].Calibracao.Data = DateTime.Now;

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
                    }
                    else
                        MessageBox.Show("Por favor, selecione um ou mais parques eólicos.", Constants.WARNNING_CAPTION);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GerarArquivosTreinamentoPotenciaPotencia()
        {
            try
            {
                this.feedbackMessage.Visibility = Visibility.Hidden;

                string strDataInicial = this.datePickerDataInicial.Text;
                string strDataFinal = this.datePickerDataFinal.Text;

                if (strDataInicial.Equals("") || strDataFinal.Equals(""))
                    MessageBox.Show("Preencha o período desejado para fazer a calibragem.", Constants.WARNNING_CAPTION);
                else
                {
                    int qtdParquesSelecionados = this.ListaParquesEolicosSelecionados.Count;
                    if (qtdParquesSelecionados > 0)
                    {
                        DateTime dataInicial = DateTime.Parse(strDataInicial);
                        DateTime dataFinal = DateTime.Parse(strDataFinal);

                        if (dataFinal < dataInicial)
                            MessageBox.Show("Desculpe, mas a data inicial tem que ser menor que a data final.", Constants.WARNNING_CAPTION);
                        else
                        {
                            BackgroundWorker worker = new BackgroundWorker();

                            String intervalo = ((ComboBoxItem)this.cmbBoxIntervalo.SelectedItem).Tag.ToString();
                            this.processBar.Value = 0;
                            worker.DoWork += (o, ea) =>
                            {
                                try
                                {
                                    // Esse número de entradas foi feito pra ser variável, mas terminou 
                                    // ficando constante pra essa etapa do projeto;
                                    int numeroDeEntradas = -1;
                                    if (intervalo.Equals(Util.Util.DEZ_MINUTOS))
                                        numeroDeEntradas = 18;
                                    else if (intervalo.Equals(Util.Util.TRINTA_MINUTOS))
                                        numeroDeEntradas = 6;
                                    else
                                        throw new Exception("Erro! Número de entradas menor que zero!");

                                    int progressoPorAquivo = 100 / qtdParquesSelecionados;
                                    for (int i = 0; i < qtdParquesSelecionados; i++)
                                    {
                                        this.Dispatcher.Invoke(new Action(() =>
                                        {
                                            this.txtProgressValue.Text = "Calibrando " +
                                                this.ListaParquesEolicosSelecionados[i].Nome + " (" + (i + 1) + "/" + qtdParquesSelecionados + ").";
                                        }));

                                        bool isTempoReal = false;
                                        this.Dispatcher.Invoke(new Action(() =>
                                        {
                                            if (((ComboBoxItem)this.cmbBoxIntervalo.SelectedItem).Tag.Equals(Util.Util.DEZ_MINUTOS))
                                                isTempoReal = true;
                                        }));

                                        FactoryController.getInstance().CalibradorController.
                                            gerarArquivosTreinamentoPotenciaPotencia(this.ListaParquesEolicosSelecionados[i],
                                                numeroDeEntradas, dataInicial, dataFinal, intervalo, isTempoReal);

                                        FactoryController.getInstance().CalibradorController.CalibrarPotenciaPotencia(this.ListaParquesEolicosSelecionados[i], isTempoReal);
                                        this.ListaParquesEolicosSelecionados[i].Calibracao.FoiCalibrado = 1;
                                        this.ListaParquesEolicosSelecionados[i].Calibracao.Data = DateTime.Now;

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
                    }
                    else
                        MessageBox.Show("Por favor, selecione um ou mais parques eólicos.", Constants.WARNNING_CAPTION);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}