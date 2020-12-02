using System.Windows;
using Tracker.Views;
using Tracker.Enumerations;
using Tracker.Interfaces;

namespace Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TrackrWindow : Window
    {
        public TrackrWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            login.SetWindowSize += mainFrame_SetWindowSize;
            login.MoveForward += mainFrame_MoveForward;
            mainFrame.Navigate(login);
        }

        private void mainFrame_SetWindowSize(int width, int height)
        {
            System.Diagnostics.Debug.WriteLine($"Inside mainFrame_SetWindowSize - Width: {width}  Height: {height}");

            this.Width = width;
            this.Height = height;
        }

        private void mainFrame_MoveForward(PageNames name)
        {
            System.Diagnostics.Debug.WriteLine($"Inside mainFrame_MoveForward - Page Name: {name.ToString()}");

            object page = null;
            switch (name)
            {
                case PageNames.FeaturesPage:
                    page = new FeaturesPage();
                    break;

                default:
                    page = null;
                    break;
            }

            if (page != null)
            {
                (page as INavigationPage).SetWindowSize += mainFrame_SetWindowSize;
                (page as INavigationPage).MoveForward += mainFrame_MoveForward;
                mainFrame.Navigate(page);
            }
        }
    }
}
