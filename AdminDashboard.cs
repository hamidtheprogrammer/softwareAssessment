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
        Admin currentAdmin = new Admin(Login.Id, Login.currentUserName , Login.currentUserEmail, Login.currentUserPassword);
        //create instance for the logged in admin

        Queries query = new Queries();
        //create query object to access queries

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();
        //get instance of DBconnection

        Login login = new Login();
        //object of login class

        Product product;
        //object of product class

        
        //welcome User
        private void AdminDashboard_Load(object sender, EventArgs e)
        {

            lbwelcome.Text = "Welcome "+currentAdmin.Name;
            
        }



        //admin account
        private void btnEditProfile_Click(object sender, EventArgs e)
        {   //display admin account details
            pnEditProfile.Visible = true;
            pnCreateProduct.Visible = false;
            pnShowInventory.Visible = false;
            pnCreateNewUser.Visible = false;
            pnUpdateProduct.Visible = false;
            tbnewUserName.Text = currentAdmin.Name;
            tbNewEmail.Text = currentAdmin.Email;
            tbnewPassword.Text = currentAdmin.Password;
        }
       
        private void btnUpdateAccount_Click(object sender, EventArgs e)
        { //update admin account
            string newCurrentUserName = tbnewUserName.Text;
            string newCurrentUserEmail = tbNewEmail.Text;
            string newCurrentUserPassword = tbnewPassword.Text;

            currentAdmin.updateAdmin(query, currentAdmin.ID, newCurrentUserName, newCurrentUserEmail, newCurrentUserPassword);

            tbnewUserName.Text = newCurrentUserName;
            tbNewEmail.Text = newCurrentUserEmail;
            tbnewPassword.Text = newCurrentUserPassword;

            lbwelcome.Text = "Welcome "+newCurrentUserName;            
        }



        //Product info
        private void btnCreateProduct_Click(object sender, EventArgs e)
        {   //add a new product 
            pnCreateProduct.Visible = true;
            pnEditProfile.Visible= false;
            pnShowInventory.Visible= false;
            pnCreateNewUser.Visible = false;
            pnUpdateProduct.Visible = false;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            byte[] pdf = File.ReadAllBytes(lbfilePath.Text);

            product = new Product(1,tbProductName.Text, rtbDescription.Text, tbProductSoftware.Text, tbBusinessArea.Text, pdf, tbUrl.Text);
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
            lbfilePath.Text = Product.insertPdf();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            pnUpdateProduct.Visible = true;
            pnShowInventory.Visible = false;
            pnEditProfile.Visible = false;
            pnCreateProduct.Visible = false;
            pnCreateNewUser.Visible = false;

        }
        
        private void btnShowInventory_Click(object sender, EventArgs e)
        {
            pnShowInventory.Visible = true;
            pnEditProfile.Visible= false;
            pnCreateProduct.Visible= false;
            pnCreateNewUser.Visible = false;
            pnUpdateProduct.Visible = false;

            //DataTable dataTable = getProduct.Tables[0];
            dgvViewproduct.DataSource = Product.showInventory(dbconnection, query).Tables[0];
        }


        
        private void btnsearchIndex_Click(object sender, EventArgs e)
        {
            if (tbEnterIndex.Text == "") 
            {
                MessageBox.Show("Please Enter an index");
            }
            else
            {
                DataTable getproductTable = Product.checkProduct(dbconnection , query, Convert.ToInt16(tbEnterIndex.Text));
                //the product.checkproduct method is used to search the product id that was entered.

                Product currentProduct = Product.displayCurrentProduct(getproductTable);
                //using the contents stored in the getproductTable, The product information is extracted from the database and stored in a Product object so they can be displayed

                lbcurrentId.Text = $"Id: {Convert.ToString(currentProduct.Id)}";
                tbNewProductName.Text = currentProduct.Name;
                rtNewDescription.Text = currentProduct.Description;
                tbNewProductSoftware.Text = currentProduct.TypeOfSoftware;
                tbNewBusinessArea.Text = currentProduct.BusinessArea;
                //tbnewpdf = currentProduct.PDF;
                tbNewURL.Text = currentProduct.Link;
              


                //Product currentProduct = new Product(Product.currentProductId, Product.currentProductName, Product.currentProductDescription, Product.currentProductTypeOfSoftware, Product.currentProductBusinessArea, Product.currentProductPDF, Product.currentProductURL);
                //currentProduct.checkProduct(query ,Convert.ToInt16(tbEnterIndex.Text));
            }
        }

        private void tbsearchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAttachNewPDF_Click(object sender, EventArgs e)
        {
            lbNewfilepath.Text = Product.insertPdf();
        }

        private void btnChangeProduct_Click(object sender, EventArgs e)
        {

            Product.changeCurrentProduct(dbconnection, query, Convert.ToInt16(lbcurrentId.Text), tbNewProductName.Text , rtNewDescription.Text , tbNewProductSoftware.Text , tbNewBusinessArea.Text , File.ReadAllBytes(lbNewfilepath.Text) , tbNewURL.Text);


        }



        //logout
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();             
        }


        
        //User creation and role assignment
        private void btnCreateNewUser_Click(object sender, EventArgs e)
        { 
             pnCreateNewUser.Visible = true;
             pnCreateProduct.Visible = false;
             pnEditProfile.Visible = false;
             pnShowInventory.Visible = false;
            pnUpdateProduct.Visible = false;

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

       
    }
}
