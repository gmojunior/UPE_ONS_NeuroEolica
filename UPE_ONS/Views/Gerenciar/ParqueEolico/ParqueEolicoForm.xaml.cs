using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UPE_ONS.Controllers;
using UPE_ONS.Model;

namespace UPE_ONS.Views
{
    /// <summary>
    /// Interaction logic for ParqueEolicoForm.xaml
    /// </summary>
    public partial class ParqueEolicoForm : UserControl
    {
        public enum EnumParqueEolicoFormType
        {
            CADASTRAR,
            ALTERAR
        }

        private ParqueEolico parqueEolico;
        private EnumParqueEolicoFormType tipo;

        public ParqueEolicoForm(EnumParqueEolicoFormType tipo, object elemento)
        {
            this.tipo = tipo;

            InitializeComponent();
            InitializeMyComponents(tipo, elemento);
        }

        private void InitializeMyComponents(EnumParqueEolicoFormType tipo, object elemento)
        {
            if (tipo == EnumParqueEolicoFormType.CADASTRAR)
            {
                this.btnAction.Content = "Cadastrar";
                this.txtTitulo.Text = "Cadastrar Parque Eólico";

                this.parqueEolico = new ParqueEolico();
            }
            else if (tipo == EnumParqueEolicoFormType.ALTERAR)
            {
                this.btnAction.Content = "Alterar";
                this.txtTitulo.Text = "Alterar Parque Eólico";

                this.parqueEolico = (ParqueEolico)elemento;
                this.txtPotenciaMaxima.Text = Math.Round(this.parqueEolico.PotenciaMaxima, 2).ToString().Replace(".",",");
            }
            this.DataContext = parqueEolico;
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.ClearAllFields();
            Main.NavigateTo(EnumNavigateTo.PARQUE_EOLICO_SELECT, null);
        }

        private void ClearAllFields()
        {
            this.txtParqueEolico.Text = "";
            this.txtPotenciaMaxima.Text = "";
            this.txtSiglaCPTEC.Text = "";
            this.txtSiglaPrevEOL.Text = "";
            this.txtNumMaquinas.Text = "";
            this.txtSiglaGETOT.Text = "";
        }

        private int _noOfErrorsOnScreen = 0;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        private void CadastrarParqueEolico_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private void CadastrarParqueEolico_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.txtPotenciaMaxima.Text == null || this.txtPotenciaMaxima.Text.Equals(""))
                this.parqueEolico.PotenciaMaxima = 1;
            else
                this.parqueEolico.PotenciaMaxima = Double.Parse(this.txtPotenciaMaxima.Text);

            if (tipo == EnumParqueEolicoFormType.CADASTRAR)
            {
                try
                {
                    FactoryController.getInstance().ParqueEolicoController.cadastrar(this.parqueEolico);
                    //FactoryController.getInstance().PrevisorController.montarEstruturaParaPrevisao();
                    MessageBox.Show("Parque eólico cadastrado com sucesso.");

                    this.ClearAllFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (tipo == EnumParqueEolicoFormType.ALTERAR)
            {
                try
                {
                    FactoryController.getInstance().ParqueEolicoController.atualizar(this.parqueEolico);
                    MessageBox.Show("Parque eólico atualizado com sucesso.");

                    this.ClearAllFields();

                    Main.NavigateTo(EnumNavigateTo.PARQUE_EOLICO_SELECT, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            e.Handled = true;
        }
    }
}