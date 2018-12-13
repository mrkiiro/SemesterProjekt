using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using App8.Annotations;
using App8.Model;

namespace App8
{
    class ViewModelBooking : INotifyPropertyChanged
    {
        private Room myRoom;
        public Grid myGrid;
        public ButtonExtension[,] myButtons;
        private ButtonExtension button;
        private int _ticketCount = 0;
        private int _ticketPrice = 110;
        private TextBlock _tb;
        public Grid MyGrid
        {
            get { return myGrid; }
            set { myGrid = value; }
        }
        public int TicketCount
        {
            get { return _ticketCount; }
            set
            {
                _ticketCount = value;
                OnPropertyChanged();
            }
        }
        public TextBlock Tb
        {
            get { return _tb; }
            set { _tb = value; }
        }
        public ViewModelBooking()
        {
            // Creating room size | Adding room soze to button array
            myRoom = new Room(8, 16);
            myButtons = new ButtonExtension[myRoom.Rows, myRoom.Columns];
        }
        public void AddButtons()
        {
            for (int i = 0; i < myRoom.Rows; i++)
            {
                for (int j = 0; j < myRoom.Columns; j++)
                {
                    button = new ButtonExtension();
                    button.Click += gridClicked(i, j);
                    myButtons[i, j] = button;
                }
            }
        }
        public void ButtonArrayGrid()
        {
            myRoom = new Room(8, 16);
            for (int i = 0; i < myRoom.Rows; i++)
            {
                for (int j = 0; j < myRoom.Columns; j++)
                {
                    // Styling grid with rows and columns and width
                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(50, GridUnitType.Pixel);
                    myGrid.RowDefinitions.Add(rd);
                    ColumnDefinition cd = new ColumnDefinition();
                    cd.Width = new GridLength(50, GridUnitType.Pixel);
                    myGrid.ColumnDefinitions.Add(cd);
                    myButtons[i, j].Background = new SolidColorBrush(Colors.DarkGreen);
                    // Setting rows and columns for button arrays
                    Grid.SetRow(myButtons[i, j], i);
                    Grid.SetColumn(myButtons[i, j], j);
                    // Adding button array into our grid
                    myGrid.Children.Add(myButtons[i, j]);
                    // Bool value to check if a button is true/false
                    if (myButtons[i, j].istaken)
                    {
                        // Change color if its taken to red, disabling the button
                        myButtons[i, j].IsEnabled = false;
                        App.Current.Resources["SystemControlBackgroundBaseLowBrush"] = new SolidColorBrush(Colors.DarkRed);
                    }
                    else
                    {
                        myButtons[i, j].Background = new SolidColorBrush(Colors.DarkGreen);
                        App.Current.Resources["ButtonBackgroundPointerOver"] = new SolidColorBrush(Colors.YellowGreen);
                    }
                }
            }
        }
        private RoutedEventHandler gridClicked(int i, int j)
        {
            return (btn, e) =>
            {
                myButtons[i, j].istaken = !myButtons[i, j].istaken;
                if (myButtons[i, j].istaken)
                {
                    myButtons[i, j].Background = new SolidColorBrush(Colors.Yellow);
                    TicketCount++;
                }
                else
                {
                    myButtons[i, j].Background = new SolidColorBrush(Colors.DarkGreen);
                    TicketCount--;
                }
                Debug.WriteLine(TicketCount);
                // Debug.WriteLine("The button at row: "+(i+1)+", col"+(j+1)+" IsTaken = "+myButtons[i,j].istaken);
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
