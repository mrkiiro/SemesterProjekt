using System;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Globalization.NumberFormatting;
using Windows.UI.ViewManagement;

namespace App8
{
    public class Movie
    {
        private string _title;
        private int _room;
        private DateTime _time;
       

        public Movie(string title, int room, DateTime time)
        {
            _title = title;
            _room = room;
            _time = DateTime.MaxValue;
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int room
        {
            get { return _room; }
            set { _room = value; }

        }

            private DateTime Time
        {
            get { return _time; }
            set { _time = DateTime.MaxValue; }
        }
      
    }

}