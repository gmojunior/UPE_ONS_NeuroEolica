using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using UPE_ONS.Controllers;
using UPE_ONS.DAO;
using UPE_ONS.Model;

namespace UPE_ONS.Views.Importacao
{
    /// <summary>
    /// Interaction logic for ImportCPTEC.xaml
    /// </summary>
    public partial class ImportacaoCPTEC : UserControl
    {
        private string CAMINHO_FILES = Environment.CurrentDirectory + @"\Arquivos\";
        private const string CAMINHO_ENTRADA_IMPORTACAO = "CPTEC";
        private const string CAMINHO_SAIDA_IMPORTACAO   = "Importados";
        private FileInfo[] files;

        private List<ParqueEolico> listaParquesEolicos;

        public ImportacaoCPTEC()
        {
            try
            {
                InitializeComponent();
                //FactoryDAO.getInstance().CPTECDAO.importOldFile(CAMINHO_FILES + CAMINHO_ENTRADA_IMPORTACAO + @"\SaidaBV.txt", 11);
                //FactoryDAO.getInstance().CPTECDAO.importOldFile(CAMINHO_FILES + CAMINHO_ENTRADA_IMPORTACAO + @"\SaidaCQ.txt", 9);
                //FactoryDAO.getInstance().CPTECDAO.importOldFile(CAMINHO_FILES + CAMINHO_ENTRADA_IMPORTACAO + @"\SaidaEN.txt", 10);

                this.listaParquesEolicos = FactoryController.getInstance().ParqueEolicoController.getAll();
                this.LoadFiles();
            }
            catch (Exception e)
            {
                this.ShowInfoMessage(e.Message);
            }
        }

        private void criarDiretoriosDeImportacaoCPTEC()
        {
            if (!Directory.Exists(CAMINHO_FILES))
                Directory.CreateDirectory(CAMINHO_FILES);

            if(!Directory.Exists(CAMINHO_FILES + CAMINHO_ENTRADA_IMPORTACAO))
                Directory.CreateDirectory(CAMINHO_FILES + CAMINHO_ENTRADA_IMPORTACAO);

            if(!Directory.Exists(CAMINHO_FILES + CAMINHO_SAIDA_IMPORTACAO))
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
            this.criarDiretoriosDeImportacaoCPTEC();

            this.files = new DirectoryInfo(CAMINHO_FILES + CAMINHO_ENTRADA_IMPORTACAO).GetFiles();
            this.dataGridImportacaoCPTECFiles.ItemsSource = files;
        }

        private void ImportCPTEC_Click(object sender, RoutedEventArgs e)
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
                                    string sigla = this.listaParquesEolicos[i].SiglaCPTEC;
                                    if (file.Name.IndexOf(sigla, StringComparison.OrdinalIgnoreCase) != -1)
                                    {
                                        FactoryController.getInstance().CPTEC_Controller.importarArquivoNovo(file.FullName, this.listaParquesEolicos[i].Id);
                                        file.CopyTo(CAMINHO_FILES + CAMINHO_SAIDA_IMPORTACAO + "\\" + file.Name, true);
                                        File.Delete(file.FullName);
                                        break;
                                    }
                                }

                                this.Dispatcher.Invoke(new Action(() =>
                                {
                                    this.processBar.Value += progressoPorAquivo;
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
    }
}