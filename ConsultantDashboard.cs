using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soft
{
    public partial class ConsultantDashboard : Form
    {
        public ConsultantDashboard()
        {
            InitializeComponent();
        }

        Queries query = new Queries();
        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();

        private void label15_Click(object sender, EventArgs e)
        {

        }

        
        private void btnClients_Click(object sender, EventArgs e)
        {
            pnAddClient.Visible = false;
            pnUpdateClient.Visible = false;
            pnClients.Visible = true;
            pnShowClients.Visible = false;
        }
        
        private void btnCreateclient_Click(object sender, EventArgs e)
        {
            pnAddClient.Visible = true;
            pnUpdateClient.Visible = false;
            pnClients.Visible = false;
            pnShowClients.Visible = false;
            rbPending.Checked = true;
        }
        
        private void btnEditClients_Click(object sender, EventArgs e)
        {
            pnAddClient.Visible = false;
            pnClients.Visible = false;
            pnUpdateClient.Visible = true;
            pnShowClients.Visible = false;
        }

       /* private string status()
        {
            string status;
            if (rbPending.Checked)
            {
                status = "Pending";
                return status;
            }
            else if (rbInProgress.Checked)
            {
                status = "In progress";
                return status;
            }
            else if (rbCompleted.Checked)
            {
                status = "Completed";
                return status;
            }
            
        }*/
        private void btnAddclient_Click(object sender, EventArgs e)
        {
            //creating predefined strings to be stored in the database for client's request's status
           
            if (tbAddClientName != null) 
            { 
               

                Client client = new Client(1, tbAddClientName.Text , tbAddClientEmail.Text, tbAddClientRequest.Text, tbAddClientType.Text, "status");
                client.addClient(query , client);
            }
            else
            {
                MessageBox.Show("Client name cannot be null");
            }
            
        }

        private void btnShowClients_Click(object sender, EventArgs e)
        {
            pnShowClients.Visible = true;
            pnAddClient.Visible = false;
            pnUpdateClient.Visible = false;
            pnClients.Visible = false;
            dgvShowClients.DataSource = Client.getClient(dbconnection, query).Tables[0];
        }
    }
}
