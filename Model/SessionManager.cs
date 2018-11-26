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
                _myManager = new SessionManager();
            }

            return _myManager;
        }

        public bool Login(User u)
        {
            DBManager myDb = DBManager.getManager();
            List<User> users = myDb.GetUsers();

            bool UnameExist = false;
            bool PwordExist = false;

            foreach (User thisUser in users)
            {
                if (thisUser.UserName == u.UserName)
                {
                    UnameExist = true;
                }
                if (thisUser.Password == u.Password && UnameExist)
                {
                    PwordExist = true;
                }
            }

            if (UnameExist && PwordExist)
            {
                //log ind
                this.loggedInUser = u;
                return true;
            }
            else if (UnameExist)
            {
                //Username Correct
                return false;
            }
            else
            {
                //username not correct
                return false;
            }
        }
    }
}
