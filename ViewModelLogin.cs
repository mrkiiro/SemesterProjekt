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
using App8.Model;
using GalaSoft.MvvmLight.Command;

namespace App8
{
    class ViewModelLogin : INotifyPropertyChanged
    {
        private string _loginUserName, _loginPassword;
        private readonly RelayCommand _loginCommand;
        private string message;


        public ViewModelLogin()
        {
            _loginCommand = new RelayCommand(Login);
            Message = "";
            startDb();
        }

        private async Task startDb()
        {
            await DBManager.initializeDatabase();
        }

        public async void Login()
        {
            User thisUser = new User(LoginUserName, LoginPassword);
            if (await SessionManager.GetManager().Login(thisUser))
            {
                changeView();
            }
            //viser fejl i enten username eller password
            if( await DBManager.getManager().getUserByName(LoginUserName) != null)
                Message = "Fejl i password";
            else
            {
                Message = "Fejl i brugernavn";
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
                case User.AcessLevels.Customer:
                    CurrFrame.Navigate(typeof(CustomerView));
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

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
