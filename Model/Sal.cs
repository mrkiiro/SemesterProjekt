using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8.Model
{
    class Sal
    {
        private int _rows;
        private int _seats;
        private string _name;
        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        public int Seats
        {
            get { return _seats; }
            set { _seats = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public Sal(int rows, int seats, string name)
        {
            this.Rows = rows;
            this.Seats = seats;
            this.Name = name;
        }
    }
}
