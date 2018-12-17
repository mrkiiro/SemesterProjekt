using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.Serialization;
using System.ServiceModel.Security;

using System.Text;
using System.Threading.Tasks;

namespace App8
{
    [DataContract]
    class User
    {
        [DataMember]
        private string _userName;
        [DataMember]
        protected internal int AcessLevel;

        public User(string username, string password)
        {

            _userName = username;
            _password = password;
        }

        public static class AcessLevels
        {
            public const int Customer = 1;
            public const int Admin = 4;
            public const int Clerk = 2;
            public const int Anon = 3;
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string Password
        {
            get { return _password; }
        }

        public override string ToString()
        {
            return UserName;
        }
    }
}
