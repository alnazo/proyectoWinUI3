using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using ProyectoAplicacion.dto;
using ProyectoAplicacion.ViewModels;

namespace ProyectoAplicacion.Views;

public sealed partial class MainPage : Page
{
    public static Logica logica = new Logica();
    private readonly Dictionary<string, bool> columnSortStates = new Dictionary<string, bool>();
    private Sitio sitioTablaSelect;

    private MainViewModel ViewModel;

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();

        ViewModel = new MainViewModel();
        InitializeComponent();
        DataContext = ViewModel;
    }

    private void DG_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs args)
    {
        if (args.Column.Header.ToString() == "Id")
        {
            args.Column.Visibility = Visibility.Collapsed;
        }

        if (args.Column.Header.ToString() == "CP")
        {
            args.Column.Header = "Codigo Postal";
        }
        
        if (args.Column.Header.ToString() == "PrecioMedio")
        {
            args.Column.Header = "Precio Medio";

            var binding = (args.Column as DataGridTextColumn)?.Binding as Binding;
            if (binding != null && binding.Path != null && binding.Path.Path == "PrecioMedio")
            {
                binding.Converter = new PrecioMedioConverter();
            }

        }

        if (args.Column.Header.ToString() == "Puntuacion")
        {
            var binding = (args.Column as DataGridTextColumn)?.Binding as Binding;
            if (binding != null && binding.Path != null && binding.Path.Path == "Puntuacion")
            {
                binding.Converter = new PuntuacionConverter();
            }

        }
    }

    private void DG_Selection(object sender, SelectionChangedEventArgs e)
    {
        if (dataGrid.SelectedItem != null)
        {
            editButton.IsEnabled = true;
            deleteButton.IsEnabled = true;

            sitioTablaSelect = (Sitio)dataGrid.SelectedItem;
        }
        else
        {
            editButton.IsEnabled = false;
            deleteButton.IsEnabled = false;
        }
    }

    private void DG_Sorting(object sender, DataGridColumnEventArgs e)
    {
        var columnName = e.Column.Header.ToString();

        if (columnSortStates.ContainsKey(columnName))
        {
            columnSortStates[columnName] = !columnSortStates[columnName];
        }
        else
        {
            columnSortStates.Add(columnName, true);
        }

        var isAscending = columnSortStates[columnName];

        dataGrid.ItemsSource = logica.SortByColum(columnName, isAscending);

        e.Column.SortDirection = isAscending
            ? DataGridSortDirection.Ascending
            : DataGridSortDirection.Descending;

        foreach (var column in dataGrid.Columns)
        {
            if (column.Header.ToString() != columnName)
            {
                column.SortDirection = null;
                columnSortStates.Remove(column.Header.ToString());
            }
        }


    }

    private void editButtonClick(object sender, RoutedEventArgs e)
    {
        if (sitioTablaSelect != null) {
            Frame.Navigate(typeof(AddSiteFormPage), sitioTablaSelect);
        }
    }
    
    private async void deleteButtonClick(object sender, RoutedEventArgs e)
    {
        if (sitioTablaSelect != null)
        {
            ContentDialog dialog = Popup.PopupYesNo(this.XamlRoot, "¿Estas seguro de eliminar este sitio?");

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                logica.eliminarSitio(sitioTablaSelect);

                if (dataGrid != null)
                {
                    ViewModel.Refresh();
                }

            }
        }
    }
    

}
