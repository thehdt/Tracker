﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tracker.Models;
using Tracker.DatabaseUtilites;
using Tracker.Enumerations;
using Tracker.ViewModels;
using Tracker.Utilities;

namespace Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel VM;
        public LoginWindow()
        {
            InitializeComponent();
            VM = (LoginViewModel)this.Resources["ViewModel"];
            this.Title = GlobalAppData.RM.GetString("app_name");
        }

        private void loginClick_Handler(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Inside loginClick_Handler()");

            string username = usernameTxtBox.Text.Trim();
            string password = passwordTxtBox.Password.Trim();

            if (Equals(username, "hieu") && Equals(password, "hieu"))
                MessageBox.Show("username and password is correct!");
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
