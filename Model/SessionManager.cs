using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8
{
    class SessionManager
    {
        private SessionManager _myManager;
        public User loggedInUser;

        private SessionManager()
        {
            loggedInUser = new User("kasper", "pass");
        }

        public SessionManager GetManager()
        {
            if(_myManager == null)
            {
                _myManager = this;
            }

            return _myManager;
        }
    }
}
