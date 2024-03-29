using FontAwesome6.Fonts;
using Interfaz;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.ApplicationModel.Resources;
using Modulos;

namespace Steam_Skins
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            CargarObjetosVentana();

            BarraTitulo.Generar(this);
            BarraTitulo.CambiarTitulo(null);
            Cerrar.Cargar();
            Pestañas.Cargar();
            ScrollViewers.Cargar();
            Interfaz.Menu.Cargar();
            Opciones.Cargar();
            Skins.Cargar();
            Steam.CargarRuta();
        }

        public void CargarObjetosVentana()
        {
            ObjetosVentana.ventana = ventana;
            ObjetosVentana.gridTitulo = gridTitulo;
            ObjetosVentana.tbTitulo = tbTitulo;
            ObjetosVentana.nvPrincipal = nvPrincipal;
            ObjetosVentana.nvItemMenu = nvItemMenu;
            ObjetosVentana.menuItemMenu = menuItemMenu;
            ObjetosVentana.nvItemOpciones = nvItemOpciones;
            ObjetosVentana.nvItemSubirArriba = nvItemSubirArriba;
            ObjetosVentana.gridCierre = gridCierre;

            //-------------------------------------------------------------------

            ObjetosVentana.botonCerrarAppSi = botonCerrarAppSi;
            ObjetosVentana.botonCerrarAppNo = botonCerrarAppNo;
            ObjetosVentana.iconoCerrarAppAzar = iconoCerrarAppAzar;
            ObjetosVentana.tbCerrarAppAzar = tbCerrarAppAzar;
            ObjetosVentana.botonCerrarAppAzar = botonCerrarAppAzar;

            //-------------------------------------------------------------------

            ObjetosVentana.gridSkins = gridSkins;
            ObjetosVentana.gridOpciones = gridOpciones;

            //-------------------------------------------------------------------

            ObjetosVentana.svSkins = svSkins;
            ObjetosVentana.spSkins = spSkins;
            ObjetosVentana.gridSkinMensaje = gridSkinMensaje;
            ObjetosVentana.gridSkinSeleccionada = gridSkinSeleccionada;
            ObjetosVentana.imagenSkinSeleccionada = imagenSkinSeleccionada;
            ObjetosVentana.botonSkinsDescarga = botonSkinsDescarga;
            ObjetosVentana.prSkinsDescarga = prSkinsDescarga;
            ObjetosVentana.botonSkinsGithub = botonSkinsGithub;

            //-------------------------------------------------------------------

            ObjetosVentana.spOpcionesBotones = spOpcionesBotones;
            ObjetosVentana.svOpciones = svOpciones;
            ObjetosVentana.spOpcionesPestañas = spOpcionesPestanas;
            ObjetosVentana.botonOpcionesSteamCambiarCarpeta = botonOpcionesSteamCambiarCarpeta;
            ObjetosVentana.tbOpcionesSteamRutaCarpeta = tbOpcionesSteamRutaCarpeta;
            ObjetosVentana.tsOpcionesSteamCarpeta = tsOpcionesSteamCarpeta;
            ObjetosVentana.cbOpcionesIdioma = cbOpcionesIdioma;
            ObjetosVentana.cbOpcionesPantalla = cbOpcionesPantalla;
            ObjetosVentana.botonOpcionesLimpiar = botonOpcionesLimpiar;
        }

        public static class ObjetosVentana
        {
            public static Window ventana { get; set; }
            public static Grid gridTitulo { get; set; }
            public static TextBlock tbTitulo { get; set; }
            public static NavigationView nvPrincipal { get; set; }
            public static NavigationViewItem nvItemMenu { get; set; }
            public static MenuFlyout menuItemMenu { get; set; }
            public static NavigationViewItem nvItemOpciones { get; set; }
            public static NavigationViewItem nvItemSubirArriba { get; set; }
            public static Grid gridCierre { get; set; }

            //-------------------------------------------------------------------

            public static Button botonCerrarAppSi { get; set; }
            public static Button botonCerrarAppNo { get; set; }
            public static FontAwesome iconoCerrarAppAzar { get; set; }
            public static TextBlock tbCerrarAppAzar { get; set; }
            public static Button botonCerrarAppAzar { get; set; }

            //-------------------------------------------------------------------

            public static Grid gridSkins { get; set; }
            public static Grid gridOpciones { get; set; }

            //-------------------------------------------------------------------

            public static ScrollViewer svSkins { get; set; }
            public static StackPanel spSkins { get; set; }
            public static Grid gridSkinMensaje { get; set; }
            public static Grid gridSkinSeleccionada { get; set; }
            public static Image imagenSkinSeleccionada { get; set; }
            public static Button botonSkinsDescarga { get; set; }
            public static ProgressRing prSkinsDescarga { get; set; }
            public static Button botonSkinsGithub { get; set; }

            //-------------------------------------------------------------------
          
            public static StackPanel spOpcionesBotones { get; set; }
            public static ScrollViewer svOpciones { get; set; }
            public static StackPanel spOpcionesPestañas { get; set; }
            public static Button botonOpcionesSteamCambiarCarpeta { get; set; }
            public static TextBlock tbOpcionesSteamRutaCarpeta { get; set; }
            public static ToggleSwitch tsOpcionesSteamCarpeta { get; set; }
            public static ComboBox cbOpcionesIdioma { get; set; }
            public static ComboBox cbOpcionesPantalla { get; set; }
            public static Button botonOpcionesLimpiar { get; set; }
        }

        private void nvPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceLoader recursos = new ResourceLoader();

            Pestañas.CreadorItems(FontAwesome6.EFontAwesomeIcon.Solid_Palette, recursos.GetString("Skins"));

            StackPanel sp = (StackPanel)ObjetosVentana.nvPrincipal.MenuItems[1];
            Pestañas.Visibilidad(gridSkins, true, sp, true);
        }

        private void nvPrincipal_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            ResourceLoader recursos = new ResourceLoader();

            if (args.InvokedItemContainer != null)
            {
                if (args.InvokedItemContainer.GetType() == typeof(NavigationViewItem2))
                {
                    NavigationViewItem2 item = args.InvokedItemContainer as NavigationViewItem2;

                    if (item.Name == "nvItemMenu")
                    {

                    }
                    else if (item.Name == "nvItemOpciones")
                    {
                        Pestañas.Visibilidad(gridOpciones, true, null, false);
                        BarraTitulo.CambiarTitulo(recursos.GetString("Options"));
                        ScrollViewers.EnseñarSubir(svOpciones);
                    }
                }
            }

            if (args.InvokedItem != null)
            {
                if (args.InvokedItem.GetType() == typeof(StackPanel2))
                {
                    StackPanel2 sp = (StackPanel2)args.InvokedItem;

                    if (sp.Children[1] != null)
                    {
                        if (sp.Children[1].GetType() == typeof(TextBlock))
                        {
                            TextBlock tb = sp.Children[1] as TextBlock;

                            if (tb.Text == recursos.GetString("Skins"))
                            {
                                Pestañas.Visibilidad(gridSkins, true, sp, true);
                                BarraTitulo.CambiarTitulo(null);
                                ScrollViewers.EnseñarSubir(svSkins);  
                            }                           
                        }
                    }
                }
            }
        }
    }
}
