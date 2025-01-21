using Microsoft.VisualBasic.ApplicationServices;
using RCinema_db.src.User;
using System;

namespace RCinema_db.src.Managers
{
    public class CurrentUserManager
    {
        private static CurrentUserManager _instance;
        public User.User CurrentUser { get; private set; }

        private CurrentUserManager() { }

        public static CurrentUserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CurrentUserManager();
                }
                return _instance;
            }
        }

        public void SetCurrentUser(User.User user)
        {
            CurrentUser = user;
        }
    }
}
