using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Assignment.Model;
using Test_Assignment.ViewModels;

namespace Test_Assignment.Views
{
    /// <summary>
    /// Логика взаимодействия для TopCoinsPage.xaml
    /// </summary>
    public partial class TopCoinsPage : Page
    {
        public TopCoinsPage()
        {
            InitializeComponent();
            DataContext = new TopCoinsViewModel();
        }
        private async void MyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                CoinModel? selectedItem = listView.SelectedItem as CoinModel;
                var fullInfo = new InformationAboutCoin(selectedItem);
                fullInfo.Show();
            }
        }
    }
}
