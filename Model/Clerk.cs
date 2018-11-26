using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App8.Annotations;

namespace App8.Model
{
    class Clerk : User
    {
        public Clerk(string Username, string Password) : base(Username, Password)
        {
            base.AcessLevel = User.AcessLevels.Clerk;
            Debug.WriteLine("Created Clerk user");
        }
    }
}
