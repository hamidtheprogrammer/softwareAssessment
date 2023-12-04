using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;
using System.Xml.Linq;

namespace soft
{
    public class DBconnection
    {
        private static DBconnection _instance;

        private String _connectionString;

        private DBconnection()
        {
            _connectionString = Properties.Settings.Default.DBconnectionstring;
        }

        public static DBconnection getInstanceOfDBconnection()
        {
            if (_instance == null)
            {
                _instance = new DBconnection();
            }
            return _instance;
        }

        public DataSet getDataSet(string sqlQuery)
        {
            //create the dataset object
            DataSet dataSet = new DataSet();

            using (SqlConnection connToDB = new SqlConnection(_connectionString))
            {
                //open connection
                connToDB.Open();

                //send SQL Query to the database
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connToDB);

                //fill in the dataset
                adapter.Fill(dataSet);

            }

            return dataSet;
        }


        //Db connection for Users
        public void saveToDb(string sqlQuery, String userName, string email, string password)
        {
            using (SqlConnection connToDb = new SqlConnection(_connectionString))
            {
                // open connectin
                connToDb.Open();

                //send SQL Query to the database
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDb);

                //set the sqlCommand's properties
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.Add(new SqlParameter("Username", userName));
                sqlCommand.Parameters.Add(new SqlParameter("Email", email));
                sqlCommand.Parameters.Add(new SqlParameter("Password", password));

                //execute the command
                sqlCommand.ExecuteNonQuery();
            }
        }

        /*public void savetoDB(string sqlQuery, string table, List<string> cols, List<object> data)
        {
            using (SqlConnection connToDb = new SqlConnection(_connectionString))
            {
                connToDb.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDb);

                sqlCommand.CommandType = CommandType.Text;

                for (int i = 0; i < cols.Count; i++)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(cols[i], data[i]));
                }

                sqlCommand.ExecuteNonQuery();


            }

        }*/


        //Dbconnection for product
        public void saveProductToDb(string sqlQuery, string name,  string description, string typeOfSoftware,string businessArea , byte[] pdf,string link)
        {
            using (SqlConnection connToDb = new SqlConnection(_connectionString))
            {
                // open connection
                connToDb.Open();

                //send SQL Query to the database
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDb);

                //set the sqlCommand's properties
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.Add(new SqlParameter("Name",name ));
                sqlCommand.Parameters.Add(new SqlParameter("Description", description));
                sqlCommand.Parameters.Add(new SqlParameter("Type_Of_Software", typeOfSoftware));
                sqlCommand.Parameters.Add(new SqlParameter("Business_Area", businessArea));             
                sqlCommand.Parameters.Add(new SqlParameter("PDF", SqlDbType.VarBinary)).Value = pdf;
                sqlCommand.Parameters.Add(new SqlParameter("Link", link));

                //execute the command
                sqlCommand.ExecuteNonQuery();

            }
        }


        //overloaded method to store foriegn key
        public void saveProductToDb(string sqlQuery, int id)
        {
            using (SqlConnection connToDb = new SqlConnection(_connectionString))
            {
                connToDb.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDb);

                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.Add(new SqlParameter("CompanyId", id));

                sqlCommand.ExecuteNonQuery();

            }
        }
        //overloaded method to remove foreign key
        public void saveProductToDb(string sqlQuery)
        {
            using (SqlConnection connToDb = new SqlConnection(_connectionString))
            {
                connToDb.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDb);

                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.ExecuteNonQuery();

            }
        }

        public void saveCompanyToDb(string sqlQuery, string company_Name, string contact, string website, string established_date, string location_Countries, string location_Cities, string addresses)
        {
            using (SqlConnection connToDb = new SqlConnection(_connectionString))
            {
                // open connection
                connToDb.Open();

                //send SQL Query to the database
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDb);

                //set the sqlCommand's properties
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.Add(new SqlParameter("Company_Name", company_Name));
                sqlCommand.Parameters.Add(new SqlParameter("Contact", contact));
                sqlCommand.Parameters.Add(new SqlParameter("Website", website));
                sqlCommand.Parameters.Add(new SqlParameter("Established_Date", established_date));
                sqlCommand.Parameters.Add(new SqlParameter("Location_Countries", location_Countries));
                sqlCommand.Parameters.Add(new SqlParameter("Location_Cities", location_Cities));
                sqlCommand.Parameters.Add(new SqlParameter("Addresses", addresses));

                //execute the command
                sqlCommand.ExecuteNonQuery();

            }

        }

            //dbconnection for clients
            public void saveClientToDb(string sqlQuery, string name, string email, string request, string clientType, string status)
        {
            using (SqlConnection connToDb = new SqlConnection(_connectionString))
            {
                connToDb.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDb);

                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.Add(new SqlParameter("Name", name));
                sqlCommand.Parameters.Add(new SqlParameter("Email", email));
                sqlCommand.Parameters.Add(new SqlParameter("Request", request));
                sqlCommand.Parameters.Add(new SqlParameter("ClientType", clientType));
                sqlCommand.Parameters.Add(new SqlParameter("Status", status));


                sqlCommand.ExecuteNonQuery();

            }
        }
    }
}