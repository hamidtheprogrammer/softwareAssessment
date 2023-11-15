using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace soft
{
    public class Queries
    {
        public string checkLoginAdmin(string getUsername, string getPassword)
        {
            return ($"SELECT * from admin Where Username='{getUsername}' AND Password = '{getPassword}'");
        }

        public string checkLoginConsultant(string getUsername, string getPassword)
        {
            return ($"SELECT * from consultant Where Username='{getUsername}' AND Password = '{getPassword}'");
        } 
        public string createNewAdmin()
        {
            string query = "INSERT INTO admin (Username, Email, Password) VALUES (@Username, @Email, @Password)";
            return query;
        }

        public string createNewConsultant()
        {
            string query = "INSERT INTO consultant (Username, Email, Password) VALUES (@Username, @Email, @Password)";
            return query;
        }
        public string updateAccount( int ID)
        {
            //return ("UPDATE '"+user+"' SET Name = '"+@newUsername+"', Email = '"+@newEmail+"', Password = '"+@newPassword+"' Where ID = '"+ID+"'" );string newUsername,, string newEmail, string newPassword
            return ($"UPDATE admin SET Username = @Username, Email = @Email, Password = @Password Where ID = '{ID}'");
            //dbconnection.saveToDb("INSERT INTO admin (Username, Email, Password) VALUES (@Username, @Email, @Password)", name, email, password);
        }

        public string saveProductToDb()
        {
            string query = "INSERT INTO product (Name, Description, Type_Of_Software, Business_Area, PDF, Link) VALUES (@Name, @Description, @Type_Of_Software, @Business_Area, @PDF, @Link)";
            return query;
        }

        public string getProductFromDb() {
            string query = "SELECT * from product";
            return query;
        }

        public string getSpecificProduct(int id)
        {
            return ($"SELECT * from product Where Id = '{id}'");
        }

        public string updateProduct(int id)
        {
            return $"UPDATE product SET Name = @Name, Description = @Description, Type_Of_Software = @Type_Of_Software, Business_Area = @Business_Area, PDF = @PDF , Link = @Link Where ID = '{id}'";
        }

       

        
    }
}
