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
    class ViewModelMainPage
    {
        private readonly RelayCommand _changeViewToLoginView;
        public ViewModelMainPage()
        {
            RelayCommand _changeViewToLoginView = new RelayCommand(ChangeViewToLoginView);
            
        }

        public void ChangeViewToLoginView()
        {
            Debug.WriteLine("metoden kører");
            Frame curr = (Frame) Window.Current.Content;
            curr.Navigate(typeof(LoginView));
        }

        public RelayCommand ChangeViewToLoginViewCommand
        {
            get { return _changeViewToLoginView; }
        }
    }
}
