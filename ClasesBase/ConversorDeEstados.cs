using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media; 

namespace ClasesBase
{
    public class ConversorDeEstados : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string estado = value as string;
        
        // Devuelve un color dependiendo del estado
        switch (estado?.ToLower())
        {
            case "programado":
                return Brushes.Green;   // Verde para programado
            case "postergado":
                return Brushes.Orange;  // Naranja para postergado
            case "reprogramado":
                return Brushes.Yellow;  // Amarillo para reprogramado
            case "cancelado":
                return Brushes.Red;     // Rojo para cancelado
            default:
                return Brushes.Gray;    // Gris para cualquier otro estado
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
}
