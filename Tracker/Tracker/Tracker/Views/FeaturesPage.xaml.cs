using System;
using System.Windows.Controls;
using Tracker.Interfaces;
using Tracker.Enumerations;

namespace Tracker.Views
{
    /// <summary>
    /// Interaction logic for FeaturesPage.xaml
    /// </summary>
    public partial class FeaturesPage : Page, INavigationPage
    {
        public event Action<int, int> SetWindowSize;
        public event Action<PageNames> MoveForward;
        public event Action MoveBackwards;

        public FeaturesPage()
        {
            InitializeComponent();
        }

    }
}
