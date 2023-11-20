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
        public string CompanyName { get; set; }
        public string Contact { get; set; }
        public string Website { get; set; }
        public string EstablishedDate { get; set; }
        public string LocationCountries { get; set; }
        public string LocationCities { get; set;}
        public string Addresses { get; set;}

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();

        public Company(int id, string companyName, string contact, string website, string establishedDate, string locationCountries, string locationCities, string addresses)
        {
            Id = id;
            CompanyName = companyName;
            Contact = contact;
            Website = website;
            EstablishedDate = establishedDate;
            LocationCountries = locationCountries;
            LocationCities = locationCities;
            Addresses = addresses;
        }


        public void addCompany(Queries query, Company company)
        {
            dbconnection.saveCompanyToDb(query.addCompanyToDb(), company.CompanyName, company.Contact, company.Website, company.EstablishedDate, company.LocationCountries, company.LocationCities, company.Addresses);
            Login.messagePrompt("Company successfully added");
        }

        public static DataSet displayCompanies(DBconnection dbconnection , Queries query)
        {
            DataSet companies = dbconnection.getDataSet(query.displayCompany());
            
            return companies;
        }

        public int getCompany(Queries query)
        {
            DataSet getComp = dbconnection.getDataSet(query.getCompany());
            DataTable getCompanyDataTable = getComp.Tables[0];
            int companyId = Convert.ToInt16(getCompanyDataTable.Rows[0]["Id"]);
            return companyId;
        }


        //method overload for updating company information.
        public void addCompany(DBconnection dbconnection, Queries query, Company company, int id)
        {
            dbconnection.saveCompanyToDb(query.updateCompany(id), company.CompanyName, company.Contact, company.Website, company.EstablishedDate, company.LocationCountries, company.LocationCities, company.Addresses);
            Login.messagePrompt("Company successfully updated");
        }

        public static Company displayclicked_company(DataRowView dataRowView)
        {
            int clickedCompanyId = Convert.ToInt16(dataRowView["Id"]);
            string clickedCompanyName = dataRowView["Company_Name"].ToString();
            string clickedCompanyContact = dataRowView["Contact"].ToString();
            string clickedCompanyWebsite = dataRowView["Website"].ToString();
            string clickedCompanyEstablishedDate = dataRowView["Established_Date"].ToString();
            string clickedCompanyLocationCountries = dataRowView["Location_Countries"].ToString();
            string clickedCompanyLocationCities = dataRowView["Location_Cities"].ToString();
            string clickedCompanyAddresses = dataRowView["Addresses"].ToString();

            Company company = new Company(clickedCompanyId, clickedCompanyName, clickedCompanyContact, clickedCompanyWebsite, clickedCompanyEstablishedDate, clickedCompanyLocationCountries, clickedCompanyLocationCities, clickedCompanyAddresses);

            return company;
        }
    }
}
