using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;

namespace ClientConvertisseurV2.Services
{
    public class WSService : IService
    {
        static HttpClient client = new HttpClient();
        private static string _url;


        static async Task RunAsync()
        {
            client.BaseAddress = new Uri(_url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public WSService(string url)
        {
            _url = url;
            RunAsync();
        }
    }
}
