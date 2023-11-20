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
using System.Drawing.Text;

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

        Company company;
        //object of Company class

        
        //welcome User
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            pnDashboard.Visible = true;
            pnEditProfile.Visible = false;
            pnAddCompany.Visible = false;
            pnCreateProduct.Visible = false;
            pnShowInventory.Visible = false;
            pnCreateNewUser.Visible = false;
            pnUpdateProduct.Visible = false;
            pnShowCompanies.Visible = false;
            pnUpdateCompany.Visible = false;
            pnMergeProductCompany.Visible = false;
            lbwelcome.Text = "Welcome "+currentAdmin.Name;
            
        }



        //admin account
        private void btnEditProfile_Click(object sender, EventArgs e)
        {   //display admin account details
            pnEditProfile.Visible = true;
            pnAddCompany.Visible = false;
            pnCreateProduct.Visible = false;
            pnShowInventory.Visible = false;
            pnCreateNewUser.Visible = false;
            pnUpdateProduct.Visible = false;
            pnShowCompanies.Visible = false;
            pnUpdateCompany.Visible = false;
            pnDashboard.Visible = false;
            pnMergeProductCompany.Visible = false;
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
            pnAddCompany.Visible = false;
            pnEditProfile.Visible= false;
            pnShowInventory.Visible= false;
            pnCreateNewUser.Visible = false;
            pnUpdateProduct.Visible = false;
            pnShowCompanies.Visible = false;
            pnUpdateCompany.Visible = false;
            pnDashboard.Visible = false;
            pnMergeProductCompany.Visible = false;
        }
        private void includePdf()
        {
            MessageBox.Show("Must Include a PDF file attached");
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            

            try{ 
                byte[] pdf = File.ReadAllBytes(lbfilePath.Text);

                product = new Product(1, tbProductName.Text, rtbDescription.Text, tbProductSoftware.Text, tbBusinessArea.Text, pdf, tbUrl.Text);
                //new product object

                product.addProduct(query, product);

                DialogResult addCompany = MessageBox.Show("Product added successfully\nWould you like to Enter a Company information for this product", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (addCompany == DialogResult.Yes)
                {
                    pnAddCompany.Visible = true;
                    pnEditProfile.Visible = false;
                    pnCreateProduct.Visible = false;
                    pnShowInventory.Visible = false;
                    pnCreateNewUser.Visible = false;
                    pnUpdateProduct.Visible = false;
                    pnShowCompanies.Visible = false;
                    pnUpdateCompany.Visible = false;
                    pnDashboard.Visible = false;
                    pnMergeProductCompany.Visible = false;
                }
                
            }
            catch (System.IO.FileNotFoundException)
            {
                includePdf();
            }
            catch(System.ArgumentException)
            {
                includePdf();
            }
        }

        private void btnSavePdf_Click(object sender, EventArgs e)
        {
            lbfilePath.Text = Product.insertPdf();
        }

        
        
        private void btnShowInventory_Click(object sender, EventArgs e)
        {
            pnShowInventory.Visible = true;
            pnAddCompany.Visible = false;
            pnEditProfile.Visible= false;
            pnCreateProduct.Visible= false;
            pnCreateNewUser.Visible = false;
            pnUpdateProduct.Visible = false;
            pnShowCompanies.Visible = false;
            pnUpdateCompany.Visible = false;
            pnDashboard.Visible = false;
            pnMergeProductCompany.Visible = false;

            //DataTable dataTable = getProduct.Tables[0];
            dgvViewproduct.DataSource = Product.showInventory(dbconnection, query).Tables[0];
        }

        private void dgvViewproduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex>= 0)
            {
                DataRowView clicked_row = (DataRowView)dgvViewproduct.Rows[e.RowIndex].DataBoundItem;
                 ForeignKey.Text = clicked_row["CompanyId"].ToString();

                pnUpdateProduct.Visible = true;
                pnAddCompany.Visible = false;
                pnShowInventory.Visible = false;
                pnEditProfile.Visible = false;
                pnCreateProduct.Visible = false;
                pnCreateNewUser.Visible = false;
                pnShowCompanies.Visible = false;
                pnUpdateCompany.Visible = false;
                pnDashboard.Visible = false;
                pnMergeProductCompany.Visible = false;

                Product clicked_Product = Product.displayCurrentProduct(clicked_row);

                clickedProductId.Text = Convert.ToString(clicked_Product.Id);
                tbNewProductName.Text = clicked_Product.Name;
                rtNewDescription.Text = clicked_Product.Description;
                tbNewProductSoftware.Text = clicked_Product.TypeOfSoftware;
                tbNewBusinessArea.Text = clicked_Product.BusinessArea;
                //tbnewpdf = currentProduct.PDF;
                tbNewURL.Text = clicked_Product.Link;

                clickedProductId.Visible = false;
                if (ForeignKey.Text == "")
                {
                    btnViewCompanyInfo.Visible = false;
                    btnDeleteCompanyInfo.Visible = false;
                    btnlinkProduct.Visible = true;
                    lbdeletecompanyInfo.Visible = false;
                    lbviewcompanyInfo.Visible = false;
                    lbLinkProduct.Visible = true;
                   
                }
                else
                {
                    btnViewCompanyInfo.Visible = true;
                    btnDeleteCompanyInfo.Visible = true;
                    btnlinkProduct.Visible = false;
                    lbdeletecompanyInfo.Visible= true;
                    lbviewcompanyInfo.Visible = true;
                    lbLinkProduct.Visible = false;

                }

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
            Product.changeCurrentProduct(dbconnection, query, Convert.ToInt16(clickedProductId.Text), tbNewProductName.Text , rtNewDescription.Text , tbNewProductSoftware.Text , tbNewBusinessArea.Text , File.ReadAllBytes(lbNewfilepath.Text) , tbNewURL.Text);
        }

        private void btnDeleteCompanyInfo_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete the company information for this product\n The company information will remain for other linked product.Confirm?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {
                Product.deletefromProduct(dbconnection, query, Convert.ToInt16(clickedProductId.Text));
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {
                Product.deleteproduct(dbconnection, query, Convert.ToInt16(clickedProductId.Text));
                MessageBox.Show("Product deleted");

                pnShowInventory.Visible = true;
                pnAddCompany.Visible = false;
                pnEditProfile.Visible = false;
                pnCreateProduct.Visible = false;
                pnCreateNewUser.Visible = false;
                pnUpdateProduct.Visible = false;
                pnShowCompanies.Visible = false;
                pnUpdateCompany.Visible = false;
                pnDashboard.Visible = false;
                pnMergeProductCompany.Visible = false;

            }
            
        }
        private void btnlinkProduct_Click(object sender, EventArgs e)
        {
            pnCreateNewUser.Visible = false;
            pnAddCompany.Visible = false;
            pnCreateProduct.Visible = false;
            pnEditProfile.Visible = false;
            pnShowInventory.Visible = false;
            pnUpdateProduct.Visible = false;
            pnShowCompanies.Visible = false;
            pnUpdateCompany.Visible = false;
            pnDashboard.Visible = false;
            pnMergeProductCompany.Visible = true;

            dgvMergeCompanyProduct.DataSource = Company.displayCompanies(dbconnection, query).Tables[0];
        }

        public void searchProduct()
        {
            if (tbsearchBox.Text != null && tbsearchBox.Text != "search vendor products")
            {
                pnShowInventory.Visible = true;
                pnAddCompany.Visible = false;
                pnEditProfile.Visible = false;
                pnCreateProduct.Visible = false;
                pnCreateNewUser.Visible = false;
                pnUpdateProduct.Visible = false;
                pnShowCompanies.Visible = false;
                pnUpdateCompany.Visible = false;
                pnDashboard.Visible = false;
                pnMergeProductCompany.Visible = false;

                //DataTable dataTable = getProduct.Tables[0];
                

                dgvViewproduct.DataSource =  Product.searchProduct(dbconnection, query, tbsearchBox.Text);
            }
        }

        private void pnImgsearchProduct_MouseClick(object sender, MouseEventArgs e)
        {
            searchProduct();
        }



        //company info
        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            company = new Company(1,tbCompanyName.Text, tbCompanyContact.Text , tbCompanyWeb.Text, tbEstablishedDate.Text, tbCountries.Text, tbCities.Text, tbAddresses.Text);
            company.addCompany(query , company);

            int companyId = company.getCompany(query);

            Product.changeCurrentProduct(dbconnection, query, companyId);
        }

        private void btnViewCompanyInfo_Click(object sender, EventArgs e)
        {
            pnUpdateProduct.Visible = false;
            pnAddCompany.Visible = false;
            pnShowInventory.Visible = false;
            pnEditProfile.Visible = false;
            pnCreateProduct.Visible = false;
            pnCreateNewUser.Visible = false;
            pnShowCompanies.Visible = true;
            pnUpdateCompany.Visible = false;
            pnDashboard.Visible = false;
            pnMergeProductCompany.Visible = false;

            DataSet companyInventory = dbconnection.getDataSet(query.getCompanyWithForeignKey(Convert.ToInt16(clickedProductId.Text)));
            DataTable companydata = companyInventory.Tables[0];
            dgvShowCompanies.DataSource = companydata;
        }

        private void dgvShowCompanies_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pnUpdateCompany.Visible = true;
            pnUpdateProduct.Visible = false;
            pnAddCompany.Visible = false;
            pnShowInventory.Visible = false;
            pnEditProfile.Visible = false;
            pnCreateProduct.Visible = false;
            pnCreateNewUser.Visible = false;
            pnShowCompanies.Visible = false;
            pnDashboard.Visible = false;
            pnMergeProductCompany.Visible = false;

            DataRowView clickedrow = (DataRowView)dgvShowCompanies.Rows[e.RowIndex].DataBoundItem;

            Company clickedCompany = Company.displayclicked_company(clickedrow);
            lbNewCompanyId.Text = Convert.ToString(clickedCompany.Id);
            tbNewCompanyName.Text = clickedCompany.CompanyName;
            tbNewCompanyContact.Text = clickedCompany.Contact;
            tbNewWebsite.Text = clickedCompany.Website;
            tbNewCompanyEstablishedDate.Text = clickedCompany.EstablishedDate;
            tbNewCompanyLocationCountries.Text = clickedCompany.LocationCountries;
            tbNewCompanyLocationCities.Text = clickedCompany.LocationCities;
            tbNewCompanyAddresses.Text = clickedCompany.Addresses;
        }

        private void btnUpdateCompany_Click(object sender, EventArgs e)
        {
            Company newCompany = new Company(Convert.ToInt16(lbNewCompanyId.Text), tbNewCompanyName.Text, tbNewCompanyContact.Text, tbNewWebsite.Text, tbNewCompanyEstablishedDate.Text, tbNewCompanyLocationCountries.Text, tbNewCompanyLocationCities.Text, tbNewCompanyAddresses.Text);
            newCompany.addCompany(dbconnection, query, newCompany, newCompany.Id);
        }

        private void dgvMergeCompanyProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataRowView clicked_row = (DataRowView)dgvMergeCompanyProduct.Rows[e.RowIndex].DataBoundItem;
                int keyFromCompany = Convert.ToInt16(clicked_row.Row["Id"].ToString());
                DialogResult sure = MessageBox.Show("Would you like to link product with {} company", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sure == DialogResult.Yes)
                {
                    Product.changeCurrentProduct(dbconnection, query, Convert.ToInt16(clickedProductId.Text), keyFromCompany);
                }
            }
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
            pnAddCompany.Visible = false;
            pnCreateProduct.Visible = false;
            pnEditProfile.Visible = false;
            pnShowInventory.Visible = false;
            pnUpdateProduct.Visible = false;
            pnShowCompanies.Visible = false;
            pnUpdateCompany.Visible = false;
            pnDashboard.Visible = false;
            pnMergeProductCompany.Visible = false;

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
