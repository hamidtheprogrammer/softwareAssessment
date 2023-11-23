﻿using System;
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
            return ($"UPDATE consultant SET Username = @Username, Email = @Email, Password = @Password Where ID = '{ID}'");
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

        public string updateProduct(int id, int foreignKey)
        {
            return $"UPDATE product SET companyId = '{foreignKey}' Where ID = '{id}'";
        }

        public string deleteProduct(int Id)
        {
            return $"DELETE from product where Id = '{Id}'";
        }

        public string searchProduct(string name)
        {
            return $"SELECT * from product where Name like '%{name}%'";
        }

        public string countProduct()
        {
            return "SELECT COUNT(*) FROM product";
        }
        public string addCompanyToDb()
        {
            return "INSERT INTO Company (Company_Name, Contact, Website, Established_Date, Location_Countries, Location_Cities, Addresses) VALUES (@Company_Name, @Contact, @Website, @Established_Date, @Location_Countries, @Location_Cities, @Addresses)";
        }

        public string getCompany()
        {
            return "SELECT * FROM COMPANY WHERE ID = (SELECT MAX(ID) FROM Company)";
        }

        public string displayCompany()
        {
            return $"SELECT * FROM company";
        }
        public string updateCompany(int id)
        {
            return $"UPDATE Company SET Company_Name = @Company_Name, Contact = @Contact, Website = @Website, Established_date = @Established_date, Location_Countries = @Location_Countries , Location_Cities = @Location_Cities , Addresses = @Addresses Where ID = '{id}'";
        }

        public string deleteCompany(int Id)
        {
            return $"DELETE from company where Id = '{Id}'";
        }

        public string addForeignKeyToNewlyAddedProduct()
        {
            return $"UPDATE product SET CompanyId = @CompanyId WHERE ID = (SELECT MAX(ID) FROM product)";
        }

        public string getCompanyWithForeignKey(int Id)
        {
            return $"SELECT Company.* FROM Company JOIN Product ON Company.Id = Product.CompanyId WHERE Product.Id = '{Id}'";
        }

        public string getProductRelatedToCompany(int Id)
        {
            return $"SELECT * FROM product where CompanyId = '{Id}'";
        }

        public String removeForeignKey(int Id)
        {
            return $"UPDATE product SET CompanyId = NULL Where ID = '{Id}'";
        }

        

        public string addClient()
        {
            return "INSERT INTO clients (Name, Email, Request, ClientType) VALUES (@Name, @Email, @Request, @ClientType)";
        }

        public string getClient()
        {
            return "SELECT * from clients";
        }

       

        
    }
}
