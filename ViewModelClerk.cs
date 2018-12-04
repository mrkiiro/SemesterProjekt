using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    class ViewModelClerk : Page, INotifyPropertyChanged
    {
        private List<User> _customerList;
        public ViewModelClerk()
        {
            _logOut = new RelayCommand(LogOut);
            _showCustomerInformation = new RelayCommand(ShowCustomerInformation);

            _customerList = DBManager.getManager().GetUsers();
            List<User> customer = new List<User>();
            foreach (User thisUser in _customerList)
            {
                if (thisUser.AcessLevel == User.AcessLevels.Customer)
                {
                    customer.Add(thisUser);
                }
            }
            _customerList = customer;
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
        //private string _userName;
        public void Search()
        {

        }

        public RelayCommand ShowCustomerInformationCommand
        {
            get { return _showCustomerInformation; }
        }

        /*public string UserName
        {
            get { return _userName; }
        }*/

        public List<User> CustomerList
        {
            get { return _customerList; }
        }

        public void ShowCustomerInformation()
        {
            DBManager.getManager().GetUsers();
            Debug.WriteLine("We are ready to Implement Search funktion!!");
        }

        #endregion

        public void list<SelectCustomers>()
        {

        }
        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
