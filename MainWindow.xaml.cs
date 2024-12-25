using System.Windows;
using System.Windows.Navigation;
using WpfAppDemo.Views;

namespace WpfAppDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Optionally, navigate to one of the views by default
            MainFrame.Navigate(new BmiCalculatorView());
        }

        private void BmiCalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BmiCalculatorView());
        }

        private void CurrencyConverterButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CurrencyConverterView());
        }
    }
}
