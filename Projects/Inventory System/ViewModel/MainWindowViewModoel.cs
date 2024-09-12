
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;
using System.Windows;

namespace FinalProjectWPF.InventorySystem
{
    internal class MainWindowViewModoel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());

        public MainWindowViewModoel() {
            Items = new ObservableCollection<Item>();
            LoadItems();
        }
        private string FilePath = "Products.json";
        private Item selectedItem;
        public Item SelectedItem
        {
            get { return selectedItem; }
            set 
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        private void AddItem()
        {
            Items.Add(new Item
            {
                Name = "NEW ITEM",
                SerialNumber= "XXXX",
                Quantity = 0,
                Comments = "",
            });
        }

        private void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }
        private void Save()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(Items);
                File.WriteAllText(FilePath, jsonString);
                MessageBox.Show("The data was saved successfully!", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool CanSave() { 
            return Items.Count > 0;
        }
        private void LoadItems()  
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string jsonString = File.ReadAllText(FilePath);  
                    List<Item> loadedItems = JsonSerializer.Deserialize<List<Item>>(jsonString);

                    if (loadedItems != null)
                    {
                        foreach (var item in loadedItems)
                        {
                            Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שError loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
