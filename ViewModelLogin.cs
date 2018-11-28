﻿using System;
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
            _loginCommand = new RelayCommand(Login);
        }

        public void Login()
        {
            User thisUser = new User(LoginUserName, LoginPassword);
            if (SessionManager.GetManager().Login(thisUser))
            {
                //to do, Kig på koden her under
                Frame CurrFrame = (Frame) Window.Current.Content;
                CurrFrame.Navigate(typeof(ClerkView));
                changeView();
            }

        }

        public void changeView()
        {
            Frame CurrFrame = (Frame)Window.Current.Content;
            Debug.WriteLine("i tried to do things.. logged in as a: " +
                            SessionManager.GetManager().loggedInUser.AcessLevel);

            switch (SessionManager.GetManager().loggedInUser.AcessLevel)
            {
                case User.AcessLevels.Clerk:
                    CurrFrame.Navigate(typeof(Booking));
                    break;
                case User.AcessLevels.Admin:
                    CurrFrame.Navigate(typeof(Booking));
                    break;
                default:
                    CurrFrame.Navigate(typeof(Booking));
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
