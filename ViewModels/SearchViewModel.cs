using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using System.Windows;
using Test_Assignment.Checkers;
using Test_Assignment.Model;
using Test_Assignment.Command;

namespace Test_Assignment.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public ICommand SearchCommand { get; private set; }
        public ICommand ChangeToDarkCommand { get; private set; }
        public ICommand ChangeToLightCommand { get; private set; }
        public SearchViewModel()
        {
            SearchCommand = new RelayCommand(obj => Search());
            ChangeToDarkCommand = new RelayCommand(obj => ChangeToDark());
            ChangeToLightCommand = new RelayCommand(obj => ChangeToLight());
        }

        private async void Search()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                MessageBox.Show("String cannot be empty");
                return;
            }
            string searchText = SearchText.Trim().ToLower();
            if (SpecialCoinsId.replacements.ContainsKey(searchText))
                searchText = SpecialCoinsId.replacements[searchText];
            else if(SpecialCoinsId.replacements.ContainsValue(searchText))
                searchText = searchText;
            else if (await InputValidation.InputCheck(searchText))
            {
                MessageBox.Show($"'{searchText}' coin not found.");
                return;
            }
            else
                searchText = searchText;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiString.ApiKey}");
            var response = await httpClient.GetAsync($"{ApiString.ApiBaseUrl}/assets/{searchText}");
            var json = await response.Content.ReadAsStringAsync();

            var itemId = JsonConvert.DeserializeObject<SomeDataCoinModel>(json);

            if (itemId != null)
            {
                var fullInfo = new InformationAboutCoin(itemId.Data);
                fullInfo.Show();
            }
        }


        private void ChangeToDark()
        {
            var uri = new Uri(@"Dictionaries/DictionaryResourcesSecond.xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void ChangeToLight()
        {
            var uri = new Uri(@"Dictionaries/DictionaryResourcesFirst.xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
