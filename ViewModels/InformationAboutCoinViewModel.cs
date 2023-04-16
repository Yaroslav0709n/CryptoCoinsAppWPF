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
    public class InformationAboutCoinViewModel:ViewModelBase
    {
        private readonly CoinModel _selectedItem;

        public InformationAboutCoinViewModel(CoinModel selectedItem)
        {
            _selectedItem = selectedItem;
            LoadAsync();
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private double _priceUsd;
        public double PriceUsd
        {
            get { return _priceUsd; }
            set
            {
                _priceUsd = value;
                OnPropertyChanged(nameof(PriceUsd));
            }
        }

        private double _marketCapUsd;
        public double MarketCapUsd
        {
            get { return _marketCapUsd; }
            set
            {
                _marketCapUsd = value;
                OnPropertyChanged(nameof(MarketCapUsd));
            }
        }

        private double _volumeUsd24Hr;
        public double VolumeUsd24Hr
        {
            get { return _volumeUsd24Hr; }
            set
            {
                _volumeUsd24Hr = value;
                OnPropertyChanged(nameof(VolumeUsd24Hr));
            }
        }

        private double _changePercent24Hr;
        public double ChangePercent24Hr
        {
            get { return _changePercent24Hr; }
            set
            {
                _changePercent24Hr = value;
                OnPropertyChanged(nameof(ChangePercent24Hr));
            }
        }

        private ObservableCollection<ExchangeModel> _exchange;
        public ObservableCollection<ExchangeModel> Exchanges
        {
            get { return _exchange; }
            set
            {
                _exchange = value;
                OnPropertyChanged(nameof(Exchanges));
            }
        }
        public async Task LoadAsync()
        {
            Name = _selectedItem.Name;
            Symbol = _selectedItem.Symbol;
            PriceUsd = _selectedItem.RoundedPriceUsd;
            MarketCapUsd = _selectedItem.RoundedMarketCapUsd;
            VolumeUsd24Hr = _selectedItem.RoundedVolumeUsd24Hr;
            ChangePercent24Hr = _selectedItem.RoundedChangePercent24Hr;

            var httpClient2 = new HttpClient();
            httpClient2.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiString.ApiKey}");
            var response2 = await httpClient2.GetAsync($"{ApiString.ApiBaseUrl}/assets/{_selectedItem.Id}/markets?limit=10");
            var json = await response2.Content.ReadAsStringAsync();

            var markets = JsonConvert.DeserializeObject<SomeDataExchangeModel>(json);
            Exchanges = new ObservableCollection<ExchangeModel>(markets.Data);
        }
    }
}
