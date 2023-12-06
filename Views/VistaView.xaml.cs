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
using System.Windows.Shapes;

namespace Zapateria.Views
{
    /// <summary>
    /// Lógica de interacción para VistaView.xaml
    /// </summary>
    public partial class VistaView : Window
    {
        public VistaView()
        {
            InitializeComponent();
            imageButton.PreviewMouseDoubleClick += ImageButton_PreviewMouseDoubleClick;
        }

        private void ImageButton_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ZapateriaView zapateriaView = new ZapateriaView();
            zapateriaView.Show();
            this.Close();
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
