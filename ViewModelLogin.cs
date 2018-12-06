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
        private readonly RelayCommand _loginCommand, _registerCustomerCommand;
        private string message;

        private string _regUName, _regPWord, _regPhone, _regEmail;


        public ViewModelLogin()
        {
            _loginCommand = new RelayCommand(Login);
            _registerCustomerCommand = new RelayCommand(Register);
            Message = "";
            startDb();
        }

        public async void Register()
        {
            List<Customer> customers = await DBManager.getManager().loadCustomers();

            bool isUnameTaken = false;
            foreach (var thisCustomer in customers)
            {
                if (thisCustomer.UserName == RegUName)
                {
                    isUnameTaken = true;
                    break;
                }
            }

            if (!isUnameTaken && RegUName != "")
            {
                await DBManager.getManager().addCustomer(
                    new Customer(RegUName, RegPWord)
                    );
            }
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

        public string RegUName
        {
            get { return _regUName; }
            set
            {
                _regUName = value;
                OnPropertyChanged();
            }
        }

        public string RegPWord
        {
            get { return _regPWord; }
            set
            {
                _regPWord = value;
                OnPropertyChanged();
            }
        }

        public string RegPhone
        {
            get { return _regPhone; }
            set
            {
                _regPhone = value;
                OnPropertyChanged();
            }
        }

        public string RegEmail
        {
            get { return _regEmail; }
            set
            {
                _regEmail = value; 
                OnPropertyChanged();
            }
        }

        public RelayCommand RegisterCustomerCommand
        {
            get { return _registerCustomerCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
