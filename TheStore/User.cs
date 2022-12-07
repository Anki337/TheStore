﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace TheStore
{
    public class User : IParsing<User>
    {
        //private variables of Class User
        private string _name;
        private string _password;
        private string _email;
        private string _address;
        private double _phone;
        private bool _isAdmin;

        //public getters and setters of Class User  
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
                if (value != null && value.Length >= 6)
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
        public bool IsAdmin { get => _isAdmin; set => _isAdmin = value; }

        public User(string Name, string Password, string Email, string Address, double Phone, bool IsAdmin)
        {
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
            this.Address = Address;
            this.Phone = Phone;
            this.IsAdmin = IsAdmin;
        }
        public User(string Name, string Password, string Email, string Address, double Phone)
        {
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
            this.Address = Address;
            this.Phone = Phone;
            this.IsAdmin = IsAdmin;
            IsAdmin = false;
        }


        public User parse(string[] words)
        {
            return new User(Name: words[0], Password: words[1],
                            Email: words[2], Address: words[3],
                            Phone: Convert.ToDouble(words[4]), IsAdmin: Convert.ToBoolean(words[5]));
        }
        public User()
        {

        }

        public override string ToString()
        {
            string line = Name + "," + Password + "," + Email + "," + Address + "," + Convert.ToString(Phone) + "," + Convert.ToString(IsAdmin) + "\r\n";
            return line;
        }

    }

}
