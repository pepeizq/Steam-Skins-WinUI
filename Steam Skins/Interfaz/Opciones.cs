using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.AppLifecycle;
using System;
using System.Collections.Generic;
using Windows.Globalization;
using Windows.Storage;
using Windows.System.UserProfile;
using WinRT.Interop;
using static Steam_Skins.MainWindow;

namespace Interfaz
{
    public static class Opciones
    {
        public static void CargarDatos()
        {
            ObjetosVentana.nvItemOpciones.PointerEntered += Animaciones.EntraRatonNvItem2;
            ObjetosVentana.nvItemOpciones.PointerExited += Animaciones.SaleRatonNvItem2;

            //---------------------------------

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;

            IReadOnlyList<string> idiomasApp = ApplicationLanguages.ManifestLanguages;

            foreach (var idioma in idiomasApp)
            {
                ObjetosVentana.cbOpcionesIdioma.Items.Add(idioma);
            }

            if (datos.Values["OpcionesIdioma"] == null)
            {
                IReadOnlyList<string> idiomasUsuario = GlobalizationPreferences.Languages;
                bool seleccionado = false;

                foreach (var idioma in idiomasUsuario)
                {
                    foreach (var idioma2 in idiomasApp)
                    {
                        if (idioma2 == idioma)
                        {
                            ObjetosVentana.cbOpcionesIdioma.SelectedItem = idioma2;
                            seleccionado = true;
                        }
                    }
                }

                if (seleccionado == false)
                {
                    ObjetosVentana.cbOpcionesIdioma.SelectedIndex = 0;
                }

                datos.Values["OpcionesIdioma"] = ObjetosVentana.cbOpcionesIdioma.SelectedItem;
            }
            else
            {
                ObjetosVentana.cbOpcionesIdioma.SelectedItem = datos.Values["OpcionesIdioma"];
            }

            ApplicationLanguages.PrimaryLanguageOverride = ObjetosVentana.cbOpcionesIdioma.SelectedItem.ToString();
          
            ObjetosVentana.cbOpcionesIdioma.SelectionChanged += CbOpcionIdioma;
            ObjetosVentana.cbOpcionesIdioma.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbOpcionesIdioma.PointerExited += Animaciones.SaleRatonComboCaja2;

            //---------------------------------

            if (datos.Values["OpcionesPantalla"] == null)
            {
                datos.Values["OpcionesPantalla"] = 0;
            }

            ObjetosVentana.cbOpcionesPantalla.SelectionChanged += CbOpcionPantalla;
            ObjetosVentana.cbOpcionesPantalla.PointerEntered += Animaciones.EntraRatonComboCaja2;
            ObjetosVentana.cbOpcionesPantalla.PointerExited += Animaciones.SaleRatonComboCaja2;
            ObjetosVentana.cbOpcionesPantalla.SelectedIndex = (int)datos.Values["OpcionesPantalla"];

            //---------------------------------

            ObjetosVentana.botonOpcionesLimpiar.Click += BotonOpcionLimpiar;
            ObjetosVentana.botonOpcionesLimpiar.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonOpcionesLimpiar.PointerExited += Animaciones.SaleRatonBoton2;
        }

        public static void CbOpcionIdioma(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesIdioma"] = cb.SelectedItem;

            ApplicationLanguages.PrimaryLanguageOverride = datos.Values["OpcionesIdioma"].ToString();
        }
       
        public static void CbOpcionPantalla(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
            datos.Values["OpcionesPantalla"] = cb.SelectedIndex;

            IntPtr ventanaInt = WindowNative.GetWindowHandle(ObjetosVentana.ventana);
            WindowId ventanaID = Win32Interop.GetWindowIdFromWindow(ventanaInt);
            AppWindow ventana2 = AppWindow.GetFromWindowId(ventanaID);

            if (cb.SelectedIndex == 0)
            {
                ventana2.SetPresenter(AppWindowPresenterKind.Default);
            }
            else if (cb.SelectedIndex == 1)
            {
                ventana2.SetPresenter(AppWindowPresenterKind.FullScreen);
            }
            else if (cb.SelectedIndex == 2)
            {
                ventana2.SetPresenter(AppWindowPresenterKind.Overlapped);
            }
        }

        public static async void BotonOpcionLimpiar(object sender, RoutedEventArgs e)
        {
            await ApplicationData.Current.ClearAsync();
            AppInstance.Restart(null);
        }
    }
}
