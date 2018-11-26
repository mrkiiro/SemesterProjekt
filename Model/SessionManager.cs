using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App8.Model;

namespace App8
{
    class SessionManager
    {
        private SessionManager _myManager;
        public User loggedInUser;

        private SessionManager()
        {
        }

        public SessionManager GetManager()
        {
            if(_myManager == null)
            {
                _myManager = this;
            }

            return _myManager;
        }

        public void Login(string uname, string pword)
        {
            DBManager myDb = DBManager.getManager();
            List<User> users = myDb.GetUsers();

            foreach (User thisUser in users)
            {
                
            }
        }
    }
}
