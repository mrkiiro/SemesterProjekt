using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.Collections.ObjectModel;

using System.Linq;
using System.Runtime.CompilerServices;
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
            return _dbManager;
        }

        public static async Task initializeDatabase()
        {
            #region Things to initialize in DB
            List<Admin> admins = new List<Admin>
            {
                { new Admin("Admin", "Admin" )}
            };
            List<Clerk> clerks = new List<Clerk>
            {
                {new Clerk("Oliver", "Kode") }
            };
            List<Customer> customers = new List<Customer>
            {
                { new Customer("Inge123","123456")},
                { new Customer("AndersJensen", "makskodylt")}
            };
            List<Movie> movies = new List<Movie>
            {
                {new Movie("En fortælling om hummeren", 2, DateTime.Today)},
                {new Movie("Stakit, stativ, kasket", 1, DateTime.Today)},
                {new Movie("Den her skal man ikke se", 3, DateTime.Today)},
                {new Movie("En skodfilm", 5, DateTime.Today)},
                {new Movie("En endnu værre film", 2, DateTime.Today) }
            };
            #endregion

            await SaveAndLoad<List<Admin>>.Save(admins, "AdminDB.json");
            await SaveAndLoad<List<Clerk>>.Save(clerks, "ClerkDB.json");
            await SaveAndLoad<List<Customer>>.Save(customers, "CustomerDB.json");
            await SaveAndLoad<List<Movie>>.Save(movies, "MovieDB.json");

            Debug.WriteLine("Database with test data has been setup");
        }

        public async Task addCustomer(Customer c)
        {
            List<Customer> customersInDatabase = await DBManager.getManager().loadCustomers();
            customersInDatabase.Add(c);
            await SaveAndLoad<List<Customer>>.Save(customersInDatabase, "CustomerDB.json");
        }

        private async Task<List<User>> loadUsers()
        {
            List<User> users = new List<User>();

            List<Admin> admins = await loadAdmins();
            foreach (Admin admin in admins)
            {
                users.Add((User)admin);
            }

            List<Clerk> clerks = await loadClerks();
            foreach (Clerk thisClerk in clerks)
            {
                users.Add((User)thisClerk);
            }

            List<Customer> customers = await loadCustomers();
            foreach (Customer thisCustomer in customers)
            {
                users.Add((User)thisCustomer);
            }
            return users;
        }

        private async Task<List<Admin>> loadAdmins()
        {
            return await SaveAndLoad<List<Admin>>.Load("AdminDB.json");
        }

        private async Task<List<Clerk>> loadClerks()
        {
            return await SaveAndLoad<List<Clerk>>.Load("ClerkDB.json");
        }

        public async Task<List<Customer>> loadCustomers()
        {
            return await SaveAndLoad<List<Customer>>.Load("CustomerDB.json");
        }

        public async Task<List<User>> GetUsers()
        {
            return await loadUsers();
        }

        public async Task<User> getUserByName(string name)
        {
            foreach (User myUser in await getManager().GetUsers())
            {
                if (myUser.UserName == name)
                    return myUser;
            }
            return null;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await SaveAndLoad<List<Movie>>.Load("MovieDB.json");
        }

        public async Task<Movie> getMovieByName(string name)
        {
            List<Movie> movies = await GetMovies();
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
