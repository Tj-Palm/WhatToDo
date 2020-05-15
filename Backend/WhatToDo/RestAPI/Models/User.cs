using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class User
    {
        private int _userId;
        private string _userName;
        private string _password;

        public User(string Username, string Password)
        {
            _userName = Username;
            _password = Password;
        }

        public User()
        {
            
        }

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }
        public string Username
        {
            get => _userName;
            set => _userName = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

   
    }
}
