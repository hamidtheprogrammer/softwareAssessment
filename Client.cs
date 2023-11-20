using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace soft
{
    public class Client
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Request { get; set; }
        public string ClientType {  get; set; }
        public string Status {  get; set; }

        public Client(int id , string name , string email , string request , string clientType, string status) 
        { 
            Id = id;
            Name = name;
            Email = email;
            Request = request;
            ClientType = clientType;
            Status = status;

        }

        DBconnection dBconnection = DBconnection.getInstanceOfDBconnection();

        public void addClient(Queries query, Client client)
        {
            dBconnection.saveClientToDb(query.addClient() , client.Name , client.Email, client.Request, client.ClientType, client.Status);
            Login.messagePrompt("Client successfully added");
        }

        public static DataSet getClient(DBconnection dbconnection , Queries query)
        {
            DataSet getclient = dbconnection.getDataSet(query.getClient());
            return getclient;
        }
    }
}
