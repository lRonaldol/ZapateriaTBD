using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zapateria.Views
{
    /// <summary>
    /// Lógica de interacción para VerZapatosView.xaml
    /// </summary>
    public partial class VerZapatosView : UserControl
    {
        public VerZapatosView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VistaView vistaView = new VistaView();
            vistaView.Show();

           Window.GetWindow(this).Close();
        }
    }
}
