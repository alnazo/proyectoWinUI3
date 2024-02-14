using Microsoft.UI.Xaml.Data;

namespace ProyectoAplicacion.dto;
public class PrecioMedioConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is double decimalValue)
        {
            return $"{decimalValue:F2} €";
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
