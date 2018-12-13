using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using App8.Annotations;
using App8.Model;

namespace App8
{
    class ViewModelBooking : INotifyPropertyChanged
    {
        private Sal minSAL;
        private ObservableCollection<Sal> _salListe;
        private static int salRow = 5;
        private int salSeats = 10;
        public Button[,] btnArray;
        private string[,] gridArray;
        private bool _available = false;
        private TextBlock myBlock;
        private Sal salen;
        private Sal mySal;
        private Grid _myGrid;
        public ButtonExtension[,] myButtons;
        public ButtonExtension button;
        private int ticketPrice = 110;
        private int ticketCount = 0;



        public Grid MyGrid
        {
            get { return _myGrid; }
            set { _myGrid = value; }
        }

        public TextBlock MyBlock
        {
            get { return myBlock; }
            set { myBlock = value; }
        }

        public int TicketCount
        {
            get { return ticketCount; }
            set
            {
                ticketCount = value;
                OnPropertyChanged(Convert.ToString(TicketCount));
            }
        }

        public ViewModelBooking()
        {
            AddButtons();
            MyGrid = new Grid();
            ButtonArrayGrid();
            myButtons[1, 1].istaken = true;
            myButtons[1, 2].istaken = true;
            myButtons[1, 3].istaken = true;
        }

        public void AddButtons()
        {
            myButtons = new ButtonExtension[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    button = new ButtonExtension();
                    button.Click += gridClicked(i, j);
                    myButtons[i, j] = button;
                }
            }
        }

        public void ButtonArrayGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // Styling grid with rows and columns and width
                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(50, GridUnitType.Pixel);
                    _myGrid.RowDefinitions.Add(rd);

                    ColumnDefinition cd = new ColumnDefinition();
                    cd.Width = new GridLength(50, GridUnitType.Pixel);
                    _myGrid.ColumnDefinitions.Add(cd);
                    
                    // Setting rows and columns for button arrays
                    Grid.SetRow(myButtons[i, j], i);
                    Grid.SetColumn(myButtons[i, j], j);

                    // Adding button array into our grid
                    _myGrid.Children.Add(myButtons[i, j]);

                    // Bool value to check if a button is true/false
                    if (myButtons[i, j].istaken)
                    {
                        // Change color if its taken to red, disabling the button
                        App.Current.Resources["SystemControlBackgroundBaseLowBrush"] = new SolidColorBrush(Colors.DarkRed);
                        App.Current.Resources["SystemControlBackgroundBaseLowBrush"] = new SolidColorBrush(Colors.Yellow); // background
                        App.Current.Resources["SystemControlDisabledBaseMediumLowBrush"] = new SolidColorBrush(Colors.Red); // content
                        App.Current.Resources["SystemControlDisabledTransparentBrush"] = new SolidColorBrush(Colors.Green); // border
                        myButtons[i, j].IsEnabled = false;

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
                    ticketCount++;
                }
                else
                {
                    myButtons[i, j].Background = new SolidColorBrush(Colors.DarkGreen);
                    ticketCount--;
                }

                Debug.WriteLine(ticketCount);
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
