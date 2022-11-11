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
        private int UserId = 0;
        private string name;
        private string password;
        private string email;
        private string address;
        private int phone;
        private bool loggedIn = false;


        public int getUserId()
        {
            return UserId;
        }

        public void setUserId() 
        {
            UserId = UserId + 1;
        }

        public string getName()
        { 
            return name;
        }

        public void setName(string _name) 
        {
            name = _name;
        }

        public string getPassword()
        {

            return password;
        }

        public bool setPassword(string _password)
        {
            if
                (password != null && password.Length > 6)
            {
                password = _password;
                return true;
            } else
                return false;    
        }

        public string getEmail()
        {
            return email;
        }

        public bool setEmail(string _email) 
        {
            if (_email.Contains("@"))
            {
                email = _email;
                return true;
            }
            else
                return false;
        }

        public string getAddress()
        {
            return address;
        }

        public void setAddress(string _address) 
        {
            address = _address;
        }
        
        public int getPhone()
        {
            return phone;
        }

        public void setPhone(int _phone) 
        {
            _phone = phone;
        }

        public bool getLoggedIn() 
        { 
            return loggedIn;
        }

        public void setLoggedIn(bool _loggedIn) 
        { 
            loggedIn = _loggedIn;
        }

        public User(string name, string password, string email, string address, int phone)
        {
            if (password != null && password.Length > 6)
            {
                this.password = password;
            }
            if (email.Contains("@"))
            {
                this.email = email;
            }
                this.name = name;
                this.address = address;
                this.phone = phone;
                UserId = UserId + 1;
                loggedIn = true;
                //userList.add();
        }
       
    }
 
}
