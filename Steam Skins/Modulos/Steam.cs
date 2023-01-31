using Microsoft.Win32;

namespace Modulos
{
    public static class Steam
    {
        public static string GenerarRuta()
        {
            RegistryKey registro = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
            string carpetaSteam = registro.GetValue("SteamPath").ToString();
            carpetaSteam = carpetaSteam.Replace("/", "\\");

            return carpetaSteam;
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
