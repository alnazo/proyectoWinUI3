using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace ProyectoAplicacion.dto;
public class Popup
{

    private static ContentDialog PopupCreate() {
        ContentDialog dialog = new ContentDialog();
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.DefaultButton = ContentDialogButton.Primary;

        return dialog;
    }

    public static ContentDialog PopupYesNo(XamlRoot xamlRoot, string msg)
    {
        ContentDialog dialog = PopupCreate();
        dialog.XamlRoot = xamlRoot;
        dialog.Title = msg;

        dialog.PrimaryButtonText = "Si";
        dialog.SecondaryButtonText = "No";

        return dialog;
    }

    public static ContentDialog PopupValidator(XamlRoot xamlRoot, string sitio)
    {
        ContentDialog dialog = PopupCreate();

        dialog.XamlRoot = xamlRoot;
        dialog.Title = "No se ha podido guardar la informacion de: " + sitio;
        dialog.Content = ValidationSitio.getFailedBlock();

        dialog.PrimaryButtonText = "Ok";

        return dialog;
    }


}
