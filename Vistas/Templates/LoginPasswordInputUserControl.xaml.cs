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
    /// Lógica de interacción para LoginPasswordInputUserControl.xaml
    /// </summary>
    public partial class LoginPasswordInputUserControl : UserControl
    {
        public LoginPasswordInputUserControl()
        {
            InitializeComponent();
        }

        public string Password
        {
            get { return passBox.Password; }
            set { passBox.Password = value; }
        }

        //public string HintPass
        //{
        //    get { return (string)GetValue(HintProperty); }
        //    set { SetValue(HintProperty, value); }
        //}

        //public static readonly DependencyProperty HintProperty =
        //    DependencyProperty.Register("HintPass", typeof(string), typeof(LoginPasswordInputUserControl));

        //public string CaptionPass
        //{
        //    get { return (string)GetValue(CaptionProperty); }
        //    set { SetValue(CaptionProperty, value); }
        //}

        //public static readonly DependencyProperty CaptionProperty =
        //    DependencyProperty.Register("CaptionPass", typeof(string), typeof(LoginPasswordInputUserControl));
    }
}
