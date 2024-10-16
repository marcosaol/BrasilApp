using BrasilApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BrasilApp.Services
{
    public class LocateCityService
    {
        private HttpClient httpClient;
        private City? city;        
        private string CityName;
        private ObservableCollection<City>? citys;
        private JsonSerializerOptions? jsonSerializerOptions;

        public LocateCityService()
        {
            this.httpClient = new();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<ObservableCollection<City>?> FetchCitys(string CityName)
        {
            Uri uri = new($"https://brasilapi.com.br/api/cptec/v1/cidade/{CityName}");

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string json = await responseMessage.Content.ReadAsStringAsync();
                    citys = JsonSerializer.Deserialize<ObservableCollection<City>>(json, jsonSerializerOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return citys;
        }
    }
}
