using System.Windows.Controls;

namespace UPE_ONS.Views
{
    /// <summary>
    /// Interaction logic for Apresentacao.xaml
    /// </summary>
    public partial class Apresentacao : UserControl
    {
        public Apresentacao()
        {
            InitializeComponent();

            Util.Animation.fadeIn(this, this.txtBoasVindas.Name);
        }
    }
}