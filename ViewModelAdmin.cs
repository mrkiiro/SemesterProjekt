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
       
        public ViewModelAdmin()
        {
            _logOut = new RelayCommand(LogOut);
            
            _getMovies = new RelayCommand(GetMovies);

            _next = new RelayCommand(Next);
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
            Debug.WriteLine("Jeg kører log ud");
            SessionManager.GetManager().LoggedInUser = null;
            Frame CurrFrame = (Frame) Window.Current.Content;
            CurrFrame.Navigate(typeof(MainPage));

        }

        public void Next()
        {
            Debug.WriteLine("Jeg kører next");
            SessionManager.GetManager().LoggedInUser = null;
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(MovieView));
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
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Movie> Film
        {
            get { return _Film; }
            set { _Film = value; }
        }

        public void GetMovies()
        {
            Debug.WriteLine("Jeg kører get movies");
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(MovieView));

        }

        private ObservableCollection<Movie> _Film = DBManager.getManager().GetMovies();



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
