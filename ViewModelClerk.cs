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
        //Customer tt = new Customer("username", "password");
        //Customer cc = new Customer("username", "password");

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
            //_userName = DBManager.getManager().GetUsers(); //SessionManager.GetManager().loggedInUser.UserName;
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
        private string _userName;
        public void Search()
        {

        }

        public RelayCommand ShowCustomerInformationCommand
        {
            get { return _showCustomerInformation; }
        }

        public string UserName
        {
            get { return _userName; }
        }

        public List<User> CustomerList
        {
            get { return _customerList; }
        }

        public List<Customer> SelectCustomers
        {
            get { return _selectCustomers; }
        }

        public void ShowCustomerInformation()
        {
            DBManager.getManager().GetUsers();
            Debug.WriteLine("We are ready to Implement Search funktion!!");
        }

        #endregion

        private List<Customer> _selectCustomers;

        public void list<SelectCustomers>()
        {

        }
        private ObservableCollection<ComboBoxItem> ComboBoxOptions;

        private string _comboBoxOption;
        private string _comboBoxHumanReadableOption;
        private ComboBoxItem _selectedComboBoxOption;
        public class ComboBoxItem
        {
            public string ComboBoxOption { get; set; }
            public string ComboBoxHumanReadableOption { get; set; }
        }

        /*public class ComboBoxOptionsManager
        {

            public static void GetComboBoxList(ObservableCollection<ComboBoxItem> ComboBoxItems)
            {
                var allItems = getComboBoxItems();
                ComboBoxItems.Clear();
                allItems.ForEach(p => ComboBoxItems.Add(p));
            }

            private static List<ComboBoxItem> getComboBoxItems()
            {
                var items = new List<ComboBoxItem>();

                items.Add(new ComboBoxItem() {ComboBoxOption = "Option1", ComboBoxHumanReadableOption = "Option 1"});
                items.Add(new ComboBoxItem() {ComboBoxOption = "Option2", ComboBoxHumanReadableOption = "Option 2"});
                items.Add(new ComboBoxItem() {ComboBoxOption = "Option3", ComboBoxHumanReadableOption = "Option 3"});

                return items;
            }
        }*/
        string _SelectedComboBoxOption = "Option1";
        public ComboBoxItem SelectedComboBoxOption
        {
            get
            {
                return _selectedComboBoxOption;
            }
            set
            {
                if (_selectedComboBoxOption != value)
                {
                    _selectedComboBoxOption = value;
                    RaisePropertyChanged("SelectedComboBoxOption");

                }
            }
        }
        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public string ComboBoxOption
        {
            get { return _comboBoxOption; }
            set { _comboBoxOption = value; }
        }

        public string ComboBoxHumanReadableOption
        {
            get { return _comboBoxHumanReadableOption; }
            set { _comboBoxHumanReadableOption = value; }
        }
    }
}
