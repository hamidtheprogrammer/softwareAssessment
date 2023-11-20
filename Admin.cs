using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
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

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();

        Login login = new Login();

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
        public void saveAdminToDb(Queries query, Admin admin)
        {
            dbconnection.saveToDb(query.createNewAdmin(), admin.Name, admin.Email, admin.Password);
            Login.messagePrompt("User added successfully");

        }

        public void updateAdmin(Queries query, int Id , string newCurrentUserName, string newCurrentUserEmail, string newCurrentUserPassword )
        {
            dbconnection.saveToDb(query.updateAccount(Id), newCurrentUserName, newCurrentUserEmail, newCurrentUserPassword);
            Login.messagePrompt("Account successfully updated");
        }
    }
}
