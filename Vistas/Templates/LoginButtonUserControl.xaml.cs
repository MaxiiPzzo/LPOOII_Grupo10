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

namespace Vistas.Templates
{
    /// <summary>
    /// Lógica de interacción para LoginButtonUserControl.xaml
    /// </summary>
    public partial class LoginButtonUserControl : UserControl
    {
        public event RoutedEventHandler ButtonClick;

        public LoginButtonUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string ButtonTittle { get; set; }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            ButtonClick?.Invoke(this, e);
        }

    }
}
