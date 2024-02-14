using System.Collections.ObjectModel;

namespace ProyectoAplicacion.Helpers;

public class PaginationHelper<T>
{
    public ObservableCollection<T> GetPage(ObservableCollection<T> sourceCollection, int pageSize, int pageNumber)
    {
        var startIndex = (pageNumber - 1) * pageSize;
        var count = Math.Min(pageSize, sourceCollection.Count - startIndex);

        if (startIndex < 0 || count <= 0)
        {
            return new ObservableCollection<T>();
        }
        else
        {
            return new ObservableCollection<T>(sourceCollection.Skip(startIndex).Take(count));
        }
    }
}
