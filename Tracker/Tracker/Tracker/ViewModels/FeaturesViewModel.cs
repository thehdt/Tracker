using System.Collections.ObjectModel;
using Tracker.Models;

namespace Tracker.ViewModels
{
    public class FeaturesViewModel : ViewModelBase
    {
        private ObservableCollection<Project> _Projects = null;
        public ObservableCollection<Project> Projects
        {
            get 
            {
                return _Projects;
            }
            set
            {
                _Projects = value;
                RaisePropertyChanged("Projects");
            }
        }

        private bool _IsCreatingProject = false;
        public bool IsCreatingProject
        {
            get
            {
                return _IsCreatingProject;
            }
            set
            {
                _IsCreatingProject = value;
                RaisePropertyChanged("IsCreatingProject");
            }
        }

        private bool _IsProjectNameEmpty = false;
        public bool IsProjectNameEmpty
        {
            get
            {
                return _IsProjectNameEmpty;
            }
            set
            {
                _IsProjectNameEmpty = value;
                RaisePropertyChanged("IsProjectNameEmpty");
            }
        }

        public string ProjectName { get; set; }
    }
}
