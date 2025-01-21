using System;
using System.ComponentModel;

namespace RCinema_db.src.User
{
    public class User
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string FullName { get; private set; }

        /* also need security level and username for datagrid */

        public User(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            FullName = $"{FirstName} {LastName}";
        }
    }
}
