using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace TheStore
{
    public class User : IParsing<User>, IEquatable<User>
    {
        //private variables of Class User
        private string _name;
        private string _password;
        private string _email;
        private string _address;
        private double _phone;

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

        public User(string Name, string Password, string Email, string Address, double Phone)
        {
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
            this.Address = Address;
            this.Phone = Phone;
        }


        public User parse(string[] words)
        {
            return new User(Name: words[0], Password: words[1],
                            Email: words[2], Address: words[3],
                            Phone: Convert.ToDouble(words[4]));
        }
        public User()
        {

        }

        public override string ToString()
        {
            string line = Name + "," + Password + "," + Email + "," + Address + "," + Convert.ToString(Phone) + "\r\n";
            return line;
        }

        /*public override bool Equals(object obj)
        {
            var User = obj as User;

            if (User != null)
            {
                return this.Phone == User.Phone
                   && this.Password == User.Password
                   && this.Email == User.Email
                   && this.Address == User.Address
                   && this.Name == User.Name;
            }
            else 
                return false;
            
         }*/
        
        public override bool Equals(object obj) => Equals(obj as User);
        public bool Equals(User obj) => obj != null && Phone == obj.Phone
                                                    && Password == obj.Password
                                                    && Email == obj.Email
                                                    && Address == obj.Address
                                                    && Name == obj.Name;
        public override int GetHashCode()
        {
            var hashCode = 181846194;
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(Phone);
            return hashCode;
        }
    
    }

}
