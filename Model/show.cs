using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8.Model
{
    class show
    {
        private DateTime playingTime;
        private Sal playingSal;
        private Movie playingMovie;

        public show(Movie movie, DateTime DateForPlaying, Sal sal)
        {
            playingTime = DateForPlaying;
            playingMovie = movie;
            playingSal = sal;
        }

        public void reserveSeat(int x, int y)
        {
            playingSal.reserveSeat(x, y);
        }
    }
}