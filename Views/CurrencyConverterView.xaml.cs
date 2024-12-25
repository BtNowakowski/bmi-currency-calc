using System.Windows;
using System.Windows.Controls;

namespace WpfAppDemo.Views
{
    public partial class CurrencyConverterView : Page
    {
        // Example rate: 1 USD = 0.85 EUR 
        private const double ConversionRate = 4.2;

        public CurrencyConverterView()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(UsdTextBox.Text, out double usdAmount))
            {
                double plnAmount = usdAmount * ConversionRate;
                ConvertedResultTextBlock.Text = $"{plnAmount} PLN = {usdAmount:F2} USD";
            }
            else
            {
                ConvertedResultTextBlock.Text = "Please enter a valid USD amount.";
            }
        }
    }
}
