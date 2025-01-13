# bmi-currency-calc

# Sprawozdanie z projektu WPF: Kalkulator BMI i Konwerter Walut

Wybrano język C# wraz ze środowiskiem Windows Presentation Foundation (WPF), ponieważ umożliwia on tworzenie aplikacji okienkowych z intuicyjnym interfejsem graficznym. Projekt zrealizowano w Visual Studio, które zapewnia wsparcie dla tworzenia i debugowania aplikacji WPF.

## Opis projektu

Projekt w **C# (WPF)** zawiera przykładową aplikację desktopową z **dwoma oddzielnymi widokami**:

1. Kalkulator BMI – oblicza wartość BMI na podstawie wprowadzonych danych (waga, wzrost) oraz wyświetla wynik wraz z odpowiednią kategorią.
2. Konwerter walut – pozwala przeliczyć kwotę w USD na PLN (na podstawie zdefiniowanego kursu).

Nawigacja między widokami jest zrealizowana w **MainWindow** za pomocą kontrolki `Frame` i dwóch przycisków, z których każdy przechodzi do innego `Page`.

Program 1: **Kalkulator BMI**

**Dane wejściowe**

Waga (w kilogramach), wprowadzana w polu tekstowym.

Wzrost (w metrach), wprowadzany w polu tekstowym.

**Dane wyjściowe**

Wartość BMI wraz z kategorią (np. niedowaga, nadwaga).

**Interfejs**

Okienkowy, z wykorzystaniem przycisków, etykiet oraz pól tekstowych. Wynik jest wyświetlany w formie tekstowej pod polami wejściowymi.

**Kategorie BMI**

- Wygłodzenie (<16)

- Wychudzenie (16-16.99)

- Niedowaga (17-18.49)

- Wartość prawidłowa (18.5-24.99)

- Nadwaga (25-29.99)

- Otyłość I stopnia (30-34.99)

- Otyłość II stopnia (35-39.99)

- Otyłość III stopnia (>40)

**Obsługa błędów**

Komunikat „Proszę podać poprawne wartości wagi i wzrostu” w przypadku nieprawidłowych danych wejściowych.


Program 2: **Konwerter walut**

**Dane wejściowe**

Kwota w USD, wprowadzana w polu tekstowym.

**Dane wyjściowe**

Kwota przeliczona na PLN według ustalonego kursu (4,2 PLN/USD).

**Interfejs**

Okienkowy, z polem wejściowym, przyciskiem "Konwertuj" oraz polem wynikowym, w którym wyświetlana jest kwota w PLN.

**Obsługa błędów**

Komunikat „Proszę podać prawidłową kwotę w USD” w przypadku nieprawidłowych danych wejściowych.

**Możliwości rozwoju**

Dynamiczne pobieranie kursów walut z API internetowego.



---

## Struktura projektu

```
WpfAppDemo
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── Views
│   ├── BmiCalculatorView.xaml
│   ├── BmiCalculatorView.xaml.cs
│   ├── CurrencyConverterView.xaml
│   └── CurrencyConverterView.xaml.cs
└── WpfAppDemo.csproj
```
## Elementy obiektowości

- **App.xaml**, **App.xaml.cs** – Pliki startowe aplikacji WPF.
- **MainWindow.xaml**, **MainWindow.xaml.cs** – Główne okno aplikacji, zawiera `Frame` do nawigacji i przyciski do przełączania widoków.

- **Views** (folder):
    - **BmiCalculatorView.xaml**, **BmiCalculatorView.xaml.cs** – Strona z kalkulatorem BMI.
    - **CurrencyConverterView.xaml**, **CurrencyConverterView.xaml.cs** – Strona z konwerterem walut (USD → PLN).

- **CalculateBMI_Click** - Obsługuje logikę obliczania BMI i określania kategorii.
- **ConvertButton_Click** - Realizuje konwersję walut przy użyciu zdefiniowanego kursu.
- **GetBmiCategory** - Pomocnicza metoda do określania kategorii BMI na podstawie wartości.

- Klasy widoków dziedziczą z klasy bazowej **Page**.

## Algorytmy i biblioteki

**Kalkulator BMI**

Algorytm oblicza BMI według wzoru:

Następnie wartość BMI jest klasyfikowana w kategoriach za pomocą metody GetBmiCategory z wykorzystaniem prostych instrukcji warunkowych (if-else).

**Konwerter walut**

Algorytm dokonuje prostego przeliczenia:

Gdzie kurs jest ustalony jako stała o wartości 4,2.

Biblioteki

**System.Windows** Obsługa interfejsu graficznego (WPF).

**System.Windows.Controls** Komponenty interfejsu (przyciski, pola tekstowe).

**System** Obsługa konwersji i operacji matematycznych.

## Obsługa błędów

**Błędy miękkie**

Niepoprawne dane wejściowe (np. brak liczby, liczba ujemna) są obsługiwane przez komunikaty wyświetlane w polu wynikowym.

**Błędy twarde**

Program zakłada poprawność działania środowiska WPF, a wyjątki systemowe (np. brak pamięci) nie są w tym momencie obsługiwane.


---

## Kod źródłowy

Poniżej przedstawiono wszystkie pliki z przykładową zawartością.

### 1. App.xaml

```xml
<Application x:Class="WpfAppDemo.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="MainWindow.xaml">

    <Application.Resources>
        <!-- 
          Definiujemy style w pliku App.xaml, aby obowiązywały globalnie 
          (we wszystkich oknach i stronach).
        -->

        <!-- Ustawienie globalnego koloru tła i koloru czcionki (Foreground) -->
        <SolidColorBrush x:Key="DarkBackgroundBrush" Color="#2E2E2E" />
        <SolidColorBrush x:Key="DarkForegroundBrush" Color="White" />

        <!-- Styl dla okien (Window) - aby wszystkie okna były ciemne i miały białą czcionkę -->
        <Style TargetType="Window">
            <Setter Property="Background" Value="{StaticResource DarkBackgroundBrush}" />
            <Setter Property="Foreground" Value="{StaticResource DarkForegroundBrush}" />
        </Style>

        <!-- Styl dla stron (Page) - dzięki temu strony (Page) też będą ciemne -->
        <Style TargetType="Page">
            <Setter Property="Background" Value="{StaticResource DarkBackgroundBrush}" />
            <Setter Property="Foreground" Value="{StaticResource DarkForegroundBrush}" />
        </Style>

        <!-- Styl dla Button -->
        <Style TargetType="Button">
            <Setter Property="Background" Value="#444444"/>
            <!-- ciemniejszy szary -->
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="BorderBrush" Value="#777777"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="Padding" Value="5,2"/>
            <Setter Property="Margin" Value="5"/>
        </Style>

        <!-- Styl dla TextBox -->
        <Style TargetType="TextBox">
            <Setter Property="Background" Value="#444444"/>
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="BorderBrush" Value="#777777"/>
        </Style>

        <!-- Styl dla TextBlock -->
        <Style TargetType="TextBlock">
            <Setter Property="Foreground" Value="White"/>
        </Style>
    </Application.Resources>
</Application>
```

### 2. App.xaml.cs

```csharp
using System.Windows;

namespace WpfAppDemo
{
    public partial class App : Application
    {
    }
}
```

### 3. MainWindow.xaml

```xml
<Application x:Class="WpfAppDemo.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="MainWindow.xaml">

    <Application.Resources>
        <!-- 
          Definiujemy style w pliku App.xaml, aby obowiązywały globalnie 
          (we wszystkich oknach i stronach).
        -->

        <!-- Ustawienie globalnego koloru tła i koloru czcionki (Foreground) -->
        <SolidColorBrush x:Key="DarkBackgroundBrush" Color="#2E2E2E" />
        <SolidColorBrush x:Key="DarkForegroundBrush" Color="White" />

        <!-- Styl dla okien (Window) - aby wszystkie okna były ciemne i miały białą czcionkę -->
        <Style TargetType="Window">
            <Setter Property="Background" Value="{StaticResource DarkBackgroundBrush}" />
            <Setter Property="Foreground" Value="{StaticResource DarkForegroundBrush}" />
        </Style>

        <!-- Styl dla stron (Page) - dzięki temu strony (Page) też będą ciemne -->
        <Style TargetType="Page">
            <Setter Property="Background" Value="{StaticResource DarkBackgroundBrush}" />
            <Setter Property="Foreground" Value="{StaticResource DarkForegroundBrush}" />
        </Style>

        <!-- Styl dla Button -->
        <Style TargetType="Button">
            <Setter Property="Background" Value="#444444"/>
            <!-- ciemniejszy szary -->
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="BorderBrush" Value="#777777"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="Padding" Value="5,2"/>
            <Setter Property="Margin" Value="5"/>
        </Style>

        <!-- Styl dla TextBox -->
        <Style TargetType="TextBox">
            <Setter Property="Background" Value="#444444"/>
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="BorderBrush" Value="#777777"/>
        </Style>

        <!-- Styl dla TextBlock -->
        <Style TargetType="TextBlock">
            <Setter Property="Foreground" Value="White"/>
        </Style>
    </Application.Resources>
</Application>

```

### 4. MainWindow.xaml.cs

```csharp
using System.Windows;
using WpfAppDemo.Views;

namespace WpfAppDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Domyślnie przechodzimy do Kalkulatora BMI (opcjonalne)
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
```

---

## Widok 1: Kalkulator BMI

### BmiCalculatorView.xaml

```xml
<Page x:Class="WpfAppDemo.Views.BmiCalculatorView"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      Title="BmiCalculatorView">
    <StackPanel Margin="20" HorizontalAlignment="Center" VerticalAlignment="Center">
        <TextBlock Text="Ka" FontSize="24" HorizontalAlignment="Center" />

        <!-- Pole wprowadzania wagi (kg) -->
        <StackPanel Orientation="Horizontal" Margin="0,10,0,0">
            <TextBlock Text="Waga (kg):" Margin="0,0,5,0"/>
            <TextBox x:Name="WeightTextBox" Width="100"/>
        </StackPanel>

        <!-- Pole wprowadzania wzrostu (m) -->
        <StackPanel Orientation="Horizontal" Margin="0,10,0,0">
            <TextBlock Text="Wzrost (m):" Margin="0,0,5,0"/>
            <TextBox x:Name="HeightTextBox" Width="100"/>
        </StackPanel>

        <!-- Przycisk obliczający BMI -->
        <Button Content="Oblicz BMI"
                Margin="0,10,0,0"
                Click="CalculateBMI_Click"/>

        <!-- Tekst z wynikiem -->
        <TextBlock x:Name="ResultTextBlock"
                   FontSize="16"
                   Margin="0,10,0,0"
                   TextWrapping="Wrap"/>
    </StackPanel>
</Page>
```

### BmiCalculatorView.xaml.cs

Poniższy kod oblicza BMI i wyświetla jego wartość. Dodatkowo wyświetlana jest **kategoria** według ustalonych norm:

- **< 16** – wygłodzenie
- **16 – 16,99** – wychudzenie
- **17 – 18,49** – niedowaga
- **18,5 – 24,99** – wartość prawidłowa
- **25 – 29,99** – nadwaga
- **30 – 34,99** – otyłość I stopnia
- **35 – 39,99** – otyłość II stopnia
- **> 40** – otyłość III stopnia

```csharp
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

                // Ustalenie kategorii BMI
                string category = GetBmiCategory(bmi);

                // Wyświetlenie wyniku i kategorii
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
```




---

## Widok 2: Konwerter Walut (USD → PLN)

### CurrencyConverterView.xaml

```xml
<Page x:Class="WpfAppDemo.Views.CurrencyConverterView"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      Title="CurrencyConverterView">
    <StackPanel Margin="20" HorizontalAlignment="Center" VerticalAlignment="Center">
        <TextBlock Text="Konwerter walut (USD → PLN)"
                   FontSize="24"
                   HorizontalAlignment="Center" />

        <!-- Pole wprowadzania kwoty w USD -->
        <StackPanel Orientation="Horizontal" Margin="0,10,0,0">
            <TextBlock Text="USD:" Margin="0,0,5,0"/>
            <TextBox x:Name="UsdTextBox" Width="100"/>
        </StackPanel>

        <!-- Przycisk uruchamiający konwersję -->
        <Button Content="Konwertuj"
                Margin="0,10,0,0"
                Click="ConvertButton_Click"/>

        <!-- Pole tekstowe z wynikiem konwersji -->
        <TextBlock x:Name="ConvertedResultTextBlock"
                   FontSize="16"
                   Margin="0,10,0,0"
                   TextWrapping="Wrap"/>
    </StackPanel>
</Page>
```

### CurrencyConverterView.xaml.cs

W tym przykładzie kurs ustalono na **4.2** (1 USD = 4,2 PLN). Przy konwersji wyświetlana jest finalna kwota w PLN oraz oryginalna kwota w USD:

```csharp
using System.Windows;
using System.Windows.Controls;

namespace WpfAppDemo.Views
{
    public partial class CurrencyConverterView : Page
    {
        // Przykładowy kurs: 1 USD = 4.2 PLN
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
                ConvertedResultTextBlock.Text = "Proszę podać prawidłową kwotę w USD.";
            }
        }
    }
}
```

---

## Uruchomienie projektu

1. **Zbuduj rozwiązanie** (menu **Build** → **Build Solution**).
2. **Uruchom aplikację** (klawisz **F5** albo **Debug** → **Start Debugging**).
3. Główne okno (**MainWindow**) wyświetli dwa przyciski:
    - **BMI Calculator** – przejście do strony kalkulatora BMI.
    - **Currency Converter** – przejście do strony konwertera walut.

## Zrzuty ekranu 

Uruchomienie aplikacji.   

<img width="383" alt="image" src="https://github.com/user-attachments/assets/4da53088-b090-4f32-8c44-5383a4d191d0" />

Działanie kalkulatora BMI (wprowadzenie danych, wyświetlenie wyniku).   

<img width="381" alt="image" src="https://github.com/user-attachments/assets/aa78c3f3-5fd4-4288-8b35-21294332b4e6" />

Działanie konwertera walut (wprowadzenie danych, wyświetlenie wyniku).   

<img width="382" alt="image" src="https://github.com/user-attachments/assets/94795942-2adb-409d-b24e-a933d7823c97" />

(W tej sekcji należy wkleić odpowiednie zrzuty ekranu.)
---

## Podsumowanie i ocena

- **Kalkulator BMI** oblicza wartość wskaźnika masy ciała na podstawie wagi (kg) oraz wzrostu (m), a następnie wyświetla wynik wraz z przypisaniem do odpowiedniej kategorii (np. „wartość prawidłowa” czy „nadwaga”).
- **Konwerter walut** zamienia kwotę w USD na PLN przy stałym kursie 4,2 PLN za 1 USD.

Cała aplikacja opiera się na **nawigacji** pomiędzy różnymi **stronami** (`Page`) wewnątrz głównego okna **MainWindow**. Dzięki temu kod jest **modularny**, a widoki są **łatwe w utrzymaniu** i **dalszej rozbudowie**.

**Ocena**

**Funkcjonalność** Programy spełniają wymagania i prawidłowo realizują swoje zadania.

**Interfejs** Prostota i intuicyjność interfejsu sprawiają, że aplikacja jest łatwa w obsłudze.

**Obsługa błędów** Miękkie błędy wejścia są prawidłowo obsługiwane.

**Możliwości rozwoju** Dalsza rozbudowa aplikacji mogłaby uwzględniać dynamiczne pobieranie kursów walut z internetu czy dodatkowe opcje wizualizacji wyników BMI.

---

> **Uwaga**: Wszystkie powyższe przykłady stanowią materiał poglądowy i można je dowolnie modyfikować, np. zmieniać styl, dodawać powiązania danych (data bindings) czy rozszerzać funkcjonalność (np. pobieranie aktualnych kursów walut z API).

Wykonano przez: Bartosz Nowakowski, Wiktoria Parchańska
