using System;
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
using TrackerModels;

namespace Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void testClick_Handler(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Hello");
            Bug bug = new Bug
            {
                ID = "1234",
                Title = "RandomTitle",
                Description = "Random Description",
                Severity = 5,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            System.Diagnostics.Debug.WriteLine($"ID: {bug.ID} - Title: {bug.Title} - Description: {bug.Description} - Severity: {bug.Severity} - " +
                $"CreateDate: {bug.CreateDate} - ModifiedDate: {bug.ModifiedDate}");
        }
    }
}
