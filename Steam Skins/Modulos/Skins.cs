using Interfaz;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using Windows.System;
using Windows.UI;
using static Steam_Skins.MainWindow;

namespace Modulos
{
    public static class Skins
    {
        public static void Cargar()
        {
            List<Skin> lista = new List<Skin>();

            Skin adwaita = new Skin
            {
                nombre = "Adwaita",
                codigo = "Adwaita-for-Steam-master",
                enlace = "https://github.com/tkashkin/Adwaita-for-Steam/archive/refs/heads/master.zip",
                screenshoot = "https://i.imgur.com/DOKayi8.png",
                github = "https://github.com/tkashkin/Adwaita-for-Steam/",
                carpetaDescompresion = "Adwaita"
            };

            lista.Add(adwaita);

            Skin air = new Skin
            {
                nombre = "Air",
                codigo = "Air-for-Steam-main",
                enlace = "https://github.com/leskal/Air-for-Steam/archive/refs/heads/main.zip",
                screenshoot = "https://i.imgur.com/qt3tsfv.png",
                github = "https://github.com/leskal/Air-for-Steam/",
                carpetaDescompresion = null
            };

            lista.Add(air);

            Skin airClassic = new Skin
            {
                nombre = "Air Classic",
                codigo = "Air-Classic-main",
                enlace = "https://github.com/leskal/Air-Classic/archive/refs/heads/main.zip",
                screenshoot = "https://i.imgur.com/RG16zOw.png",
                github = "https://github.com/leskal/Air-Classic/",
                carpetaDescompresion = null
            };

            lista.Add(airClassic);

            Skin compact = new Skin
            {
                nombre = "Compact",
                codigo = "Compact-master",
                enlace = "https://github.com/badanka/Compact/archive/refs/heads/master.zip",
                screenshoot = "https://i.imgur.com/Mdhlxwo.png",
                github = "https://github.com/badanka/Compact/",
                carpetaDescompresion = null
            };

            lista.Add(compact);

            Skin fluent = new Skin
            {
                nombre = "Fluent",
                codigo = "Fluent-for-Steam-main",
                enlace = "https://github.com/purogamer/Fluent-for-Steam/archive/refs/heads/main.zip",
                screenshoot = "https://i.imgur.com/3GISKNk.png",
                github = "https://github.com/purogamer/Fluent-for-Steam/",
                carpetaDescompresion = null
            };

            lista.Add(fluent);

            Skin metro = new Skin
            {
                nombre = "Metro",
                codigo = "UPMetroSkin-master",
                enlace = "https://github.com/redsigma/UPMetroSkin/archive/refs/heads/master.zip",
                screenshoot = "https://i.imgur.com/ImRWsGI.png",
                github = "https://github.com/redsigma/UPMetroSkin",
                carpetaDescompresion = "Unofficial 4.x Patch\\Main Files [Install First]"
            };

            lista.Add(metro);

            Skin original = new Skin
            {
                nombre = "Original",
                codigo = "OG-Steam-main",
                enlace = "https://github.com/ungstein/OG-Steam/archive/refs/heads/main.zip",
                screenshoot = "https://i.imgur.com/EMCaA8h.png",
                github = "https://github.com/ungstein/OG-Steam/",
                carpetaDescompresion = "OG-Steam"
            };

            lista.Add(original);

            Skin pixelvision2 = new Skin
            {
                nombre = "PixelVision²",
                codigo = "Pixelvision2-master",
                enlace = "https://github.com/somini/Pixelvision2/archive/refs/heads/master.zip",
                screenshoot = "https://i.imgur.com/zLBwmFS.png",
                github = "https://github.com/somini/Pixelvision2/",
                carpetaDescompresion = null
            };

            lista.Add(pixelvision2);

            Skin threshold = new Skin
            {
                nombre = "Threshold",
                codigo = "Threshold-Skin-master",
                enlace = "https://github.com/Edgarware/Threshold-Skin/archive/refs/heads/master.zip",
                screenshoot = "https://i.imgur.com/dGihk7V.png",
                github = "https://github.com/Edgarware/Threshold-Skin/",
                carpetaDescompresion = null
            };

            lista.Add(threshold);

            Skin miku = new Skin
            {
                nombre = "Threshold Miku",
                codigo = "Threshold-Miku-Light",
                enlace = "https://github.com/Jack-Myth/Threshold-Miku/archive/refs/heads/Light.zip",
                screenshoot = "https://i.imgur.com/sNkeyKo.png",
                github = "https://github.com/Jack-Myth/Threshold-Miku/",
                carpetaDescompresion = null
            };

            lista.Add(miku);

            Skin miku2 = new Skin
            {
                nombre = "Threshold Miku Dark",
                codigo = "Threshold-Miku-master",
                enlace = "https://github.com/Jack-Myth/Threshold-Miku/archive/refs/heads/master.zip",
                screenshoot = "https://i.imgur.com/KwOPQCM.png",
                github = "https://github.com/Jack-Myth/Threshold-Miku/",
                carpetaDescompresion = null
            };

            lista.Add(miku2);

            //---------------------------------------------------

            ObjetosVentana.spSkins.Children.Clear();

            foreach (Skin skin in lista)
            {
                StackPanel sp = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                TextBlock tb = new TextBlock
                {
                    Text = skin.nombre,
                    Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"])
                };

                sp.Children.Add(tb);

                Button2 boton = new Button2
                {
                    Content = sp,
                    Tag = skin,
                    Background = new SolidColorBrush(Colors.Transparent),
                    Padding = new Thickness(15, 12, 15, 12),
                    CornerRadius = new CornerRadius(5),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(10),
                    BorderThickness = new Thickness(0)
                };

                boton.Click += SeleccionarSkin;
                boton.PointerEntered += Animaciones.EntraRatonBoton2;
                boton.PointerExited += Animaciones.SaleRatonBoton2;

                ObjetosVentana.spSkins.Children.Add(boton);
            }

            //---------------------------------------------------

            ObjetosVentana.botonSkinsDescarga.Click += DescargarSkin;
            ObjetosVentana.botonSkinsDescarga.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonSkinsDescarga.PointerExited += Animaciones.SaleRatonBoton2;

            ObjetosVentana.botonSkinsGithub.Click += AbrirGithub;
            ObjetosVentana.botonSkinsGithub.PointerEntered += Animaciones.EntraRatonBoton2;
            ObjetosVentana.botonSkinsGithub.PointerExited += Animaciones.SaleRatonBoton2;
        }

        public static void SeleccionarSkin(object sender, RoutedEventArgs e)
        {
            foreach (Button2 botonSkin in ObjetosVentana.spSkins.Children)
            {
                botonSkin.Background = new SolidColorBrush(Colors.Transparent);
            }

            Button2 boton = sender as Button2;
            boton.Background = new SolidColorBrush((Color)Application.Current.Resources["ColorPrimario"]);
            Skin skin = boton.Tag as Skin;

            ObjetosVentana.imagenSkinSeleccionada.Source = skin.screenshoot;
            ObjetosVentana.botonSkinsDescarga.Tag = skin;
            ObjetosVentana.botonSkinsGithub.Tag = skin;

            ObjetosVentana.gridSkinMensaje.Visibility = Visibility.Collapsed;
            ObjetosVentana.gridSkinSeleccionada.Visibility = Visibility.Visible;
        }

        public static void DescargarSkin(object sender, RoutedEventArgs e)
        {
            Button2 boton = sender as Button2;
            Skin skin = boton.Tag as Skin;

            Descarga.Iniciar(skin.enlace, skin.codigo, skin.carpetaDescompresion);
        }

        public static async void AbrirGithub(object sender, RoutedEventArgs e)
        {
            Button2 boton = sender as Button2;
            Skin skin = boton.Tag as Skin;

            await Launcher.LaunchUriAsync(new Uri(skin.github));
        }

        public static void ActivarDesactivar(bool estado)
        {
            ObjetosVentana.botonSkinsDescarga.IsEnabled = estado;
            ObjetosVentana.botonSkinsGithub.IsEnabled = estado;

            foreach (Button2 boton in ObjetosVentana.spSkins.Children)
            {
                boton.IsEnabled = estado;
            }
        }
    }

    public class Skin
    {
        public string nombre;
        public string codigo;
        public string enlace;
        public string screenshoot;
        public string github;
        public string carpetaDescompresion;
    }
}
