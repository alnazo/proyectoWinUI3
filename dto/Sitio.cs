using System.ComponentModel;
using ProyectoAplicacion.enums;

namespace ProyectoAplicacion.dto;
public class Sitio : INotifyPropertyChanged
{
    public int Id { get; set; }
    //Datos
    public String Nombre { get; set; }
    public double Puntuacion { get; set; }
    public double PrecioMedio { get; set; }
    public int Telefono { get; set; }

    //Ubicacion
    public Via Via { get; set; }
    public String Direccion { get; set; }
    public int Local { get; set; }
    public String Municipio { get; set; }
    public int CP { get; set; }

    private static int ultimoId = 0;

    public Sitio() {}

    public Sitio(string nombre, double puntuacion, double precioMedio, int telefono , Via via, string direccion, int local, string municipio, int cp)
    {
        Id = ultimoId++;
        ultimoId = ultimoId++;

        Nombre = nombre;
        Puntuacion = puntuacion;
        PrecioMedio = precioMedio;
        Telefono = telefono;

        Via = via;
        Direccion = direccion;
        Local = local;
        Municipio = municipio;
        CP = cp;
    }

    public event PropertyChangedEventHandler PropertyChanged;

}
