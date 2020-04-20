using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using COVID.Models;
using Newtonsoft.Json;

namespace COVID.Services
{
    public static class AzureClient
    {
        private static string Url { get; } = "https://covidapi20200420180335.azurewebsites.net/covid19tg";
        public static async Task<InfosCovid> RefreshDataAsync()
        {
            var uri = new Uri(Url);
            HttpClient myClient = new HttpClient();

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
            
                var returnValue = new InfosCovid();
                returnValue.Details=JsonConvert.DeserializeObject<List<Details>>(content);
                return returnValue;
            }
            return null;
        }
    }
}
