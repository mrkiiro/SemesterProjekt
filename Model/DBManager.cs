using System;
using System.Collections.Generic;

using System.Diagnostics;
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
        private List<User> users;

        private DBManager()
        {
            instanciateDB();
            users = loadUsers().Result;
        }

        private void instanciateDB()
        {
            List<Clerk> clerk = new List<Clerk>();
            clerk.Add(new Clerk("Oliver", "Kode"));
            SaveAndLoad<List<Clerk>>.Save(clerk, "ClerkDB.json");

            List<Admin> admin = new List<Admin>();
            admin.Add(new Admin("Oliver", "Kode"));
            SaveAndLoad<List<Admin>>.Save(admin, "AdminDB.json");
        }

        public static DBManager getManager()
        {
            if (_dbManager == null)
            {
                _dbManager = new DBManager();
            }
            return _dbManager;
        }

        private async Task<List<User>> loadUsers()
        {
            /* working save code
            List<Clerk> clerk = new List<Clerk>();
            clerk.Add(new Clerk("Oliver", "Kode"));
            SaveAndLoad<List<Clerk>>.Save(clerk, "ClerkDB.json");
            */
            //List<Admin> admins = await SaveAndLoad<List<Admin>>.Load("AdminDB.json");
            List<Clerk> clerks = await SaveAndLoad<List<Clerk>>.Load("ClerkDB.json");

            List<User> users = new List<User>();
            /*
            foreach (Admin admin in admins)
            {
                users.Add((User)admin);
            }
            */
            foreach (Clerk thisClerk in clerks)
            {
                users.Add((User)thisClerk);
            }
            return users;
        }
        //AdminDB.json - ClerkDB.json
        public List<User> GetUsers()
        {
            if (users.Count > 0)
                return users;
            else
            {
                return null;
            }
        }

        public static User getUserByName(string name)
        {
            foreach (User myUser in getManager().GetUsers())
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
