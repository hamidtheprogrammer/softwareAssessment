using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void savetoDB(string sqlQuery, string table, List<string> cols, List<object> data)
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

        }

        public void saveProductToDb(string sqlQuery, string name, string typeOfSoftware, string businessArea, string link, byte[] pdf, string description)
        {
            using (SqlConnection connToDb = new SqlConnection(_connectionString))
            {
                connToDb.Open();

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connToDb);

                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.Add(new SqlParameter("Name",name ));
                sqlCommand.Parameters.Add(new SqlParameter("Description", description));
                sqlCommand.Parameters.Add(new SqlParameter("Type_Of_Software", typeOfSoftware));
                sqlCommand.Parameters.Add(new SqlParameter("Business_Area", businessArea));             
                sqlCommand.Parameters.Add(new SqlParameter("PDF", pdf));
                sqlCommand.Parameters.Add(new SqlParameter("Link", link));


            }
        }
    }
}