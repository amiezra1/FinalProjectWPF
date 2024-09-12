using System.Windows;

namespace FinalProjectWPF.InventorySystem
{
    /// <summary>
    /// Interaction logic for InventorySystemApp.xaml
    /// </summary>
    public partial class InventorySystemApp : Window
    {
        public InventorySystemApp()
        {
            InitializeComponent();
            MainWindowViewModoel vm = new MainWindowViewModoel();
            DataContext = vm;
        }
    }
}
