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
        private Grid _myGrid;

        public Grid MyGrid {
            get { return _myGrid; }
            set
            {
                _myGrid = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCustomer()
        {

            Sal mySal = new Sal(20,20);
            MyGrid = new Grid();

            
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
                    myBtn.Width = 200;
                    myBtn.Height = 100;

                    Debug.WriteLine(MyGrid.Children.Count);
                    MyGrid.Children.Add(myBtn);
                }
            }

            MyGrid.Height = 800;
            MyGrid.Width = 800;
            MyGrid.Background = new SolidColorBrush(Colors.DarkBlue);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
