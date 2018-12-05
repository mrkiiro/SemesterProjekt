using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;

namespace App8
{
    class ViewModelCustomer
    {
        public ViewModelCustomer()
        {
            _logOut = new RelayCommand(LogOut);
        }
        private readonly RelayCommand _logOut;
        public RelayCommand LogOutCommand
        {
            get { return _logOut; }
        }

        public void LogOut()
        {
            SessionManager.GetManager().loggedInUser = null;
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(MainPage));
        }
    }
}
