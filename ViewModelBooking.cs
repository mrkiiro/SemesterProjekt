using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using App8.Model;

namespace App8
{
    class ViewModelBooking
    {
        private Sal minSAL;
        private static int salRow = 5;
        private ObservableCollection<Sal> _salListe;
        private int salSeats = 10;
        public Button[,] btnArray;
        private Button btn;
        private string[,] gridArray;
        private bool _available;
        private Grid _viewGrid;

        public ViewModelBooking()
        {
            _viewGrid = new Grid();;
            gridArray = new string[salRow, salSeats];
            btnArray = new Button[salRow, salSeats];

            _salListe = new ObservableCollection<Sal>();
            _salListe.Add(new Sal(10, 20, "Sal 1"));
            _salListe.Add(new Sal(5, 10, "Sal 2"));


            for (int i = 0; i < salRow; i++)
            {
                for (int j = 0; j < salSeats; j++)
                {

                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(30, GridUnitType.Pixel);
                    _viewGrid.RowDefinitions.Add(rd);

                    ColumnDefinition cd = new ColumnDefinition();
                    cd.Width = new GridLength(30, GridUnitType.Pixel);
                    _viewGrid.ColumnDefinitions.Add(cd);
                }
            }
            VisGrid();
        }

        public void VisGrid()
        {
            for (int i = 0; i < salRow; i++)
            {
                for (int j = 0; j < salSeats; j++)
                {
                    //add ´new seat(i, j);

                    btn = new Button();
                    btn.Click += gridClicked(i, j);
                    btn.Content = "";
                    btnArray[i, j] = btn;
                    _viewGrid.Children.Add(btn);
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    btn.Background = new SolidColorBrush(Colors.DarkGreen);
                }
            }
        }
        public Boolean PickSeat(int row, int seat)
        {
            return true;
        }
        private RoutedEventHandler gridClicked(int i, int j)
        {

            return (btn, e) => btnArray[i, j].Background = new SolidColorBrush(Colors.Yellow);

        }
    }
}
