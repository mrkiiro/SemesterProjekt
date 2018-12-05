using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            users = loadUsers().Result;
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
    }
}
