﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soft
{
    public class user
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public user(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }
    }
    public class admin: user
    {
        public admin(string name , string password , string email): base(name , password , email) 
        {
            

        }
    }

}
