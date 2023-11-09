using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace soft
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }
        Admin currentAdmin = Admin.getInstanceOfAdmin(Login.Id, Login.currentUserName , Login.currentUserEmail, Login.currentUserPassword);
        //create instance for the logged in admin

        Queries query = new Queries();
        //create query object to access queries

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();
        //get instance of DBconnection

        Login login = new Login();
        //object of login class

        

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

            lbwelcome.Text = "Welcome "+currentAdmin.Name;
            
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        { 
            //display admin account details

            pnEditProfile.Visible = true;
            pnCreateProduct.Visible = false;
            pnShowInventory.Visible = false;
            pnCreateNewUser.Visible = false;
            tbnewUserName.Text = currentAdmin.Name;
            tbNewEmail.Text = currentAdmin.Email;
            tbnewPassword.Text = currentAdmin.Password;

        }
       

        private void btnLogin_Click(object sender, EventArgs e)
        {   //update admin account
            string newCurrentUserName = tbnewUserName.Text;
            string newCurrentUserEmail = tbNewEmail.Text;
            string newCurrentUserPassword = tbnewPassword.Text;

            dbconnection.saveToDb(query.updateAccount("admin" , currentAdmin.ID) , newCurrentUserName, newCurrentUserEmail, newCurrentUserPassword) ;
            login.messagePrompt("Account successfully updated");

        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {   //add a new product 
            pnCreateProduct.Visible = true;
            pnEditProfile.Visible= false;
            pnShowInventory.Visible= false;
            pnCreateNewUser.Visible = false;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            byte[] pdf = File.ReadAllBytes(lbfilePath.Text);

            Product product = new Product(1,tbProductName.Text, rtbDescription.Text, tbProductSoftware.Text, tbBusinessArea.Text, pdf, tbUrl.Text);
            //new product object

            //var cols = new List<string>(){"Name","Description","Type_Of_Software","Business_Area","PDF","Link"};
            //add database column to fill to list

            //var data = new List<object>() { product.Name, product.TypeOfSoftware, product.BusinessArea, product.Link, product.PDF, product.Description };
            //add data to be inserted in the database to list

            product.addProduct(query, product);

            //dbconnection.saveToDb("INSERT INTO admin (Username, Email, Password) VALUES (@Username, @Email, @Password)", name, email, password);
        }

        private void btnSavePdf_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog =  new OpenFileDialog())
            {   //openfiledialog object

                openFileDialog.Filter = "PDF Files |*.pdf";
                //filter for pdf files

                openFileDialog.Title = "Please select a PDF file for attachment";
                //tell user to select a PDF file

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    //verify correct PDF file
                {
                    string filePath = openFileDialog.FileName;
                    lbfilePath.Text = filePath;
                }
            } 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
             
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            

        }

        private void btnShowInventory_Click(object sender, EventArgs e)
        {
            pnShowInventory.Visible = true;
            pnEditProfile.Visible= false;
            pnCreateProduct.Visible= false;
            pnCreateNewUser.Visible = false;
            DataSet getProduct = dbconnection.getDataSet(query.getProductFromDb());
            //DataTable dataTable = getProduct.Tables[0];
            dgvViewproduct.DataSource = getProduct.Tables[0];
        }

        private void btnCreateNewUser_Click(object sender, EventArgs e)
        { 
             pnCreateNewUser.Visible = true;
             pnCreateProduct.Visible = false;
             pnEditProfile.Visible = false;
             pnShowInventory.Visible = false;

            rbConsultant.Checked = true;

        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if(rbAdmin.Checked)
            {
                Admin admin = new Admin(1,tbAddNewUserName.Text, tbAddNewUserEmail.Text, tbAddNewUserPassword.Text);
                admin.saveAdminToDb(query , admin);
            }
            else
            {
                Consultant consultant = new Consultant(1, tbAddNewUserName.Text, tbAddNewUserEmail.Text, tbAddNewUserPassword.Text);
                consultant.saveConsultantToDb(query , consultant);
            }
        }



        /* private void button3_Click(object sender, EventArgs e)
         {
            
         }

         private void btnCreateNewUser_Click(object sender, EventArgs e)
         {

         }*/
    }
}
