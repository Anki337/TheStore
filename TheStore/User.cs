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
        private string _phone;
        private bool _isAdmin;
        private int hashCode;

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
        public string Phone { get => _phone; set => _phone = value; }
        public bool IsAdmin { get => _isAdmin; set => _isAdmin = value; }

        public User(string Name, string Password, string Email, string Address, string Phone, bool IsAdmin)
        {
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
            this.Address = Address;
            this.Phone = Phone;
            this.IsAdmin = IsAdmin;
        }
 
        public User parse(string[] words)
        {
            return new User(Name: words[0], Password: words[1],
                            Email: words[2], Address: words[3],
                            Phone: words[4], IsAdmin: Convert.ToBoolean(words[5]));
        }
        public User()
        {

        }

        public override string ToString()
        {
            string line = Name + "," + Password + "," + Email + "," + Address + "," + Phone + "," + IsAdmin + "\r\n";
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
        public bool Equals(User obj) => obj != null && Phone == obj.Phone &&
                                                       Name == obj.Name &&
                                                       Password == obj.Password &&
                                                       Email == obj.Email &&
                                                       Address == obj.Address &&
                                                       IsAdmin == obj.IsAdmin;
        /*public override bool Equals(object obj)
        {
            return obj is User user &&
                   Name == user.Name &&
                   Password == user.Password &&
                   Email == user.Email &&
                   Address == user.Address &&
                   Phone == user.Phone &&
                   IsAdmin == user.IsAdmin &&
                   EqualityComparer<object>.Default.Equals(hashCode, user.hashCode);
        }
        */
        public override int GetHashCode()
        {
            int hashCode = -637348235;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IsAdmin);
            hashCode = hashCode * -1521134295 + EqualityComparer<object>.Default.GetHashCode(this.hashCode);
            return hashCode;
        }


        /*public override int GetHashCode()
        {
            //var hashCode = 181846194;
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            hashCode = hashCode * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(IsAdmin);
            return hashCode;
        }*/

    }

}
