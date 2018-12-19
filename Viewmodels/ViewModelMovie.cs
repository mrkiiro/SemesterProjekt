using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App8.Model;

namespace App8
{
    class ViewModelMovie 
    {

        private readonly RelayCommand _getMovies;
        private Movie movieToWorkOn;
        private Movie movieToWorkOn1;

        // oguz will try something awesome here
        private ObservableCollection<Movie> _movie = new ObservableCollection<Movie>();

        public ViewModelMovie()
        {
            // oguz er sej

            _movie.Add(new Movie("Fantastic Beasts", 1, DateTime.Now));
            _movie.Add(new Movie("The Avengers: Infinity War Part 2", 2, DateTime.Now));
            _movie.Add(new Movie("Ternet Ninja", 1, DateTime.Now));
            _movie.Add(new Movie("Lone Ranger", 3, DateTime.Now));

            // oguz er ikke længere sej
            movieToWorkOn = new Movie("Godfilm", 3, DateTime.Now);
            movieToWorkOn1 = new Movie("Wackfilm", 2, DateTime.Now);

            _getMovies = new RelayCommand(GetMovies);

            Title = movieToWorkOn.title;
            Room = movieToWorkOn.room;
            Date = movieToWorkOn.Time.Date.ToString("MM/dd/yyyy");
            Time = movieToWorkOn.Time.Hour.ToString();
        }

        public ObservableCollection<Movie> Movies
        {
            get { return _movie; }
            set { _movie = value; }
        }

        public String Title
        {
            get;

        }

        public int Room
        {
            get;

        }

        public string Date
        {
            get;

        }

        public string Time
        {
            get;

        }
        private async Task startDb()
        {
            await DBManager.initializeDatabase();
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
