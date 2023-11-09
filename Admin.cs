using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soft
{
    public class Admin
    {
        public int ID { get; set; }
        public string Name {  get; set; }
        public string Email {  get; set; }
        public String Password {  get; set; }

        public static Admin _instanceOfAdmin;

        public Admin(int iD , string name, string email, string password) 
        {
            ID = iD;
            Name = name;
            Email = email;
            Password = password;
        }

        public static Admin getInstanceOfAdmin(int iD, string name, string email, string password)
        {
            if ( _instanceOfAdmin == null)
            {
                _instanceOfAdmin = new Admin(iD,name, email, password);
            }
            return _instanceOfAdmin;
        }
    }
}
