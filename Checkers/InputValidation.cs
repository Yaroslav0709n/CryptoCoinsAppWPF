using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_Assignment.Model;

namespace Test_Assignment.Checkers
{
    internal class InputValidation
    {
        private const string ApiBaseUrl = "https://api.coincap.io/v2";
        private const string ApiKey = "6d0c6fca-c85b-48be-9d36-4f25aa58c0fe";
        public static async Task<bool> InputCheck(string selectedItem)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
            var response = await httpClient.GetAsync($"{ApiBaseUrl}/assets");
            var json = await response.Content.ReadAsStringAsync();
            var coins = JsonConvert.DeserializeObject<SomeDataCoinsModel>(json);
            return !coins.Data.Any(c => c.Id == selectedItem);
        }
    }
}
