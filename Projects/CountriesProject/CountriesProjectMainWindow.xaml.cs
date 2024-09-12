using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace FinalProjectWPF.CountriesProject
{
    /// <summary>
    /// Interaction logic for CountriesProjectMainWindow.xaml
    /// </summary>
    public partial class CountriesProjectMainWindow : Window
    {
        public ObservableCollection<Country> Countries { get; set; } = new ObservableCollection<Country>();
        private ObservableCollection<Country> _allCountries = new ObservableCollection<Country>();

        public static HttpClient client = new HttpClient();
        public CountriesProjectMainWindow()
        {
            InitializeComponent();
            LoadCountriesDataAsync();
        }
        private async Task LoadCountriesDataAsync()
        {
            string json = await client.GetStringAsync("https://restcountries.com/v3.1/all");

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Countries = JsonSerializer.Deserialize<ObservableCollection<Country>>(json, options);

            foreach (Country c in Countries)
            {
                _allCountries.Add(c);
            }
            CountriesDataGrid.ItemsSource = Countries;

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            List<Country> filteredCountries = _allCountries
                .Where(c => c.Name.Common.ToLower().Contains(searchText))
                .ToList();

            UpdateCountriesCollection(filteredCountries);
        }

        private void RegionFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRegion = (RegionFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedRegion == "All Regions")
            {
                UpdateCountriesCollection(_allCountries.ToList());
            }
            else
            {
                List<Country> filteredCountries = _allCountries
                    .Where(c => c.Region.ToLower() == selectedRegion.ToLower())
                    .ToList();

                UpdateCountriesCollection(filteredCountries);
            }
        }

        private void UpdateCountriesCollection(List<Country> countries)
        {
            Countries.Clear();
            foreach (Country country in countries)
            {
                Countries.Add(country);
            }
        }
    }
}
