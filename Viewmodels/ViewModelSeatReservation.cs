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
    class ViewModelSeatReservation
    {
        private RelayCommand _changeViewBackToClerkView;

        public ViewModelSeatReservation()
        {
            _changeViewBackToClerkView = new RelayCommand(ChangeViewBackToClerkView);
        }
        public void ChangeViewBackToClerkView()
        {
            Frame CurrFrame = (Frame) Window.Current.Content;
            CurrFrame.Navigate(typeof(ClerkView));
        }
        public RelayCommand ChangeViewBackToClerkViewCommand
        {
            get { return _changeViewBackToClerkView; }
        }
    }
}
