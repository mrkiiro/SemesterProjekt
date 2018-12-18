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
        private int _col;

        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        public int Col
        {
            get { return _col; }
            set { _col = value; }
        }

        public Sal(int row, int col)
        {
            _rows = row;
            _col = col;
        }
    }
}
