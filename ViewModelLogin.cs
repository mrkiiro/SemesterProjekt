using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App8.Annotations;
using GalaSoft.MvvmLight.Command;

namespace App8
{
    class ViewModelLogin : INotifyPropertyChanged
    {
        private string _loginUserName, _loginPassword;
        private SessionManager mySession = SessionManager.GetManager();
        private readonly RelayCommand _loginCommand;

        public ViewModelLogin()
        {
            SessionManager sm = SessionManager.GetManager();
            _loginCommand = new RelayCommand(Login);
        }

        public void Login()
        {
            User thisUser = new User(LoginUserName, LoginPassword);
            if (SessionManager.Login(thisUser))
            {
                changeView();
            }

        }

        public void changeView()
        {
            Frame CurrFrame = (Frame)Window.Current.Content;

            switch (SessionManager.loggedInUser.AcessLevel)
            {
                case User.AcessLevels.Clerk:
                    CurrFrame.Navigate(typeof(ClerkView));
                    break;
                case User.AcessLevels.Admin:
                    CurrFrame.Navigate(typeof(AdminLogin));
                    break;
                default:
                    break;
            }
        }

        public string LoginUserName
        {
            get { return _loginUserName; }
            set
            {
                _loginUserName = value;
                OnPropertyChanged();
            }
        }

        public string LoginPassword
        {
            get { return _loginPassword; }
            set
            {
                _loginPassword = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LoginCommand
        {
            get { return _loginCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
