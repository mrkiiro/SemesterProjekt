using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App8.Model;

namespace App8
{
    class SessionManager
    {
        private static SessionManager _myManager;
        public static User loggedInUser;

        private SessionManager()
        {
        }

        public static SessionManager GetManager()
        {
            if (_myManager == null)
            {
                _myManager = new SessionManager();
            }
            return _myManager;
        }

        public static void Logout()
        {
            loggedInUser = null;
            Frame CurrFrame = (Frame)Window.Current.Content;
            CurrFrame.Navigate(typeof(MainPage));
        }

        public async Task<bool> Login(User u)
        {
            List<User> users = await DBManager.getManager().GetUsers();

            bool UnameExist = false;
            bool PwordExist = false;

            foreach (User thisUser in users)
            {
                if (thisUser.UserName == u.UserName)
                {
                    UnameExist = true;
                }
                if (thisUser.Password == u.Password && UnameExist)
                {
                    PwordExist = true;
                }
            }

            if (UnameExist && PwordExist)
            {
                loggedInUser = await DBManager.getManager().getUserByName(u.UserName);
                return true;
            }
            else if (UnameExist)
            {
                //Username Correct
                return false;
            }
            else
            {
                //username not correct
                return false;
            }
        }
    }
}
