﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8.Model
{
    class Room
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

        public Room(int row, int col)
        {
            _rows = row;
            _col = col;
        }
    }
}
