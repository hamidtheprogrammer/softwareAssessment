﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static int Id;
        public static string currentUserName;
        public static string currentUserPassword;
        public static string currentUserEmail;

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();

        public void messagePrompt(string message)
        {
            MessageBox.Show(message);
        }

        public string getUserName()
        {
            string username = tbUserName.Text;
            return username;
        }
        public string getPassword()
        {
            string password = tbPassword.Text;
            return password;
        }

        private void checkLoginCredentials()
        {
            if (getUserName() == "" || getPassword() == "")
            {
                messagePrompt("Please fill in credentials");
            }
            else
            {
                string query = "SELECT * from admin Where Username= '" + getUserName() + "' AND Password = '" +getPassword() + "'";
                DataSet datasetadmin = dbconnection.getDataSet(query);
                DataTable dataTable = datasetadmin.Tables[0];
                if(dataTable.Rows.Count == 1) 
                {
                    Id = Convert.ToInt16(dataTable.Rows[0]["ID"]);
                    currentUserName = dataTable.Rows[0]["Username"].ToString();
                    currentUserEmail = dataTable.Rows[0]["Email"].ToString();
                    currentUserPassword = dataTable.Rows[0]["Password"].ToString();

                    AdminDashboard adminDashboard = new AdminDashboard();
                    adminDashboard.Show();
                    this.Hide();
                    
                }
                else
                {
                    messagePrompt("Invalid Login credentials");
                }
            }

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            checkLoginCredentials();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                checkLoginCredentials();
            }
        }
    }
}
