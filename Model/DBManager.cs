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
            users.Add(new User("Admin", "Admin"));
            users.Add(new User("Oliver", "kode"));

            return users;
        }
    }
}
