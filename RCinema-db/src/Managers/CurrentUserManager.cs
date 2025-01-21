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
                    lock (typeof(CurrentUserManager))
                    {
                        if (_instance == null)
                        {
                            _instance = new CurrentUserManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetCurrentUser(User.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            CurrentUser = user;
            Console.WriteLine($"Current user set: UserID={user.Id}");
        }

        public User.User GetCurrentUser()
        {
            if (CurrentUser == null)
            {
                throw new InvalidOperationException("Current user is not set.");
            }
            return CurrentUser;
        }
    }
}
