using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using App8.Annotations;
using App8.Model;

namespace App8.Viewmodels
{
    class ViewModelCustomer : INotifyPropertyChanged
    {
        private GridView _myGrid;

        public GridView MyGrid {
            get { return _myGrid; }
            set
            {
                _myGrid = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCustomer()
        {
            GridView mg = new GridView();

            mg.Background = new SolidColorBrush(Colors.Green);
            //Sal mySal = new Sal(20,20);

            /*
            for (int x = 0; x < mySal.Cols; x++)
            {
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int y = 0; y < mySal.Rows; y++)
            {
                MyGrid.RowDefinitions.Add(new RowDefinition());
            }

            Debug.WriteLine(MyGrid.RowDefinitions.Count);
            
            for (int x = 0; x < mySal.Cols; x++)
            {
                for (int y = 0; y < mySal.Rows; y++)
                {
                    Button myBtn = new Button();
                    myBtn.Content = "someString";

                    Debug.WriteLine(MyGrid.Children.Count);
                    MyGrid.Children.Add(myBtn);
                }
            }
            MyGrid.Background = new SolidColorBrush(Colors.DarkBlue);
            */
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
