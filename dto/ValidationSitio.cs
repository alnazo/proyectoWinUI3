using System.Text;

namespace ProyectoAplicacion.dto;
public class ValidationSitio
{
    public static bool sitioNombre = false;
    public static bool sitioTelefono = false;
    public static bool sitioDireccion = false;
    public static bool sitioLocal = false;
    public static bool sitioMunicipio = false;
    public static bool sitioCP = false;

    public static bool validar(Sitio sitio)
    {
        sitioNombre = (sitio.Nombre == null || sitio.Nombre.Equals("")) ? true : false;
        sitioTelefono = sitio.Telefono.ToString().Length != 9 ? true : false;
        sitioDireccion = (sitio.Direccion == null || sitio.Direccion.Equals("")) ? true : false;
        sitioLocal = sitio.Local < 0 ? true : false;
        sitioMunicipio = (sitio.Municipio == null || sitio.Municipio.Equals("")) ? true : false;
        sitioCP = sitio.CP.ToString().Length != 5 ? true : false;

        var res = sitioNombre || sitioTelefono || sitioDireccion || sitioLocal || sitioMunicipio || sitioCP;

        return res;
    }

    public static void resetVal()
    {
        sitioNombre = false;
        sitioTelefono = false;
        sitioDireccion = false;
        sitioLocal = false;
        sitioMunicipio = false;
        sitioCP = false;
    }

    public static string getFailedBlock()
    {
        StringBuilder stringBuilder = new StringBuilder();

        if (sitioNombre) stringBuilder.AppendLine("· El Nombre del sitio no puede estar vacio.");
        if (sitioTelefono) stringBuilder.AppendLine("· El Telefono debe de ser de 9 digitos.");
        if (sitioDireccion) stringBuilder.AppendLine("· La Direccion del lugar no puede estar vacia.");
        if (sitioLocal) stringBuilder.AppendLine("· El Numero del local debe ser 0 (S/N) o mayor.");
        if (sitioMunicipio) stringBuilder.AppendLine("· El Municipio no debe estar vacio.");
        if (sitioCP) stringBuilder.AppendLine("· El Codigo Postar debe de ser de 5 digitos.");

        return stringBuilder.ToString();

    }

}
