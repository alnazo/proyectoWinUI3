using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using ProyectoAplicacion.dto;
using ProyectoAplicacion.enums;
using ProyectoAplicacion.ViewModels;

namespace ProyectoAplicacion.Views;

public sealed partial class AddSiteFormPage : Page
{
    public Via[] viaList => (Via[])Enum.GetValues(typeof(Via));
    public Sitio sitio;

    public AddSiteFormViewModel ViewModel { get; }

    public AddSiteFormPage()
    {
        ViewModel = App.GetService<AddSiteFormViewModel>();
        InitializeComponent();

        sitio = new Sitio();
        this.DataContext = sitio;
        viaSelect.SelectedIndex = 0;
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is Sitio && (Sitio)e.Parameter != null)
        {
            prepareView();

            sitio = (Sitio)e.Parameter;
            loadForm(sitio);
        }
        base.OnNavigatedTo(e);
    }

    private void loadForm(Sitio sitio)
    {
        nombre.Text = sitio.Nombre;
        puntuacion.Value = sitio.Puntuacion;
        telefono.Text = sitio.Telefono.ToString();
        precio.Value = sitio.PrecioMedio;
        viaSelect.SelectedItem = sitio.Via;
        direccion.Text = sitio.Direccion;
        local.Text = sitio.Local.ToString();
        municipio.Text = sitio.Municipio;
        cp.Text = sitio.CP.ToString();
    }

    private void prepareView()
    {
        clearButton.Visibility = Visibility.Collapsed;
        saveButton.Content = "Cambiar datos";
        saveButton.Click -= saveSite;
        saveButton.Click += changeInfo;

    }

    private void changeInfo(object sender, RoutedEventArgs e)
    {
        Sitio newSitio = new Sitio(nombre.Text, (int)puntuacion.Value, precio.Value, int.Parse(telefono.Text), (Via)viaSelect.SelectedItem, direccion.Text, int.Parse(local.Text), municipio.Text, int.Parse(cp.Text));

        changeData(sitio, newSitio);
    }

    private void saveSite(object sender, RoutedEventArgs e)
    {
        sitio = new Sitio(
            nombre.Text,
            (int)puntuacion.Value, 
            precio.Value,
            int.Parse(telefono.Text),
            (Via)viaSelect.SelectedItem,
            direccion.Text,
            int.Parse(local.Text),
            municipio.Text,
            int.Parse(cp.Text)
        );

        changeData(sitio);
    }

    private void clearForm(object sender, RoutedEventArgs e)
    {
        nombre.Text = string.Empty;
        puntuacion.Value = 0;
        telefono.Text = "0";
        precio.Value = 0;
        direccion.Text = string.Empty;
        local.Text = "0";
        municipio.Text = string.Empty;
        cp.Text = "0";    
    }

    private async void changeData(Sitio sitio, Sitio newSitio = null)
    {
        var newSitiobool = newSitio != null ? ValidationSitio.validar(newSitio) : true;
        var sitiobool = newSitio == null ? ValidationSitio.validar(sitio) : true;

        if (!newSitiobool && newSitio != null)
        {
            MainPage.logica.editarSitio(sitio, newSitio);
            sitiobool = false;
        }
        else if (!sitiobool)
        {
            MainPage.logica.agregarSitio(sitio);
            newSitiobool = false;
        }

        if (sitiobool || newSitiobool)
        {
            ContentDialog dialog = Popup.PopupValidator(this.XamlRoot, sitio.Nombre);
            await dialog.ShowAsync();
        }
        else
        {
            Frame.Navigate(typeof(MainPage));
        }
        
    }

}
