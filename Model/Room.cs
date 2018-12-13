using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8.Model
{
    class Room
    {
        private int _rows, _columns;
        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }
        public int Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        public Room(int row, int column)
        {
            _rows = row;
            _columns = column;
        }
    }
}
