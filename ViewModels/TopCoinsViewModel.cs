using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test_Assignment.Model;

namespace Test_Assignment.ViewModels
{
    public class TopCoinsViewModel:ViewModelBase
    {
        private ObservableCollection<CoinModel> _cryptoList;
        public ObservableCollection<CoinModel> CryptoList
        {
            get { return _cryptoList; }
            set
            {
                _cryptoList = value;
                OnPropertyChanged(nameof(CryptoList));
            }
        }
        public TopCoinsViewModel()
        {
            LoadCryptoList();
        }
        public async Task LoadCryptoList()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiString.ApiKey}");
            var response = await httpClient.GetAsync($"{ApiString.ApiBaseUrl}/assets?limit=10");
            var json = await response.Content.ReadAsStringAsync();

            var coins = JsonConvert.DeserializeObject<SomeDataCoinsModel>(json);
            CryptoList = new ObservableCollection<CoinModel>(coins.Data);
        }
    }
}
