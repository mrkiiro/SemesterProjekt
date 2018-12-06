using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using App8.Annotations;
using App8.Model;

namespace App8
{
    class ViewModelAdmin : INotifyPropertyChanged
    {
        private readonly RelayCommand _logOut;
        private readonly RelayCommand _getMovies;
        private string _searchbar;
        private readonly RelayCommand _next;
        private ObservableCollection<Movie> _Film;
        private ObservableCollection<Movie> DBMovies;

        private ObservableCollection<Customer> _customers;

        public ViewModelAdmin()
        {
            _logOut = new RelayCommand(LogOut);
            _getMovies = new RelayCommand(GetMovies);
            _next = new RelayCommand(Next);

            _loadMovies();
            _Film = new ObservableCollection<Movie>();
        }

        private async Task _loadMovies()
        {
            List<Movie> myMovies = await DBManager.getManager().GetMovies();
            DBMovies = new ObservableCollection<Movie>();
            foreach (var loadedMovie in myMovies)
            {
                DBMovies.Add(loadedMovie);
            }
            _Film = DBMovies;
            OnPropertyChanged("Film");
        }

        public RelayCommand LogOutCommand
        {
            get
            {
                return _logOut;
            }
        }

        public void LogOut()
        {
            SessionManager.Logout();
        }

        public void Next()
        {
            Debug.WriteLine("Jeg kører next");
            SessionManager.loggedInUser = null;
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(MovieView));
        }

        private void updateSearchList()
        {
            ObservableCollection<Movie> SortedList = new ObservableCollection<Movie>();

            for (int i = 0; i < Searchbar.Length; i++)
            {
                foreach (var movie in DBMovies)
                {
                    if (Searchbar.Length <= movie.title.Length)
                    {
                        if (movie.title[i] == Searchbar[i] && !SortedList.Contains(movie))
                        {
                                SortedList.Add(movie);
                        }
                    }
                }
            }

            Film = SortedList;
                if (Searchbar == string.Empty)
                {
                    Film = DBMovies;
                }
            }

        public RelayCommand NextCommand
        {
            get { return _next; }
        }

        public RelayCommand GetMoviesCommand
        {
            get { return _getMovies; }
        }

        public string Searchbar
        {
            get { return _searchbar; }
            set
            {
                _searchbar = value;
                updateSearchList();
            }
        }

        public ObservableCollection<Movie> Film
        {
            get { return _Film; }
            set
            {
                _Film = value;
                OnPropertyChanged();
            }
        }

        public void GetMovies()
        {
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(MovieView));
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
