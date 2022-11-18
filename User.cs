using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStore
{
    public class User
    {
        //private variables of Class User
        private int _userId = 0;
        private string _name;
        private string _password;
        private string _email;
        private string _address;
        private double _phone;
        private bool _loggedIn = false;

        //(mostly)public getters and setters of Class User
        public int UserId
        {
            get => _userId;
            private set => _userId += _userId; //setter is private since the ID is only supposed to be set in the constructor of the User class
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value != null && value.Length > 6)
                {
                    _password = value;
                }
                else
                {
                    _password = null;
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value.Contains("@"))
                {
                    _email = value;

                }
                else
                    _email = null;
            }
        }
        public string Address { get => _address; set => _address = value; }
        public double Phone { get => _phone; set => _phone = value; }
        public bool LoggedIn { get => _loggedIn; set => _loggedIn = value; }

        public User()
        {
        }
        public User(string name, string password, string email, string address, double phone)
        {
            if (password != null && password.Length > 6)
            {
                this._password = password;
            }
            if (email.Contains("@"))
            {
                this._email = email;
            }
            this._name = name;
            this._address = address;
            this._phone = phone;
            _userId = UserId;
            _loggedIn = LoggedIn;
        }

    }

}
