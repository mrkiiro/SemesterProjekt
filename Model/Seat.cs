using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8.Model
{
    class Seat
    {
        private bool isTaken;

        public Seat()
        {
            isTaken = false;
        }

        public bool reserve()
        {
            if (isTaken)
            {
                return false;
            }
            else
            {
                isTaken = true;
                return true;
            }
        }
    }
}
