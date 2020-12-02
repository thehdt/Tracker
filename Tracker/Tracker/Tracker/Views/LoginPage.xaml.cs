using System;
using System.Windows;
using System.Windows.Controls;
using Tracker.ViewModels;
using Tracker.Interfaces;
using Tracker.Enumerations;

namespace Tracker.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page, INavigationPage
    {
        private readonly LoginViewModel VM;
        public event Action<int, int> SetWindowSize;
        public event Action<PageNames> MoveForward;
        public event Action MoveBackwards;

        public LoginPage()
        {
            InitializeComponent();
            VM = (LoginViewModel)this.Resources["ViewModel"];
        }

        private void loginClick_Handler(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Inside loginClick_Handler()");

            string username = usernameTxtBox.Text.Trim();
            string password = passwordTxtBox.Password.Trim();

            if (Equals(username, "hieu") && Equals(password, "hieu"))
            {
                SetWindowSize(800, 600);
                MoveForward(PageNames.FeaturesPage);
            }
            else
                MessageBox.Show("username and password is incorrect!");
        }

        private void username_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Inside username_TextChanged");

            VM.IsUsernameEmpty = usernameTxtBox.Text.Trim() == string.Empty;

            VM.IsLoginReady = !VM.IsUsernameEmpty && !VM.IsPasswordEmpty;
        }

        private void password_TextChanged(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Inside password_TextChanged");

            VM.IsPasswordEmpty = passwordTxtBox.Password.Trim() == string.Empty;

            VM.IsLoginReady = !VM.IsUsernameEmpty && !VM.IsPasswordEmpty;
        }
    }
}
