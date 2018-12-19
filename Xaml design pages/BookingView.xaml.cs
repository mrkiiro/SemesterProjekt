using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class BookingView : Page
    {
        public BookingView()
        {
            this.InitializeComponent();

            // Calling our viewmodel to access methods etc...
            ViewModelBooking b = new ViewModelBooking();
            b.AddButtons();

            b.myButtons[1, 1].istaken = true;
            b.myButtons[1, 2].istaken = true;
            b.myButtons[1, 3].istaken = true;

            // New instance of the grid | Adding new grid to stackpanel
            b.MyGrid = new Grid();
            BookPanel.Children.Add(b.MyGrid);

            //
            b.ButtonArrayGrid();

            TicketCounter.Text = Convert.ToString(b.TicketCount);
        }
    }
}
