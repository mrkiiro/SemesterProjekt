using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App8
{
    [DataContract]
    class Customer : User
    {
        [DataMember]
        private string email;
        [DataMember]
        private string phonen;

        public Customer(string username, string password) : base(username, password)
        {
            base.AcessLevel = User.AcessLevels.Customer;
        }
    }
}
