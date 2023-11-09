using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soft
{
    public partial class AdminRegister : Form
    {
        public AdminRegister()
        {
            InitializeComponent();
        }


        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();

        

        private void register_Click(object sender, EventArgs e)
        {
            String name = usernameBox.Text;
            String email = emailBox.Text;
            String password = passwordBox.Text;

            /*while (true)
            {
                DataSet datasetadmin = dbconnection.getDataSet("SELECT Username, Email FROM admin");
                
            }*/

            dbconnection.saveToDb("INSERT INTO admin (Username, Email, Password) VALUES (@Username, @Email, @Password)" , name , email , password );

            MessageBox.Show("Registration successful");

            usernameBox.Text = "";
            emailBox.Text = "";
            passwordBox.Text = "";

        }
    }
}
