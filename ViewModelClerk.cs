using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App8.Model;
using GalaSoft.MvvmLight.Command;

namespace App8
{
    class ViewModelClerk
    {

        public ViewModelClerk()
        {
            _logOut = new RelayCommand(LogOut);
            _showCustomerInformation = new RelayCommand(ShowCustomerInformation);
        }

        #region Log out

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

            //sæt Logged In User i Session manager til null
            //skift side til login siden
            //Debug.WriteLine("We are ready to Implement LOGOUT!!");
        }

        #endregion

        #region Show customer information

        private readonly RelayCommand _showCustomerInformation;

        public RelayCommand ShowCustomerInformationCommand
        {
            get { return _showCustomerInformation; }
        }

        public void ShowCustomerInformation()
        {
            DBManager.getManager().GetUsers();
            Debug.WriteLine("We are ready to Implement LOGOUT!!");
        }

        #endregion


    }
}
