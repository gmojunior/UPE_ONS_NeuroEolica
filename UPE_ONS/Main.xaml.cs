using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UPE_ONS.Util;
using UPE_ONS.Views;
using UPE_ONS.Views.Importacao;

namespace UPE_ONS
{
    public enum EnumNavigateTo
    {
        APRESENTACAO,
        PARQUE_EOLICO_CADASTRAR_FORM,
        PARQUE_EOLICO_ALTERAR_FORM,
        PARQUE_EOLICO_SELECT,
        IMPORTACAO,
        CALIBRAR,
        IMPORTACAO_CPTEC,
        VISUALIZAR_DADOS,
        VISUALIZAR_PREVISOES,
        PREVER,
        PREVER_VENTO_POTENCIA
    }
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public static StackPanel mainContent;

        public Main()
        {
            InitializeComponent();

            mainContent = this.MainContent;

            NavigateTo(EnumNavigateTo.APRESENTACAO, null);
        }

        public static StackPanel getContentInstance()
        {
            return mainContent;
        }

        public static void NavigateTo(EnumNavigateTo screen, object element)
        {
            Main.getContentInstance().Children.Clear();
            switch (screen)
            {
                case EnumNavigateTo.APRESENTACAO:
                    Main.getContentInstance().Children.Add(new Apresentacao());
                    break;
                case EnumNavigateTo.PARQUE_EOLICO_SELECT:
                    Main.getContentInstance().Children.Add(new ParqueEolicoSelect());
                    break;
                case EnumNavigateTo.PARQUE_EOLICO_CADASTRAR_FORM:
                    Main.getContentInstance().Children.Add(new ParqueEolicoForm(ParqueEolicoForm.EnumParqueEolicoFormType.CADASTRAR, null));
                    break;
                case EnumNavigateTo.PARQUE_EOLICO_ALTERAR_FORM:
                    Main.getContentInstance().Children.Add(new ParqueEolicoForm(ParqueEolicoForm.EnumParqueEolicoFormType.ALTERAR, element));
                    break;
                case EnumNavigateTo.IMPORTACAO_CPTEC:
                    Main.getContentInstance().Children.Add(new ImportacaoCPTEC());
                    break;
                case EnumNavigateTo.IMPORTACAO:
                    Main.getContentInstance().Children.Add(new ImportacaoPrevEOL());
                    break;
                case EnumNavigateTo.VISUALIZAR_DADOS:
                    Main.getContentInstance().Children.Add(new VisualizarDados());
                    break;
                case EnumNavigateTo.CALIBRAR:
                    Main.getContentInstance().Children.Add(new Calibrar());
                    break;
                case EnumNavigateTo.PREVER:
                    Main.getContentInstance().Children.Add(new Previsor());
                    break;
                case EnumNavigateTo.PREVER_VENTO_POTENCIA:
                    Main.getContentInstance().Children.Add(new PrevisorVentoPotencia());
                    break;
                case EnumNavigateTo.VISUALIZAR_PREVISOES:
                    Main.getContentInstance().Children.Add(new VisualizarPrevisoes());
                    break;
            }
        }

        private void ParqueEolico_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(EnumNavigateTo.PARQUE_EOLICO_SELECT, null);
        }

        private void VisualizarPrevisoes_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(EnumNavigateTo.VISUALIZAR_PREVISOES, null);
        }

        private void ImportacaoCPTEC_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(EnumNavigateTo.IMPORTACAO_CPTEC, null);
        }

        private void ImportacaoPrevEOL_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(EnumNavigateTo.IMPORTACAO, null);
        }

        private void Apresentacao_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(EnumNavigateTo.APRESENTACAO, null);
        }
        
        private void WindowsTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Minimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximizar_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void Visualizar_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(EnumNavigateTo.VISUALIZAR_DADOS, null);
        }

        private void Calibrar_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(EnumNavigateTo.CALIBRAR, null);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show(Constants.CLOSE_MESSAGE, Constants.CONFIRMATION_CAPTION, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Environment.Exit(0);
        }

        private void Previsor_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(EnumNavigateTo.PREVER, null);
        }

        private void PrevisorVentoPotencia_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(EnumNavigateTo.PREVER_VENTO_POTENCIA, null);
        }
    }
}