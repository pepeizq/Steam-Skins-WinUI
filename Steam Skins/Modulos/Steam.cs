using Microsoft.Win32;
using Windows.Storage;
using static Steam_Skins.MainWindow;

namespace Modulos
{
    public static class Steam
    {
        public static void CargarRuta()
        {
            RegistryKey registro = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");

            if (registro.GetValue("SteamPath") != null)
            {
                string carpetaSteam = registro.GetValue("SteamPath").ToString();
                carpetaSteam = carpetaSteam.Replace("/", "\\");
                carpetaSteam = carpetaSteam + "\\skins";

                ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
                datos.Values["OpcionesSteamInstalacion"] = carpetaSteam;

                ObjetosVentana.tbOpcionesSteamRutaCarpeta.Text = carpetaSteam;
            }
        }

        public static string GenerarRuta()
        {
            ApplicationDataContainer datos = ApplicationData.Current.LocalSettings;
           
            if (datos.Values["OpcionesSteamInstalacion"] != null) 
            {
                string carpetaSteam = datos.Values["OpcionesSteamInstalacion"].ToString();
                return carpetaSteam;
            }
            
            return null;
        }

        public static void CambiarSkin(string nombre)
        {
            RegistryKey registro = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");

            try
            {
                registro.SetValue("SkinV5", nombre);
            }
            catch { }          
        }
    }
}
