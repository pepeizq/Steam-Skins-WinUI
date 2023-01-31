using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace Herramientas
{
    public static class Ficheros
    {
        public static bool ExisteFichero(string enlaceFichero)
        {
            Uri enlace = new Uri(enlaceFichero);

            try
            {
                StorageFile fichero = StorageFile.GetFileFromApplicationUriAsync(enlace).AsTask().Result;

                if (fichero != null) 
                {
                    return true;
                }
            }
            catch
            {

            }

            return false;
        }

        public static string LeerFicheroDentroAplicacion(string enlaceFichero)
        {
            Uri enlace = new Uri(enlaceFichero);
            StorageFile fichero = StorageFile.GetFileFromApplicationUriAsync(enlace).AsTask().Result;
            return FileIO.ReadTextAsync(fichero).AsTask().Result;
        }

        public static string LeerFicheroFueraAplicacion(string enlaceFichero)
        {
            enlaceFichero = enlaceFichero.Replace("/", Strings.ChrW(92).ToString());

            StorageFile fichero = StorageFile.GetFileFromPathAsync(enlaceFichero).AsTask().Result;
            return FileIO.ReadTextAsync(fichero).AsTask().Result;
        }

        public static async void EscribirFichero(string nombreFichero, string contenido)
        {
            StorageFolder carpetaApp = ApplicationData.Current.LocalFolder;

            try
            {
                await carpetaApp.CreateFolderAsync("Plantillas", CreationCollisionOption.FailIfExists);
            }
            catch { }

            StorageFolder carpetaPlantillas = await carpetaApp.GetFolderAsync("Plantillas");
            StorageFile fichero = await carpetaPlantillas.CreateFileAsync(nombreFichero, CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(fichero, contenido);
        }

        public static async Task<int> LeerCantidadFicheros()
        {
            StorageFolder carpetaApp = ApplicationData.Current.LocalFolder;
            StorageFolder carpetaPlantillas = null;

            try
            {
                carpetaPlantillas = await carpetaApp.GetFolderAsync("Plantillas");
            }
            catch { }
            
            if (carpetaPlantillas != null)
            {
                IReadOnlyList<StorageFile> ficheros = await carpetaPlantillas.GetFilesAsync();
                return ficheros.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
