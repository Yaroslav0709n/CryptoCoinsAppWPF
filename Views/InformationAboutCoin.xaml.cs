using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Test_Assignment.Model;
using Test_Assignment.ViewModels;

namespace Test_Assignment
{
    /// <summary>
    /// Логика взаимодействия для InformationAboutCoin.xaml
    /// </summary>
    public partial class InformationAboutCoin : Window
    {
        public InformationAboutCoin(CoinModel selectedItem)
        {
            InitializeComponent();
            DataContext = new InformationAboutCoinViewModel(selectedItem);
        }
    }
}
