using FontAwesome6;
using FontAwesome6.Fonts;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.Windows.ApplicationModel.Resources;
using System;
using Windows.ApplicationModel;
using Windows.System;
using Windows.UI;
using static Steam_Skins.MainWindow;

namespace Interfaz
{
    public static class Menu
    {
        public static void Cargar()
        {
            ResourceLoader recursos = new ResourceLoader();
           
            //--------------------------------------------------------------------

            //FontAwesome icono1 = new FontAwesome
            //{
            //    Icon = EFontAwesomeIcon.Solid_ThumbsUp,
            //    Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"])
            //};

            //MenuFlyoutItem2 item1 = new MenuFlyoutItem2
            //{
            //    Icon = icono1,
            //    Text = recursos.GetString("MenuRate"),
            //    Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
            //    RequestedTheme = ElementTheme.Dark
            //};

            //item1.Click += BotonAbrirVotar;
            //item1.PointerEntered += Animaciones.EntraRatonMenuFlyoutItem2;
            //item1.PointerExited += Animaciones.SaleRatonMenuFlyoutItem2;

            //ObjetosVentana.menuItemMenu.Items.Add(item1);

            FontAwesome icono2 = new FontAwesome
            {
                Icon = EFontAwesomeIcon.Brands_Github,
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"])
            };

            MenuFlyoutItem2 item2 = new MenuFlyoutItem2
            {
                Icon = icono2,
                Text = recursos.GetString("MenuGithub"),
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark
            };

            item2.Click += BotonAbrirCodigoFuente;
            item2.PointerEntered += Animaciones.EntraRatonMenuFlyoutItem2;
            item2.PointerExited += Animaciones.SaleRatonMenuFlyoutItem2;

            ObjetosVentana.menuItemMenu.Items.Add(item2);

            //--------------------------------------------------------------------

            MenuFlyoutSeparator separador1 = new MenuFlyoutSeparator
            {
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Height = 30
            };

            ObjetosVentana.menuItemMenu.Items.Add(separador1);

            //--------------------------------------------------------------------

            MenuFlyoutItem2 item3 = new MenuFlyoutItem2
            {
                Text = recursos.GetString("MenuContact"),
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item3.Click += BotonAbrirContactar;
            item3.PointerEntered += Animaciones.EntraRatonMenuFlyoutItem2;
            item3.PointerExited += Animaciones.SaleRatonMenuFlyoutItem2;

            ObjetosVentana.menuItemMenu.Items.Add(item3);

            MenuFlyoutItem2 item4 = new MenuFlyoutItem2
            {
                Text = recursos.GetString("MenuPatchNotes"),
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item4.Click += BotonAbrirNotasParche;
            item4.PointerEntered += Animaciones.EntraRatonMenuFlyoutItem2;
            item4.PointerExited += Animaciones.SaleRatonMenuFlyoutItem2;

            ObjetosVentana.menuItemMenu.Items.Add(item4);

            //--------------------------------------------------------------------

            MenuFlyoutSeparator separador2 = new MenuFlyoutSeparator
            {
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Height = 30
            };

            ObjetosVentana.menuItemMenu.Items.Add(separador2);

            //--------------------------------------------------------------------

            MenuFlyoutItem2 item5 = new MenuFlyoutItem2
            {
                Text = "pepeizqapps.com",
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item5.Click += BotonAbrirWeb1;
            item5.PointerEntered += Animaciones.EntraRatonMenuFlyoutItem2;
            item5.PointerExited += Animaciones.SaleRatonMenuFlyoutItem2;

            ObjetosVentana.menuItemMenu.Items.Add(item5);

            MenuFlyoutItem2 item6 = new MenuFlyoutItem2
            {
                Text = "pepeizqdeals.com",
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item6.Click += BotonAbrirWeb2;
            item6.PointerEntered += Animaciones.EntraRatonMenuFlyoutItem2;
            item6.PointerExited += Animaciones.SaleRatonMenuFlyoutItem2;

            ObjetosVentana.menuItemMenu.Items.Add(item6);

            //--------------------------------------------------------------------

            MenuFlyoutSeparator separador3 = new MenuFlyoutSeparator
            {
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Height = 30
            };

            ObjetosVentana.menuItemMenu.Items.Add(separador3);

            //--------------------------------------------------------------------

            MenuFlyoutItem2 item7 = new MenuFlyoutItem2
            {
                Text = recursos.GetString("MenuExit"),
                Foreground = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"]),
                RequestedTheme = ElementTheme.Dark,
                Margin = new Thickness(-30, 0, 0, 0)
            };

            item7.Click += BotonCerrarApp;
            item7.PointerEntered += Animaciones.EntraRatonMenuFlyoutItem2;
            item7.PointerExited += Animaciones.SaleRatonMenuFlyoutItem2;

            ObjetosVentana.menuItemMenu.Items.Add(item7);
        }

        public async static void BotonAbrirVotar(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=" + Package.Current.Id.FamilyName));
        }

        public async static void BotonAbrirCodigoFuente(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://github.com/pepeizq/Widgets-Games"));
        }

        public async static void BotonAbrirContactar(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/contact/"));
        }

        public async static void BotonAbrirNotasParche(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/patch-notes/"));
        }

        public async static void BotonAbrirWeb1(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqapps.com/"));
        }

        public async static void BotonAbrirWeb2(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://pepeizqdeals.com/"));
        }

        public static void BotonCerrarApp(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            app.Exit();
        }
    }
}
