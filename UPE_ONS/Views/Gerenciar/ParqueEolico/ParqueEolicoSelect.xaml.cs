using System;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ParqueEolicoSelect : UserControl
    {

        private ObservableCollection<ParqueEolico> listaParquesEolicos;

        public ParqueEolicoSelect()
        {
            InitializeComponent();

            var worker = new BackgroundWorker();

            worker.DoWork += (sender, args) =>
            {
                try
                {
                    this.listaParquesEolicos =
                        new ObservableCollection<ParqueEolico>(FactoryController.getInstance().ParqueEolicoController.getAll());

                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        if (this.listaParquesEolicos.Count > 0)
                            this.ShowParquesEolicos();
                        else
                            this.ShowInfoMessage("Ainda não existe nenhum parque eólico cadastrado no banco de dados até o presente momento.");

                        this.dataGridParqueEolico.ItemsSource = listaParquesEolicos;
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



        private void ShowParquesEolicos()
        {
            this.dataGridParqueEolico.Visibility = Visibility.Visible;
            this.txtBoxException.Visibility = Visibility.Hidden;
        }

        private void ShowInfoMessage(String message)
        {
            this.txtBoxException.Text = message;
            this.txtBoxException.Visibility = Visibility.Visible;
            this.dataGridParqueEolico.Visibility = Visibility.Hidden;
        }

        private void CadastrarParque_Click(object sender, RoutedEventArgs e)
        {
            Main.NavigateTo(EnumNavigateTo.PARQUE_EOLICO_CADASTRAR_FORM, null);
        }

        private void ExcluirParque_Click(object sender, RoutedEventArgs e)
        {
            int index = this.dataGridParqueEolico.SelectedIndex;
            if (index == -1)
                MessageBox.Show("Por favor, selecione um parque eólico.");
            else
            {
                try
                {
                    if (MessageBox.Show("Tem certeza que deseja remover o parque eólico selecionado? Atenção, sua exclusão pode implicar na exclusão dos dados já importados associados a este parque.", Constants.CONFIRMATION_CAPTION, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        ParqueEolico parqueSelecionado = (ParqueEolico)this.dataGridParqueEolico.SelectedItem;
                        FactoryController.getInstance().ParqueEolicoController.Delete(parqueSelecionado);
                        this.listaParquesEolicos.Remove((ParqueEolico)this.dataGridParqueEolico.SelectedItem);

                        MessageBox.Show("Parque eólico removido com sucesso.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AlterarParque_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = this.dataGridParqueEolico.SelectedItem;
            if (selectedItem != null)
                Main.NavigateTo(EnumNavigateTo.PARQUE_EOLICO_ALTERAR_FORM, selectedItem);
            else
                MessageBox.Show("Por favor, seleciona um Parque Eólico!", "Alerta");
        }
    }
}