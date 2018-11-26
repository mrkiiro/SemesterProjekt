using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8
{
    class User
    {
        private string _userName;
        private string _password;
        private int _acessLevel;

        public User(string username, string password)
        {
            _userName = username;
            _password = password;
            _acessLevel = AcessLevels.Anon;
        }

        public static class AcessLevels
        {
            public static int Customer = 1;
            public static int Admin = 2;
            public static int Clerk = 3;
            public static int Anon = 4;
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}
