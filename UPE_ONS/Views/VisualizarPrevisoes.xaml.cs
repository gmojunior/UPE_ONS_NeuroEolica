using System;
using System.Windows;
using System.Windows.Controls;
using UPE_ONS.Controllers;
using UPE_ONS.Util;

namespace UPE_ONS.Views
{
    /// <summary>
    /// Interaction logic for VisualizarPrevisoes.xaml
    /// </summary>
    public partial class VisualizarPrevisoes : UserControl
    {
        public VisualizarPrevisoes()
        {
            try
            {
                InitializeComponent();

                this.cmbBoxParquesEolicos.ItemsSource = FactoryController.getInstance().ParqueEolicoController.getAll();
            }
            catch (Exception e)
            {
                this.txtMessage.Text = Constants.ERROR_OPEN_CONNECTION;
            }
        }

        private void cmbBoxParquesEolicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void chkBoxAllFields_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}