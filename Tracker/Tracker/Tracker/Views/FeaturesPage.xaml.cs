﻿using System;
using System.Windows.Controls;
using Tracker.Interfaces;
using Tracker.Enumerations;
using Tracker.ViewModels;
using System.Windows.Input;
using Tracker.Models;
using System.Collections.ObjectModel;

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

        private FeaturesViewModel VM;

        public FeaturesPage()
        {
            InitializeComponent();
            VM = (FeaturesViewModel)this.Resources["ViewModel"];
        }

        //Will need to do a loading of bugs/tasks for projects
        // Populate list of projects

        private void FeaturesPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            VM.Projects = new ObservableCollection<Project>();
        }
        
        private void newProjectDisplay_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            VM.IsCreatingProject = true;
        }

        private void projectCreateGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBox textBox = Keyboard.FocusedElement as TextBox;
            TraversalRequest tRequest = new TraversalRequest(FocusNavigationDirection.Next);
            if (textBox != null)
            {
                textBox.MoveFocus(tRequest);
            }
        }

        private void createProject_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            VM.Projects.Add(new Project { Name = VM.ProjectName, ID = new Guid().ToString()});

            VM.IsCreatingProject = false;
            VM.IsProjectNameEmpty = false;
            VM.ProjectName = string.Empty;
        }

        private void projectName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = projectTxtBox.Template.FindName("PART_EditableTextBox", projectTxtBox) as TextBox;

            if (textBox != null)
            {
                VM.IsProjectNameEmpty = textBox.Text.Trim() != string.Empty;
                VM.ProjectName = textBox.Text.Trim();
            }
        }

        private void exitProjectDisplay_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            VM.IsCreatingProject = false;
            VM.IsProjectNameEmpty = false;
            VM.ProjectName = string.Empty;
        }
    }
}
