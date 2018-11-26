using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8.Model
{
    class Admin : User
    {
        public Admin(string Username, string Password) : base(Username, Password)
        {
            base.AcessLevel = User.AcessLevels.Admin;
            Debug.WriteLine("Created Admin User");
        }
    }
}
