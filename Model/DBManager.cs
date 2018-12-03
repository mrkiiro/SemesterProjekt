using System;
using System.Collections.Generic;
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
            users.Add(new Customer("c", "c"));
            users.Add(new Customer("t", "t"));


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
    }
}
