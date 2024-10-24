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
using ClasesBase;

namespace Vistas.MVVP.View
{
    /// <summary>
    /// Interaction logic for EstadosDeCompetencias.xaml
    /// </summary>
    public partial class EstadosDeCompetencias : Window
    {
        public EstadosDeCompetencias()
        {
            InitializeComponent();
            CargarEstados();
            ConfigurarEnlace();
        }
        public void CargarEstados()
        {

        // Cargar los datos del archivo XML
        XmlDataProvider xmlDataProvider = new XmlDataProvider();
        xmlDataProvider.Source = new Uri("./MVVP/EstadosComp.xml", UriKind.Relative);
        xmlDataProvider.XPath = "/EstadosCompetencias/Estado";

        // Enlazar el ComboBox a los datos XML
        EstadosComboBox.DataContext = xmlDataProvider;
        EstadosComboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding());

        }
        public void ConfigurarEnlace()
        {
            // Crear el enlace para la propiedad Fill del rectángulo
        Binding fillBinding = new Binding("SelectedItem.InnerText")
        {
            Source = EstadosComboBox,
            Converter = new ConversorDeEstados()
        };

        // Enlazar el Fill del Rectangle al ComboBox con el conversor
        EstadoRectangle.SetBinding(Rectangle.FillProperty, fillBinding);
 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
