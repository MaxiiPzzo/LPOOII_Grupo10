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
    /// Lógica de interacción para FormLongTextboxUC.xaml
    /// </summary>
    public partial class FormLongTextboxUC : UserControl
    {
        public FormLongTextboxUC()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(FormLongTextboxUC));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(FormLongTextboxUC));
    }
}
