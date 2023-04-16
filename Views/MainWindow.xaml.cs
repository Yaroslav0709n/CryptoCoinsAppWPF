using System.Windows;
using Test_Assignment.ViewModels;
using Test_Assignment.Views;

namespace Test_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myFrame.Content = new TopCoinsPage();
            DataContext = new SearchViewModel();
            
        }
    }
}
