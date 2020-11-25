using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private bool _IsLoginReady = false;
        public bool IsLoginReady
        { 
            get
            {
                return _IsLoginReady;
            }
            set
            {
                _IsLoginReady = value;
                RaisePropertyChanged("IsLoginReady");
            }
        }

        private bool _IsUsernameEmpty = true;
        public bool IsUsernameEmpty 
        {
            get
            {
                return _IsUsernameEmpty;
            }
            set
            {
                _IsUsernameEmpty = value;
                RaisePropertyChanged("IsUsernameEmpty");
            }
        }

        private bool _IsPasswordEmpty = true;
        public bool IsPasswordEmpty 
        { 
            get
            {
                return _IsPasswordEmpty;
            }
            set
            {
                _IsPasswordEmpty = value;
                RaisePropertyChanged("IsPasswordEmpty");
            }
        }
    }
}
