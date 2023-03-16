using FontAwesome6;
using Microsoft.UI.Xaml;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using System.Collections.Generic;
using Windows.System;
using static Steam_Skins.MainWindow;

namespace Interfaz
{
    public static class Cerrar
    {
        private static bool cerrar2 = false;

        public static void Cargar()
        {
            ObjetosVentana.ventana.Closed += VentanaCerrar;

            ObjetosVentana.botonCerrarAppSi.Click += SiCerrar;
            ObjetosVentana.botonCerrarAppSi.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonCerrarAppSi.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.botonCerrarAppNo.Click += NoCerrar;
            ObjetosVentana.botonCerrarAppNo.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonCerrarAppNo.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.botonCerrarAppAzar.Click += AbrirEnlaceAzar;
            ObjetosVentana.botonCerrarAppAzar.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonCerrarAppAzar.PointerExited += Animaciones.SaleRatonBoton2;
        }

        private static void VentanaCerrar(object sender, WindowEventArgs e)
        {
            if (cerrar2 == false)
            {
                e.Handled = true;
                ObjetosVentana.gridCierre.Visibility = Visibility.Visible;

                ResourceLoader recursos = new ResourceLoader();

                List<MensajeCerrar> mensajes = new List<MensajeCerrar>
                {
                    new MensajeCerrar(EFontAwesomeIcon.Brands_Github, recursos.GetString("AppClosingMessage1"), AppDatos.Github),
                    //new MensajeCerrar(EFontAwesomeIcon.Solid_ThumbsUp, recursos.GetString("AppClosingMessage2"), AppDatos.Votar),
                    new MensajeCerrar(EFontAwesomeIcon.Solid_Desktop, recursos.GetString("AppClosingMessage3"), AppDatos.NotasParches)
                };

                Random azar = new Random();
                int numeroElegido = azar.Next(0, mensajes.Count);

                ObjetosVentana.iconoCerrarAppAzar.Icon = mensajes[numeroElegido].icono;
                ObjetosVentana.tbCerrarAppAzar.Text = mensajes[numeroElegido].mensaje;
                ObjetosVentana.botonCerrarAppAzar.Tag = mensajes[numeroElegido].enlace;
            }
        }

        private static void SiCerrar(object sender, RoutedEventArgs e)
        {
            cerrar2 = true;

            Application app = Application.Current;
            app.Exit();
        }

        private static void NoCerrar(object sender, RoutedEventArgs e)
        {
            ObjetosVentana.gridCierre.Visibility = Visibility.Collapsed;
        }

        private static async void AbrirEnlaceAzar(object sender, RoutedEventArgs e)
        {
            Button2 boton = sender as Button2;
            string enlace = boton.Tag as string;

            await Launcher.LaunchUriAsync(new Uri(enlace));
        }
    }

    public class MensajeCerrar
    {
        public EFontAwesomeIcon icono { get; set; }
        public string mensaje { get; set; }
        public string enlace { get; set; }

        public MensajeCerrar(EFontAwesomeIcon Icono, string Mensaje, string Enlace)
        {
            icono = Icono;
            mensaje = Mensaje;
            enlace = Enlace;
        }
    }
}
