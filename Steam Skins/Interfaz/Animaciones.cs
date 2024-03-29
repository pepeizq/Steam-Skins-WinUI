﻿using FontAwesome6.Fonts;
using Microsoft.UI;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System.Collections.Generic;
using Windows.UI;

namespace Interfaz
{
    public static class Animaciones
    {
        public static void EntraRatonNvItem2(object sender, PointerRoutedEventArgs e)
        {
            SolidColorBrush fondo = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"])
            {
                Opacity = 0.2
            };

            NavigationViewItem2 nvItem = sender as NavigationViewItem2;
            nvItem.CambiarCursor(InputSystemCursor.Create(InputSystemCursorShape.Hand));

            Grid grid = nvItem.Content as Grid;
            grid.Background = fondo;

            if (grid.Children[0] != null)
            {
                if (grid.Children[0].GetType() == typeof(AnimatedIcon))
                {
                    AnimatedIcon icono = grid.Children[0] as AnimatedIcon;
                    AnimatedIcon.SetState(icono, "Pressed");
                }
            }
        }

        public static void SaleRatonNvItem2(object sender, PointerRoutedEventArgs e)
        {
            NavigationViewItem2 nvItem = sender as NavigationViewItem2;
            nvItem.CambiarCursor(InputSystemCursor.Create(InputSystemCursorShape.Arrow));

            Grid grid = nvItem.Content as Grid;
            grid.Background = new SolidColorBrush(Colors.Transparent);

            if (grid.Children[0] != null)
            {
                if (grid.Children[0].GetType() == typeof(AnimatedIcon))
                {
                    AnimatedIcon icono = grid.Children[0] as AnimatedIcon;
                    AnimatedIcon.SetState(icono, "Normal");
                }
            }
        }

        public static void EntraRatonBoton2(object sender, PointerRoutedEventArgs e)
        {
            Button2 boton = sender as Button2;
            EventoBoton(boton, "ColorPrimario");
        }

        public static void SaleRatonBoton2(object sender, PointerRoutedEventArgs e)
        {
            Button2 boton = sender as Button2;
            EventoBoton(boton, "ColorFuente");
        }

        private static void EventoBoton(Button2 boton, string color)
        {
            if (boton != null)
            {
                boton.CambiarCursor(InputSystemCursor.Create(InputSystemCursorShape.Hand));

                List<object> listaObjetos = new List<object>();

                if (boton.Content.GetType() == typeof(StackPanel))
                {
                    StackPanel sp = boton.Content as StackPanel;

                    if (sp.Children.Count > 0)
                    {
                        foreach (object objeto in sp.Children)
                        {
                            listaObjetos.Add(objeto);
                        }
                    }
                }
                else if (boton.Content.GetType() == typeof(Grid))
                {
                    Grid grid = boton.Content as Grid;

                    if (grid.Children.Count > 0)
                    {
                        foreach (object objeto in grid.Children)
                        {
                            listaObjetos.Add(objeto);
                        }
                    }
                }

                if (listaObjetos.Count > 0)
                {
                    foreach (object objeto in listaObjetos)
                    {
                        if (objeto.GetType() == typeof(TextBlock))
                        {
                            TextBlock tb = objeto as TextBlock;
                            tb.Foreground = new SolidColorBrush((Color)Application.Current.Resources[color]);
                        }
                        else if (objeto.GetType() == typeof(FontAwesome))
                        {
                            FontAwesome icono = objeto as FontAwesome;
                            icono.Foreground = new SolidColorBrush((Color)Application.Current.Resources[color]);
                        }
                    }
                }
            }
        }

        public static void EntraRatonComboCaja2(object sender, PointerRoutedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            cb.CambiarCursor(InputSystemCursor.Create(InputSystemCursorShape.Hand));
        }

        public static void SaleRatonComboCaja2(object sender, PointerRoutedEventArgs e)
        {
            ComboBox2 cb = sender as ComboBox2;
            cb.CambiarCursor(InputSystemCursor.Create(InputSystemCursorShape.Arrow));
        }

        public static void EntraRatonStackPanel2(object sender, PointerRoutedEventArgs e)
        {
            StackPanel2 sp = sender as StackPanel2;
            sp.CambiarCursor(InputSystemCursor.Create(InputSystemCursorShape.Hand));

            SolidColorBrush fondo = new SolidColorBrush((Color)Application.Current.Resources["ColorFuente"])
            {
                Opacity = 0.2
            };

            sp.Background = fondo;
        }

        public static void SaleRatonStackPanel2(object sender, PointerRoutedEventArgs e)
        {
            StackPanel2 sp = sender as StackPanel2;
            sp.CambiarCursor(InputSystemCursor.Create(InputSystemCursorShape.Arrow));
            sp.Background = new SolidColorBrush(Colors.Transparent);
        }

        public static void EntraRatonMenuFlyoutItem2(object sender, PointerRoutedEventArgs e)
        {
            MenuFlyoutItem2 item = sender as MenuFlyoutItem2;
            item.CambiarCursor(InputSystemCursor.Create(InputSystemCursorShape.Hand));
        }

        public static void SaleRatonMenuFlyoutItem2(object sender, PointerRoutedEventArgs e)
        {
            MenuFlyoutItem2 item = sender as MenuFlyoutItem2;
            item.CambiarCursor(InputSystemCursor.Create(InputSystemCursorShape.Arrow));
        }
    }
}
