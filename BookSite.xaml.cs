using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BookSite : Page
    {
        public BookSite()
        {
            this.InitializeComponent();

            ViewModelBooking b = new ViewModelBooking();
            b.AddButtons();

            b.myButtons[1, 1].istaken = true;
            b.myButtons[1, 2].istaken = true;
            b.myButtons[1, 3].istaken = true;

            b.MyGrid = new Grid();
            GridView.Children.Add(b.MyGrid);

            b.ButtonArrayGrid();
            
            

        }
    }
}
