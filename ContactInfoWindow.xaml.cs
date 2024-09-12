using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace FinalProjectWPF
{
    /// <summary>
    /// Interaction logic for ContactInfoWindow.xaml
    /// </summary>
    public partial class ContactInfoWindow : Window
    {
        public ContactInfoWindow()
        {
            InitializeComponent();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.ToString(),
                UseShellExecute = true
            });
        }

    }
}
