using CommunityToolkit.WinUI.Notifications;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using System.Diagnostics;
using Windows.Foundation.Metadata;
using Windows.UI.Notifications;
//using static Principal.MainWindow;

namespace Herramientas
{
    public static class Notificaciones
    {
        public static async void Ventana(string titulo, string contenido = null, string cerrar = null)
        {
            ContentDialog notificacion = new ContentDialog
            {
                Title = titulo,
                Content = contenido
            };

            if (cerrar == null)
            {
                notificacion.CloseButtonText = cerrar;
            }

            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
            {
                //notificacion.XamlRoot = ObjetosVentana.ventana.Content.XamlRoot;
            }

            ContentDialogResult resultado = await notificacion.ShowAsync();
        }

        public static void Consola(string titulo)
        {
            Debug.WriteLine(titulo);
        }

        public static void Toast(string titulo, string enlace = null, string imagen = null)
        {
            AdaptiveText textoTitulo = new AdaptiveText
            {
                Text = titulo,
                HintMaxLines = 4
            };

            ToastGenericAppLogo logo = new ToastGenericAppLogo
            {
                Source = "Assets/Imagenes/notificaciones.png",
                HintCrop = ToastGenericAppLogoCrop.Default
            };

            ToastBindingGeneric contenido = new ToastBindingGeneric
            {
                AppLogoOverride = logo
            };
            contenido.Children.Add(textoTitulo);
           
            if (imagen != null)
            {
                ToastGenericHeroImage hero = new ToastGenericHeroImage
                {
                    Source = imagen
                };

                contenido.HeroImage = hero;
            }

            ToastVisual tostadaVisual = new ToastVisual
            {
                BindingGeneric = contenido
            };

            ToastActionsCustom tostadaAcciones = new ToastActionsCustom();

            if (enlace != null)
            {
                ResourceLoader recursos = new ResourceLoader();

                ToastButton botonAbrir = new ToastButton(recursos.GetString("Open"), enlace)
                {
                    ActivationType = ToastActivationType.Protocol
                };

                if (botonAbrir != null)
                {
                    tostadaAcciones.Buttons.Add(botonAbrir);
                }
            }

            ToastContent tostada = new ToastContent
            {
                Visual = tostadaVisual,
                Actions = tostadaAcciones
            };

            try
            {
                ToastNotification notificacion = new ToastNotification(tostada.GetXml())
                {
                    ExpirationTime = DateTime.Now.AddSeconds(60)
                };

                ToastNotifier notificador = ToastNotificationManager.CreateToastNotifier();
                notificador.Show(notificacion);
            }
            catch (Exception)
            {

            }
        }
    }
}
