using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App8
{
    class ViewModelCheckOut
    {
        public ViewModelCheckOut()
        {
            
        }
        public static void ChangeView()
        { 
        Frame CurrFrame = (Frame)Window.Current.Content;
        CurrFrame.Navigate(typeof(CheckOutView));
        }

    }
}
