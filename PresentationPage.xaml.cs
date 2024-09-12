using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace FinalProjectWPF
{
    public partial class PresentationPage : Page
    {
        public PresentationPage()
        {
            InitializeComponent();
        }

        private Window currentProject;
        public void OnStart(string title, string ProjectDescription, ImageSource imageSource, Window project, string contentOpenProject = "Open Project")
        {
            DescriptionTitle.Text = $"Abour {title}";
            TitleLabel.Content = title;
            ProjectText.Text = ProjectDescription;
            ProjectImage.Source = imageSource;
            currentProject = project;
            OpenProject.Content = contentOpenProject;
        }
        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.7;

        }
        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            currentProject.Show();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void UserAvatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContactInfoWindow contactInfoWindow = new ContactInfoWindow();
            contactInfoWindow.Show();
        }
    }
}
