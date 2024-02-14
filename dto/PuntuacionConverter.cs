using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

namespace ProyectoAplicacion.dto;
public class PuntuacionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is double stars)
        {
            return MostrarEstrellas(stars);
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }


    private string MostrarEstrellas(double puntuacion)
    {
        StringBuilder estrellas = new StringBuilder();

        for (var i = 1; i <= (int)puntuacion; i++)
        {
            estrellas.Append('⭐');
        }

        return estrellas.ToString();
    }

}
