using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace App8.Model
{
    class DBManager
    {
        private static DBManager _dbManager;

        private DBManager()
        {
        }

        public static DBManager getManager()
        {
            if (_dbManager == null)
            {
                _dbManager = new DBManager();
            }
            return _dbManager; ;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new Admin("Admin", "Admin"));
            users.Add(new Clerk("Oliver", "Kode"));
            users.Add(new User("User", "User"));
           

            return users;
        }

        public User getUserByName(string name)
        {
            List < User > users = GetUsers();

            foreach (User myUser in users)
            {
                if (myUser.UserName == name)
                    return myUser;
            }

            return null;
        }

        public ObservableCollection<Movie> GetMovies()
        {
            ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
            movies.Add(new Movie("Peter Plys 5", 2, DateTime.Today));
            movies.Add(new Movie("Avengers 2", 1, DateTime.Today));
            movies.Add(new Movie("Den her skal man ikke se", 3, DateTime.Today));
            movies.Add(new Movie("En skodfilm", 5, DateTime.Today));
            movies.Add(new Movie("En endnu værre film", 2, DateTime.Today));

            return movies;
        }

        public Movie getMovieByName(string name)
        {
            ObservableCollection<Movie> movies = GetMovies();

            foreach (Movie myMovie in movies)
            {
                {
                    if (myMovie.title == name)
                        return myMovie;
                }
                
            }
                        return null;
        }
    }
}
