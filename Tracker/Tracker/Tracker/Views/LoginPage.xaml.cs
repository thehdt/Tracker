using System;
using System.Windows;
using System.Windows.Controls;
using Tracker.ViewModels;
using Tracker.Interfaces;
using Tracker.Enumerations;
using System.Windows.Input;

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

            TextBox internalTxtBox = usernameTxtBox.Template.FindName("PART_EditableTextBox", usernameTxtBox) as TextBox;

            if (internalTxtBox != null)
            { 
                VM.IsUsernameEmpty = internalTxtBox.Text.Trim() == string.Empty;

                VM.IsLoginReady = !VM.IsUsernameEmpty && !VM.IsPasswordEmpty;
            }
        }

        private void password_TextChanged(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Inside password_TextChanged()");

            VM.IsPasswordEmpty = passwordTxtBox.Password.Trim() == string.Empty;

            VM.IsLoginReady = !VM.IsUsernameEmpty && !VM.IsPasswordEmpty;
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBox textBox = Keyboard.FocusedElement as TextBox;
            PasswordBox pwBox = Keyboard.FocusedElement as PasswordBox;
            TraversalRequest tRequest = new TraversalRequest(FocusNavigationDirection.Next);
            if (textBox != null)
            {
                textBox.MoveFocus(tRequest);
            }
            else if (pwBox != null)
            {
                pwBox.MoveFocus(tRequest);
            }

        }

        private void passwordTxtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Inside passwordTxtBox_LostFocus()");
            TextBlock textBlock = passwordTxtBox.Template.FindName("PasswordTextBlock", passwordTxtBox) as TextBlock;
            textBlock.Visibility = (VM.IsPasswordEmpty)? Visibility.Visible : Visibility.Collapsed;
        }

        private void passwordTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Inside passwordTxtBox_GotFocus()");
            TextBlock textBlock = passwordTxtBox.Template.FindName("PasswordTextBlock", passwordTxtBox) as TextBlock;
            textBlock.Visibility = Visibility.Collapsed;
        }
    }
}
