using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppDemo.Views
{
    public partial class BmiCalculatorView : Page
    {
        public BmiCalculatorView()
        {
            InitializeComponent();
        }

        private void CalculateBMI_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(WeightTextBox.Text, out double weight) &&
                double.TryParse(HeightTextBox.Text, out double height) &&
                height > 0)
            {
                double bmi = weight / (height * height);

                // Określenie kategorii według ustalonych norm
                string category = GetBmiCategory(bmi);

                // Wyświetlenie wyniku wraz z kategorią
                ResultTextBlock.Text = $"Twoje BMI: {bmi:F2}\nKategoria: {category}";
            }
            else
            {
                ResultTextBlock.Text = "Proszę podać poprawne wartości wagi i wzrostu!";
            }
        }

        private string GetBmiCategory(double bmi)
        {
            if (bmi < 16)
                return "wygłodzenie";
            else if (bmi <= 16.99)
                return "wychudzenie";
            else if (bmi <= 18.49)
                return "niedowaga";
            else if (bmi <= 24.99)
                return "wartość prawidłowa";
            else if (bmi <= 29.99)
                return "nadwaga";
            else if (bmi <= 34.99)
                return "otyłość I stopnia";
            else if (bmi <= 39.99)
                return "otyłość II stopnia";
            else
                return "otyłość III stopnia";
        }
    }
}
