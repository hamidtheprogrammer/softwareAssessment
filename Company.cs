using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soft
{
    public class Company
    {
        public int Id { get; set; }
        private string CompanyName { get; set; }
        private string Contact { get; set; }
        private string Website { get; set; }
        private string EstablishedDate { get; set; }
        private string LocationCountries { get; set; }
        private string LocationCities { get; set;}
        private string Addresses { get; set;}

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();

        public Company(int id, string companyName, string contact, string website, string establishedDate, string locationCountries, string locationCities, string addresses)
        {
            Id = id; //company Id
            CompanyName = companyName; //company name
            Contact = contact; // company contact
            Website = website; //company website
            EstablishedDate = establishedDate; //company established date
            LocationCountries = locationCountries; // company country loactions
            LocationCities = locationCities; // company city locations
            Addresses = addresses; //company addresses
        }

        //adding a company to database
        public void addCompany(Queries query, Company company)
        {   
            dbconnection.saveCompanyToDb(query.addCompanyToDb(), company.CompanyName, company.Contact, company.Website, company.EstablishedDate, company.LocationCountries, company.LocationCities, company.Addresses);
            //dbconnection class called to input queries to store passed parameters in the database
            Login.messagePrompt("Company successfully added");
        }
        
        //method overload for updating company information.
        public void addCompany(DBconnection dbconnection, Queries query, Company company, int id)
        {
            dbconnection.saveCompanyToDb(query.updateCompany(id), company.CompanyName, company.Contact, company.Website, company.EstablishedDate, company.LocationCountries, company.LocationCities, company.Addresses);
            //overloaded method, query changed to update company with specified Id
            Login.messagePrompt("Company successfully updated");
        }

        public static DataSet displayCompanies(DBconnection dbconnection , Queries query)
        {
            DataSet companies = dbconnection.getDataSet(query.displayCompany());
            //extraction of data from the database using queries, the data is stored into a dataset object.

            return companies;
            //return companies
        }

        //getting company Id to store as foreign key
        public int getCompany(Queries query)
        {
            DataSet getComp = dbconnection.getDataSet(query.getCompany());
            DataTable getCompanyDataTable = getComp.Tables[0];
            int companyId = Convert.ToInt16(getCompanyDataTable.Rows[0]["Id"]);
            return companyId;
        }


       

    }
}
