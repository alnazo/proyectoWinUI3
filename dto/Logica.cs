using System.Collections.ObjectModel;
namespace ProyectoAplicacion.dto;
public class Logica
{
    public ObservableCollection<Sitio> listaSitios { get; set; }

    private string _cachedSortedColumn = string.Empty;

    public Logica()
    {
        listaSitios = new ObservableCollection<Sitio>();

        //Pre-load Sites
        listaSitios.Add(new Sitio("Lou Burguer", 4, 13.40f, 955292063, enums.Via.Calle ,"Cruz", 2, "El Viso Del Alcor", 41520));
        listaSitios.Add(new Sitio("WoW Smash Burguer", 5, 9.60f, 624455990, enums.Via.Calle, "Ramón Soto Vargas", 1, "Camas", 41900));
        listaSitios.Add(new Sitio("Monkey Food", 3, 14.90f, 854705871, enums.Via.Calle, "Jóse Recuerda Rubio", 5, "Sevilla", 41018));
        listaSitios.Add(new Sitio("Papa Jhons Pizza", 4, 16.00f, 954736739, enums.Via.Avenida, "Ramón y Cajal", 12, "Sevilla", 41005));
        listaSitios.Add(new Sitio("Pizzeria Madre Mía", 5, 9.50f, 954706730, enums.Via.Calle, "Vasco de Gama", 149, "Sevilla", 41006));
        listaSitios.Add(new Sitio("Street Food Burger", 4, 18.30f, 679131949, enums.Via.Avenida, "Alemania", 5, "Sevilla", 41012));
        listaSitios.Add(new Sitio("La Croqueta del Abuelo", 5, 12.90f, 955273871, enums.Via.Calle, "Entamador", 10, "Dos Hermanas", 41701));
        listaSitios.Add(new Sitio("Shushi Panda", 4, 22.10f, 955056562, enums.Via.Avenida, "Ingeniero José Luis Prats", 1, "Dos Hermanas", 41703));
        listaSitios.Add(new Sitio("Ramen Shifu", 4, 19.40f, 955543033, enums.Via.Avenida, "Ingeniero José Luis Prats", 1, "Dos Hermanas", 41703));

    }

    public ObservableCollection<Sitio> SortByColum(string sortBy, bool ascending)
    {
        _cachedSortedColumn = sortBy;
        switch(sortBy)
        {
            case "Nombre":
                if (ascending)
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Nombre ascending select item);
                }
                else
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Nombre descending select item);
                }
            case "Puntuacion":
                if (ascending)
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Puntuacion ascending select item);
                }
                else
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Puntuacion descending select item);
                }
            case "Precio Medio":
                if (ascending)
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.PrecioMedio ascending select item);
                }
                else
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.PrecioMedio descending select item);
                }
            case "Telefono":
                if (ascending)
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Telefono ascending select item);
                }
                else
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Telefono descending select item);
                }
            case "Via":
                if (ascending)
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Via ascending select item);
                }
                else
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Via descending select item);
                }
            case "Direccion":
                if (ascending)
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Direccion ascending select item);
                }
                else
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Direccion descending select item);
                }
            case "Local":
                if (ascending)
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Local ascending select item);
                }
                else
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Local descending select item);
                }
            case "Municipio":
                if (ascending)
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Municipio ascending select item);
                }
                else
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.Municipio descending select item);
                }
            case "Codigo Postal":
                if (ascending)
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.CP ascending select item);
                }
                else
                {
                    return new ObservableCollection<Sitio>(from item in listaSitios orderby item.CP descending select item);
                }

            default:
                return listaSitios;
        }
    }
    
    public void agregarSitio(Sitio sitio)
    {
        listaSitios.Add(sitio);
    }

    public void eliminarSitio(Sitio sitio)
    {
        for (var i = 0; i < listaSitios.Count; i++)
        {
            if (listaSitios[i].Id == sitio.Id)
            {
                listaSitios.RemoveAt(i);
                break;
            }
        }
    }

    public void editarSitio(Sitio sitio, Sitio newSitio)
    {
        for (var i = 0; i < listaSitios.Count; i++)
        {
            if (listaSitios[i].Id == sitio.Id)
            {
                newSitio.Id = sitio.Id;
                listaSitios.RemoveAt(i);
                listaSitios.Insert(i, newSitio);
                break;
            }
        }
    }

}
