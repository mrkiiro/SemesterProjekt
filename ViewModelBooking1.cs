using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    class ViewModelBooking1
    {
        private Sal mySal;
        private const int salRow = 5;
        private ObservableCollection<Sal> _salListe;
        private const int salSeats = 10;
        public Button[,] btnArray;
        private string[,] gridArray;
        private bool _available;
        private TextBlock myBlock;
        private Grid _viewGrid;
        public Grid ViewGrid
        {
            get { return _viewGrid; }
            set { _viewGrid = value; }
        }

        public TextBlock MyBlock
        {
            get { return myBlock; }
            set { myBlock = value; }
        }

        public ViewModelBooking1()
        {
            gridArray = new string[salRow, salSeats];
            btnArray = new Button[salRow, salSeats];
            MyBlock.Text = " ++++ This is from codebehind!";
            _salListe = new ObservableCollection<Sal>();
            _salListe.Add(new Sal(10, 20, "Sal 1"));
            _salListe.Add(new Sal(5, 10, "Sal 2"));

        }
        public void VisGrid()
        {
            for (int i = 0; i < salRow; i++)
            {
                for (int j = 0; j < salSeats; j++)
                {
                    //add ´new seat(i, j);

                    Button btn = new Button();
                    btn.Click += gridClicked(i, j);
                    btn.Content = gridArray[i,j];
                    btnArray[i, j] = btn;
                    _viewGrid.Children.Add(btn);
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    btn.Background = new SolidColorBrush(Colors.DarkGreen);

                    RowDefinition rd = new RowDefinition();
                    rd.Height = new GridLength(30, GridUnitType.Pixel);
                    ViewGrid.RowDefinitions.Add(rd);

                    ColumnDefinition cd = new ColumnDefinition();
                    cd.Width = new GridLength(30, GridUnitType.Pixel);
                    ViewGrid.ColumnDefinitions.Add(cd);
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
