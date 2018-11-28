using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;

namespace App8
{
    class ViewModelClerk
    {
        private readonly RelayCommand _logOut;
        public ViewModelClerk()
        {
            _logOut = new RelayCommand(LogOut);
        }

        public RelayCommand LogOutCommand
        {
            get { return _logOut; }
        }

        public void LogOut()
        {
            SessionManager.GetManager().loggedInUser = null;
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(MainPage));

            //sæt Logged In User i Session manager til null
            //skift side til login siden
            //Debug.WriteLine("We are ready to Implement LOGOUT!!");
        }
        
    }
}
