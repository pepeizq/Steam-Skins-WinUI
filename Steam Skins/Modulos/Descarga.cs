using Microsoft.UI.Xaml;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using static Steam_Skins.MainWindow;

namespace Modulos
{
    public static class Descarga
    {
        public static async void Iniciar(string enlaceDescarga, string nombreSkin, string carpetaEspecifica)
        {
            Skins.ActivarDesactivar(false);
            ObjetosVentana.prSkinsDescarga.Visibility = Visibility.Visible;

            await Task.Delay(100);

            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:15.0) Gecko/20100101 Firefox/15.0.1");
            
            try
            {
                byte[] ficheroBytes = await cliente.GetByteArrayAsync(enlaceDescarga);
                File.WriteAllBytes(ApplicationData.Current.LocalFolder.Path + "\\" + nombreSkin + ".zip", ficheroBytes);
            }
            catch { }

            StorageFile ficheroDescarga = await StorageFile.GetFileFromPathAsync(ApplicationData.Current.LocalFolder.Path + "\\" + nombreSkin + ".zip");
            BasicProperties tamaño = await ficheroDescarga.GetBasicPropertiesAsync();

            if (tamaño.Size > 0)
            {
                IStorageFolder carpetaSteam = await StorageFolder.GetFolderFromPathAsync(Steam.GenerarRuta() + "\\skins");
                await ficheroDescarga.MoveAsync(carpetaSteam, "fichero", NameCollisionOption.ReplaceExisting);

                ZipFile.ExtractToDirectory(ficheroDescarga.Path, carpetaSteam.Path, true);

                if (carpetaEspecifica != null)
                {
                    Directory.Move(carpetaSteam.Path + "\\" + nombreSkin + "\\" + carpetaEspecifica, carpetaSteam.Path + "\\" + nombreSkin + "2");
                    Directory.Delete(carpetaSteam.Path + "\\" + nombreSkin, true);
                }

                await ficheroDescarga.DeleteAsync();
                
                Steam.CambiarSkin(nombreSkin);
            }

            ObjetosVentana.prSkinsDescarga.Visibility = Visibility.Collapsed;
            Skins.ActivarDesactivar(true);
        }
    }
}
