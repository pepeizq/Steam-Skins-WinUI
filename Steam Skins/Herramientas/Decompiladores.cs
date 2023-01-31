using System;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Herramientas
{
    public static class Decompiladores
    {
        public static async Task<string> CogerHtml(string enlace)
        {
            string html = String.Empty;

            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:15.0) Gecko/20100101 Firefox/15.0.1");

            try
            {
                HttpResponseMessage respuesta = new HttpResponseMessage();
                respuesta = await cliente.GetAsync(new Uri(enlace));
                cliente.Dispose();
                respuesta.EnsureSuccessStatusCode();

                html = await respuesta.Content.ReadAsStringAsync() as string;
                respuesta.Dispose();
            }
            catch (Exception)
            {

            };

            cliente.Dispose();
            return html;
        }
    }
}
