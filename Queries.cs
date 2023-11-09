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
        public string updateAccount(string user ,int ID )
        {
            //return ("UPDATE '"+user+"' SET Name = '"+@newUsername+"', Email = '"+@newEmail+"', Password = '"+@newPassword+"' Where ID = '"+ID+"'" );string newUsername,, string newEmail, string newPassword
            return ("UPDATE '"+user+ "' SET Name = newUsername, newEmail, newPassword Where ID = '"+ID+"'");
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
    }
}
