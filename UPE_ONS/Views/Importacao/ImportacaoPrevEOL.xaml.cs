using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using UPE_ONS.Controllers;
using UPE_ONS.DAO;
using UPE_ONS.Model;


namespace UPE_ONS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ImportacaoPrevEOL : UserControl
    {
        private string CAMINHO_FILES = Environment.CurrentDirectory + @"\Arquivos\";
        private const string CAMINHO_ENTRADA_IMPORTACAO = "PrevEOL";
        private const string CAMINHO_SAIDA_IMPORTACAO   = "Importados";
        private FileInfo[] files;

        private List<ParqueEolico> listaParquesEolicos;

        #region Construtor

        public ImportacaoPrevEOL()
        {
            try
            {
                InitializeComponent();

                this.listaParquesEolicos = FactoryController.getInstance().ParqueEolicoController.getAll();
                this.LoadFiles();
            }
            catch (Exception e)
            {
                this.ShowInfoMessage(e.Message);
            }
        }

        #endregion

        #region Eventos

        private void importPrevEOLFile_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.feedbackMessage.Visibility = Visibility.Hidden;

                if (files.Length > 0)
                {
                    int qtdArquivos = files.Length;
                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += (o, ea) =>
                    {
                        try
                        {
                            int progressoPorAquivo = 100 / files.Length;
                            int count = 0;

                            foreach (FileInfo file in this.files)
                            {
                                count++;

                                this.Dispatcher.Invoke(new Action(() => { this.txtProgressValue.Text = "Importando arquivo " + count + "/" + qtdArquivos + "."; }));

                                for (int i = 0; i < this.listaParquesEolicos.Count; i++)
                                {
                                    string sigla = this.listaParquesEolicos[i].SiglaPrevEOL;
                                    if (file.Name.IndexOf(sigla, StringComparison.OrdinalIgnoreCase) != -1)
                                    {
                                        // Arquivos de 30 minutos
                                        if (file.Name.IndexOf(Util.Util.TRINTA_MINUTOS, StringComparison.OrdinalIgnoreCase) != -1)
                                            FactoryDAO.getInstance().PrevEOLDAO.importarArquivoPrevEOL(file.FullName, this.listaParquesEolicos[i].Id, Util.Util.TRINTA_MINUTOS);
                                        // Arquivos de 10 minutos
                                        else if (file.Name.IndexOf(Util.Util.DEZ_MINUTOS, StringComparison.OrdinalIgnoreCase) != -1)
                                            FactoryDAO.getInstance().PrevEOLDAO.importarArquivoPrevEOL(file.FullName, this.listaParquesEolicos[i].Id, Util.Util.DEZ_MINUTOS);
                                        else
                                            break;
                                        file.CopyTo(CAMINHO_FILES + CAMINHO_SAIDA_IMPORTACAO + "\\" + file.Name, true);
                                        File.Delete(file.FullName);
                                        break;
                                    }
                                }

                                this.Dispatcher.Invoke(new Action(() =>
                                {
                                    //this.processBar.Value += progressoPorAquivo;
                                    this.LoadFiles();
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
                            HideProgressBar();
                        }));
                    };

                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        ShowProgressBar();
                    }));

                    worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                this.ShowInfoMessage(ex.Message);
            }
        }

        private void HideProgressBar()
        {
            this.GridProgressBar.Visibility = Visibility.Collapsed;
            this.gridPaternProgressBar.Visibility = Visibility.Collapsed;
        }

        private void ShowProgressBar()
        {
            this.GridProgressBar.Visibility = Visibility.Visible;
            this.gridPaternProgressBar.Visibility = Visibility.Visible;
        }

        #endregion

        #region Private Methods

        private void criarDiretoriosDeImportacaoPrevEOL()
        {
            if (!Directory.Exists(CAMINHO_FILES))
                Directory.CreateDirectory(CAMINHO_FILES);

            if (!Directory.Exists(CAMINHO_FILES + CAMINHO_ENTRADA_IMPORTACAO))
                Directory.CreateDirectory(CAMINHO_FILES + CAMINHO_ENTRADA_IMPORTACAO);

            if (!Directory.Exists(CAMINHO_FILES + CAMINHO_SAIDA_IMPORTACAO))
                Directory.CreateDirectory(CAMINHO_FILES + CAMINHO_SAIDA_IMPORTACAO);
        }

        private void ShowInfoMessage(string message)
        {
            this.txtMessage.Text = message;
            this.gridMessage.Visibility = Visibility.Visible;
            this.gridContent.Visibility = Visibility.Hidden;
        }

        private void LoadFiles()
        {
            this.criarDiretoriosDeImportacaoPrevEOL();

            this.files = new DirectoryInfo(CAMINHO_FILES + CAMINHO_ENTRADA_IMPORTACAO).GetFiles();
            this.dataGridImportacaoPrevEOLFiles.ItemsSource = files;
        }


        #endregion
    }
}