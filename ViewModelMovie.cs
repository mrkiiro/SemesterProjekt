using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App8
{
    class ViewModelMovie
    {

        private readonly RelayCommand _getMovies;

        public ViewModelMovie()
        {
            _getMovies = new RelayCommand(GetMovies);
        }

        public RelayCommand GetMoviesCommand
        {
            get { return _getMovies; }
        }

        public void GetMovies()
        {
            Debug.WriteLine("Jeg kører get movies");
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(MovieView));

        }

    }
}
