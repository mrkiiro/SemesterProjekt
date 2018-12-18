using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8.Model
{
    class Sal
    {
        private Seat[,] seats;
        public int Rows, Cols;

        public Sal(int rows, int cols)
        {
            seats = new Seat[rows,cols];
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    seats[x,y] = new Seat();
                }
            }

            Rows = rows;
            Cols = cols;
        }

        public bool reserveSeat(int x,int y)
        {
            return seats[x, y].reserve();
        }
    }
}
