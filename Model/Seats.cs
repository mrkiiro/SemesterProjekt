using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8.Model
{
    class Seats
    {
        private int rowPos, colPos;
        private bool isTaken;

        public Seats(int x, int y)
        {
            rowPos = x;
            colPos = y;
            isTaken = false;
        }

        public void takeSeat()
        {
            isTaken = true;
        }

        public bool Occupied()
        {
            return isTaken;
        }
    }
}
