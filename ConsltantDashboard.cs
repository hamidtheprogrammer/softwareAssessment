using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace soft
{
    public partial class ConsltantDashboard : Form
    {

        private Rectangle btnAddProductOriginalRect;

        private Size formOriginalSize;

        //TIMER

        private Timer _timer;
        public ConsltantDashboard()
        {
            InitializeComponent();

            // Initialize the timer
            _timer = new Timer();
            _timer.Interval = 1000; // Set the interval to 1000 milliseconds (1 second)
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the label with the current date and time
            lbTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }


        //OBJECTS

        Consultant currentConsultant = new Consultant(Login.Id, Login.currentUserName , Login.currentUserEmail, Login.currentUserPassword);
        //create instance for the logged in consultant

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


        


        //PANELS

        public void panelLoadDashboard()
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
        }
        public void panelEditProfile()
        {
            pnEditProfile.Visible = true;
            pnAddCompany.Visible = false;
            pnCreateProduct.Visible = false;
            pnShowInventory.Visible = false;
            pnCreateNewUser.Visible = false;
            pnUpdateProduct.Visible = false;
            pnShowCompanies.Visible = false;
            pnUpdateCompany.Visible = false;
            pnDashboard.Visible = false;
        }

        public void panelCreateProduct()
        {
            pnCreateProduct.Visible = true;
            pnAddCompany.Visible = false;
            pnEditProfile.Visible = false;
            pnShowInventory.Visible = false;
            pnCreateNewUser.Visible = false;
            pnUpdateProduct.Visible = false;
            pnShowCompanies.Visible = false;
            pnUpdateCompany.Visible = false;
            pnDashboard.Visible = false;
            pnMergeProductCompany.Visible = false;
        }

        public void panelAddCompany()
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
        }

        public void panelShowInventory()
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
        }

        public void panelUpdateProduct()
        {
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
        }

        public void panelMergeCompanyProduct()
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
        }

        public void panelShowCompanies()
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
        }

        public void panelUpdateCompanies()
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
        }

        public void panelCreateNewUser()
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
        }

       



        //welcome User
        private void ConsltantDashboard_Load(object sender, EventArgs e)
        {
            panelLoadDashboard();
            lbwelcome.Text = "Welcome Hamid"+currentConsultant.Name;

            dgvAllProducts();
            productCounter();
            lbpdfHolder.Visible = false;
            btnCreateNewUser.Visible = false;


            formOriginalSize = this.Size;
            btnAddProductOriginalRect = new Rectangle(btnAddProduct.Location.X,btnAddProduct.Location.Y,btnAddProduct.Width,btnAddProduct.Height);

        }

        private void resizeChildrenControls()
        {
            resizeControl(btnAddProductOriginalRect, btnAddProduct);
        }

        private void resizeControl(Rectangle OriginalControlRect, Control control)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);

            int newX = (int)(OriginalControlRect.X * xRatio);
            int newY = (int)(OriginalControlRect.Y * yRatio);

            int newWidth = (int)(OriginalControlRect.Width * xRatio);
            int newHeight = (int)(OriginalControlRect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }
        
        private void AdminDashboard_Resize(object sender, EventArgs e)
        {
           

        }
        

       


        //FUNCTIONS



        //Load Dashboard function
        public void loadDashBoard()
        {
            panelLoadDashboard();
            dgvAllProducts();
            productCounter();
        }



        //Consultant Account functions


        private void displayConsultantAccount()
        {   //display Counsultant account details function
            panelEditProfile();
            tbnewUserName.Text = currentConsultant.Name;
            tbNewEmail.Text = currentConsultant.Email;
            tbnewPassword.Text = currentConsultant.Password;
        }
        private void updateConsultantAccount()
        {
            //update Consultant account function
            //the newly added credentials are stored in a variable
            string newCurrentUserName = tbnewUserName.Text;
            string newCurrentUserEmail = tbNewEmail.Text;
            string newCurrentUserPassword = tbnewPassword.Text;

            //credentials are passed into a method that tellse the dbconnection class to update the account in the database using the specified Id 
            currentConsultant.updateConsultant(query, currentConsultant.ID, newCurrentUserName, newCurrentUserEmail, newCurrentUserPassword);

            tbnewUserName.Text = newCurrentUserName;
            tbNewEmail.Text = newCurrentUserEmail;
            tbnewPassword.Text = newCurrentUserPassword;

            lbwelcome.Text = "Welcome " + newCurrentUserName;
        }


        //product functions

        //Adding a product
        private void insertPdf()
        {   //insert pdf and store the filepath on a label
            lbfilePath.Text = Product.insertPdf();
        }
        private void includePdf()
        {   //message to prompt user to include a pdf when adding a new product
            MessageBox.Show("Must Include a PDF file attached");
        }
        private void AddProduct()
        {// Add Product to record
            if (tbProductName.Text == "") {
                MessageBox.Show("Product must have a name");
            }
            try
            {   //filepath stored in label is stored in a pdf variable for the contents of the file to be extracted
                byte[] pdf = File.ReadAllBytes(lbfilePath.Text);
                //new product object created
                product = new Product(1, tbProductName.Text, rtbDescription.Text, tbProductSoftware.Text, tbBusinessArea.Text, pdf, tbUrl.Text);
                //Method is called to add pass inputted product information to be further passed into the dbconnection class where queries are finally used to store in the database
                product.addProduct(query, product);
                //prompt user to ask  if they would like to add a company information to the added product.
                DialogResult addCompany = MessageBox.Show("Product added successfully\nWould you like to Enter a Company information for this product", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if user clicks wishes to....
                if (addCompany == DialogResult.Yes)
                {   //company panel is displayed 
                    panelAddCompany();
                    pnMergeProductCompany.Visible = false;
                }

            }//exception caught incase user does not include a PDF file.
            catch (System.IO.FileNotFoundException)
            {
                includePdf();
            }
            catch (System.ArgumentException)
            {
                includePdf();
            }
        }

        //retrieve all products
        public void dgvAllProducts()
        {  
            dgvViewproduct.DataSource = Product.showInventory(dbconnection, query).Tables[0];
        }

        //Show product Inventory
        private void showProductInventory()
        {   //Product Inventory panel is displayed
            panelShowInventory();
            //All products added are displayed in a datagridview
            dgvAllProducts();
        }

        //click a product
        private void clickProduct(int row)
        {   //a datarowview object is created to extract the product info that has been clicked
            DataRowView clicked_row = (DataRowView)dgvViewproduct.Rows[row].DataBoundItem;

            //foreign key of the clicked product that contains the company info for the product is stored in a non-visible label
            ForeignKey.Text = clicked_row["CompanyId"].ToString();

            //panel is displayed to expand clicked product details
            panelUpdateProduct();

            //the products info are displayed in fields
            clickedProductId.Text = Convert.ToString(clicked_row["Id"]);
            tbNewProductName.Text = clicked_row["Name"].ToString();
            rtNewDescription.Text = clicked_row["Description"].ToString();
            tbNewProductSoftware.Text = clicked_row["Type_Of_Software"].ToString();
            tbNewBusinessArea.Text = clicked_row["Business_Area"].ToString();
            lbpdfHolder.Text = clicked_row["PDF"].ToString();
            tbNewURL.Text = clicked_row["Link"].ToString();
            lnkProductURL.Text = "Click to open link";
            clickedProductId.Visible = false;//the Id of the clicked product is made non-visible to the user.

            //if foreign key of product is nulled, then the product does not have a company information, therefore , button is displayed to add company info for product.
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
            {   //else if product contains foreign key, buttons to view company info or delete company info are made visible. 
                btnViewCompanyInfo.Visible = true;
                btnDeleteCompanyInfo.Visible = true;
                btnlinkProduct.Visible = false;
                lbdeletecompanyInfo.Visible = true;
                lbviewcompanyInfo.Visible = true;
                lbLinkProduct.Visible = false;

            }
        }


        //update a product

        //change pdf
        private void changePdf()
        {
            lbNewfilepath.Text = Product.insertPdf();
            lbpdfHolder.Text = System.Text.Encoding.UTF8.GetString(File.ReadAllBytes(lbNewfilepath.Text));
        }

        //update product
        private void changeProductDetails()
        {
            try
            {   //updated product details in fields are sent to backend classes to be applied in the database
                Product.changeCurrentProduct(dbconnection, query, Convert.ToInt16(clickedProductId.Text), tbNewProductName.Text, rtNewDescription.Text, tbNewProductSoftware.Text, tbNewBusinessArea.Text, Encoding.UTF8.GetBytes(lbpdfHolder.Text), tbNewURL.Text);
            }
            catch (System.IO.FileNotFoundException)
            {
                includePdf();
            }
            catch (System.ArgumentException)
            {
                includePdf();
            }
        }

        //the method below displays all company info to allow the user to select a company to link an exiting product.
        //this allows when a new product in which the company for this product already exists in the database, rather.....
        //than rewriting the company info  for the newly added product, the product can be linked to the existing company instead.
        private void linkcompanyinfo()
        {   //panel to show all companies is displayed
            panelMergeCompanyProduct();
            //all companies are displayed in the datagridview by calling method containing query from backend
            dgvMergeCompanyProduct.DataSource = Company.displayCompanies(dbconnection, query).Tables[0];
        }

        //the method below links the selected company with the product been updated
        private void mergeCompanyWithProduct(int row)
        {   //extract infor of clicked comapny
            DataRowView clicked_row = (DataRowView)dgvMergeCompanyProduct.Rows[row].DataBoundItem;
            //record the Id to be used as a foreign key
            int keyFromCompany = Convert.ToInt16(clicked_row.Row["Id"].ToString());
            string nameFromCompany = clicked_row.Row["Company_Name"].ToString();
            //message box to confirm linkage
            DialogResult sure = MessageBox.Show($"Would you like to link product with '{nameFromCompany}' company", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (sure == DialogResult.Yes)
            {   //function called to pass foreign key and store in selected product's foreignkey column
                Product.changeCurrentProduct(dbconnection, query, Convert.ToInt16(clickedProductId.Text), keyFromCompany);
            }
        }

        //delete company info for a particular product
        private void deleteCompanyInfo()
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete the company information for this product\n The company information will remain for other linked product.Confirm?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {   //Checks the foreign key and deletes for selected prodduct
                Product.deletefromProduct(dbconnection, query, Convert.ToInt16(clickedProductId.Text));
            }
        }

        //delete product
        private void deleteProduct()
        {   //message box asks user to confirm deletion
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirm == DialogResult.Yes)
            {   //product Id passed to backend class containing query function to delete the product
                Product.deleteproduct(dbconnection, query, Convert.ToInt16(clickedProductId.Text));
                MessageBox.Show("Product deleted");

                showProductInventory();
                //show product inventory after deletion
            }
        }
        
        //search product
        public void searchProduct()
        {
            if (tbsearchBox.Text != "" && tbsearchBox.Text != "search vendor products")
            {
                panelShowInventory();//show product inventory panel

                dgvViewproduct.DataSource =  Product.searchProduct(dbconnection, query, tbsearchBox.Text).Tables[0];//fill tables with product matching searched criteria
            }
        }

        //product counter
        public void productCounter()
        {
            int countProduct = dgvViewproduct.Rows.Count - 1;
            lbproductCount.Text = $"{countProduct.ToString()} product added";
        }


        //company functions

        //adding new company info to new product
        public void addCompanyInfoToProduct()
        { 
            if (tbCompanyName.Text == "")
            {
                MessageBox.Show("must Include company");
            }
            else
            {
              //object of company created and text fields are passed to be stored in the database.
                company = new Company(1, tbCompanyName.Text, tbCompanyContact.Text, tbCompanyWeb.Text, tbEstablishedDate.Text, tbCountries.Text, tbCities.Text, tbAddresses.Text);
                company.addCompany(query, company);

                //the company id is also recorded and stored as a foreign key for selected product
                int companyId = company.getCompany(query);

                Product.changeCurrentProduct(dbconnection, query, companyId);
            } 
           
        }

        //viewing the company information for a product
        public void viewCompanyInfo()
        {
            panelShowCompanies();//company information panel
            DataSet companyInventory = dbconnection.getDataSet(query.getCompanyWithForeignKey(Convert.ToInt16(clickedProductId.Text)));
            DataTable companydata = companyInventory.Tables[0];
            //the datagridview is populated with the company details for selected product
            dgvShowCompanies.DataSource = companydata;
        }
        
        //click a company
        public void clickCompany(int row)
        {
            panelUpdateCompanies();//panel to update company 

            DataRowView clickedrow = (DataRowView)dgvShowCompanies.Rows[row].DataBoundItem;

            //clciked company information is expanded for edits or viewing
            lbNewCompanyId.Text = Convert.ToString(clickedrow["Id"]);
            tbNewCompanyName.Text = clickedrow["Company_Name"].ToString();
            tbNewCompanyContact.Text = clickedrow["Contact"].ToString();
            tbNewWebsite.Text = clickedrow["Website"].ToString();
            tbNewCompanyEstablishedDate.Text = clickedrow["Established_Date"].ToString();
            tbNewCompanyLocationCountries.Text = clickedrow["Location_Countries"].ToString();
            tbNewCompanyLocationCities.Text = clickedrow["Location_Cities"].ToString();
            tbNewCompanyAddresses.Text = clickedrow["Addresses"].ToString();
        }

        //update a Company
        public void updateCompaany()
        {   //text field details are recorded into an object to be updated in the database with specified Id
            Company newCompany = new Company(Convert.ToInt16(lbNewCompanyId.Text), tbNewCompanyName.Text, tbNewCompanyContact.Text, tbNewWebsite.Text, tbNewCompanyEstablishedDate.Text, tbNewCompanyLocationCountries.Text, tbNewCompanyLocationCities.Text, tbNewCompanyAddresses.Text);
            newCompany.addCompany(dbconnection, query, newCompany, newCompany.Id);
        }

        //show all products under a selected company
        public void showProductsForCompany()
        {   
            panelShowInventory();
            //all products containg selected company's foreign key are displayed
            dgvViewproduct.DataSource = Product.showInventory(dbconnection, query, Convert.ToInt16(lbNewCompanyId.Text)).Tables[0];
        }







        //FORMS
        
        
        //dashboard form
        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            loadDashBoard();
        }


        //Consultant account in forms


        //display profile
        private void btnEditProfile_Click(object sender, EventArgs e)
        {   //display Consultant account
            displayConsultantAccount();
        }
        //update profile
        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {   //update Consultant Account
            updateConsultantAccount();
        }



        //Product info in forms


        //adding a product

        //create Product
        private void btnCreateProduct_Click(object sender, EventArgs e)
        {   //shows panel to add product
           panelCreateProduct();
        }
        //add PDF file
        private void btnSavePdf_Click(object sender, EventArgs e)
        {   //allows user to insert Pdf 
            insertPdf();
        }
        //save the product
        private void btnAddProduct_Click(object sender, EventArgs e)
        {   //Allow user to add product after details have been added
            AddProduct();
        }

 
        //display product Inventory and view their info in forms

        //Inventory
        private void btnShowInventory_Click(object sender, EventArgs e)
        {
            showProductInventory();
        }
        //click product
        private void dgvViewproduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {   //when user clicks a product, the product info is expanded which can be later updated or deleted.

            try { 
                if (e.RowIndex >= 0 && e.ColumnIndex>= 0)
                {
                    clickProduct(e.RowIndex);
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("cell is empty");
            }
            
        }

       
        //Update product in forms

        //open PDF
        private void btnOpenPdf_Click(object sender, EventArgs e)                                                                                                       //NOT COMPLETED
        {
            //The contents of the PDF file previously stored as varchar in the database is extracted ...
            //into an invisible label and then stored in a pdf string
            byte[] pdf = (byte[])System.Text.Encoding.UTF8.GetBytes(lbpdfHolder.Text);
            //webBrowser is made visible
            
            //webBrowser1.DocumentText = $"<html><body><embed type='application/pdf' width='100%' height='100%' src='data:application/pdf;base64,{pdf}'></embed></body></html>"; 
            string pdfFilePath = Path.GetTempFileName() + ".pdf";
            File.WriteAllBytes(pdfFilePath, pdf);
            System.Diagnostics.Process.Start(pdfFilePath);
        }

        //open URL
        private void lnkProductURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(tbNewURL.Text.ToString());
        }                                   

        //update product details
        private void btnChangeProduct_Click(object sender, EventArgs e)
        {  
           changeProductDetails();
        }
        
        //update pdf
        private void btnAttachNewPDF_Click(object sender, EventArgs e)
        {  
           changePdf();
        }
       
        //delete company info for clicked product
        private void btnDeleteCompanyInfo_Click(object sender, EventArgs e)
        {
            deleteCompanyInfo();
        }
       
        //delete selected product
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            deleteProduct(); 
        }

        //display companies to link product
        private void btnlinkProduct_Click(object sender, EventArgs e)
        {
           linkcompanyinfo();
        }

        //link product to a company
        private void dgvMergeCompanyProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                mergeCompanyWithProduct(e.RowIndex);
            }
        }
       
        //click search button to search item
        private void pnImgsearchProduct_MouseClick(object sender, MouseEventArgs e)
        {
            searchProduct();
        }

        //remove place holder in search box
        private void tbsearchBox_MouseClick(object sender, MouseEventArgs e)
        {
            tbsearchBox.Text = "";
        }

        //allows enter on keyboard to execute command
        private void tbsearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                searchProduct();
            }
        }


        //company info in forms

        //adding new company for a new product
        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            addCompanyInfoToProduct();
            
        }

        //view company info for selected product in forms
        private void btnViewCompanyInfo_Click(object sender, EventArgs e)
        {
           viewCompanyInfo();
        }

       
        //show company details
        private void dgvShowCompanies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCompany(e.RowIndex);
        }

        //update company
        private void btnUpdateCompany_Click(object sender, EventArgs e)
        {
            updateCompaany();
        }

        //show all products offered by company
        private void btnshowAllRelatedProducts_Click(object sender, EventArgs e)
        {
            showProductsForCompany();
        }


        //Back Trackers

        private void btnreturnUpdateCompany_Click(object sender, EventArgs e)
        {
            panelShowCompanies();
        }

        private void btnReturnCompanyinventory_Click(object sender, EventArgs e)
        {
            panelUpdateProduct();
        }

        private void btnReturnUpdateProduct_Click(object sender, EventArgs e)
        {
            panelShowInventory();
            dgvAllProducts();
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
            panelCreateNewUser();
            
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
