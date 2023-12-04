using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace soft
{
    public class Product
    {
        private int Id { get; set; }
        private string Name {  get; set; }
        private string Description {  get; set; }
        private string TypeOfSoftware {  get; set; }
        private string BusinessArea {  get; set; }
        private byte[] PDF {  get; set; }
        private string Link {  get; set; }

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();
        Login login = new Login();

        public Product( int id, string name, string description, string typeOfsoftware, string businessArea, byte[] pdf, string link)
        {
            Id = id; // Product Id
            Name = name; //product name
            Description = description; //product description
            TypeOfSoftware = typeOfsoftware; //type of software
            BusinessArea = businessArea; //business area of product
            PDF = pdf; //pdf 
            Link = link; //url to product
        }

        public static string insertPdf()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {   //openfiledialog object

                openFileDialog.Filter = "PDF Files |*.pdf";
                //filter for pdf files

                openFileDialog.Title = "Please select a PDF file for attachment";
                //prompting user to select a PDF file

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                //verify PDF file is correct
                {
                    string filePath = openFileDialog.FileName;
                    //store PDF file path

                    return filePath;
                    //return file pathy
                }
                else
                {
                    return null;
                    //return null if file path is invalid
                }
            }
        }
        //adding a product to database
        public void addProduct(Queries query, Product product)
        {
            dbconnection.saveProductToDb(query.saveProductToDb(), product.Name, product.Description, product.TypeOfSoftware, product.BusinessArea, product.PDF, product.Link);
            //dbconnection class called to input queries to store passed parameters in the database
        }

        public static DataSet showInventory(DBconnection dbconnection, Queries query)
        {   //an object of DBconnection is used as a parameter because the method is static, therefore,
            //the previously instantiated DBconnection method cannot be accessed.
            DataSet getProduct = dbconnection.getDataSet(query.getProductFromDb());
            //extraction of data from the database using queries, the data is stored into a dataset object.
            return getProduct;
            //object returned
        }

        //overloaded method to view particular company related product
        public static DataSet showInventory(DBconnection dbconnection, Queries query, int Id)
        {   
            DataSet getProduct = dbconnection.getDataSet(query.getProductRelatedToCompany(Id));
            //getting company info on a particular product by passing foreign key
            return getProduct;
        }

        public static void changeCurrentProduct(DBconnection dbconnection, Queries query, int id, string name, string description, string typeOfsoftware, string businessArea, byte[] pdf, string link)
        {   //Parameters are passed with queries to change a product information in the database
            dbconnection.saveProductToDb(query.updateProduct(id), name, description, typeOfsoftware, businessArea, pdf, link);
            Login.messagePrompt("Product successfully updated");
           
        }

        //overloaded method to pass foreign key to dbconnection class
        public static void changeCurrentProduct(DBconnection dbconnection, Queries query,  int foreignKey)
        {
            dbconnection.saveProductToDb(query.addForeignKeyToNewlyAddedProduct(), foreignKey);
            //adding company's primary key to newly added product as a foriegn key so they can be linked
        }
        
        //overloaded method to store foreign key
        public static void changeCurrentProduct(DBconnection dbconnection, Queries query, int id, int foreignKey)
        {
            dbconnection.saveProductToDb(query.updateProduct(id, foreignKey),foreignKey);
            //linking an existing product to a company by updating its foreign key column
        }
        
        //delete product
        public static void deleteproduct(DBconnection dbconnection, Queries query, int Id)
        {
            dbconnection.saveProductToDb(query.deleteProduct(Id));
        }

        // method to delete foreign key
        public static void deletefromProduct(DBconnection dbconnection, Queries query, int Id)
        {
            dbconnection.saveProductToDb(query.removeForeignKey(Id));
            //unlinking a product with a company by deleting foreign key
        }

       

        public static DataSet searchProduct(DBconnection dbconnection, Queries query, string name)
        {   //returns all product matching searched criteria
            DataSet matchedProducts =  dbconnection.getDataSet(query.searchProduct(name));
            return matchedProducts;
        }
       



    }
}
