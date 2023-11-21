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

namespace soft
{
    public class Product
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }
        public string TypeOfSoftware {  get; set; }
        public string BusinessArea {  get; set; }
        public byte[] PDF {  get; set; }
        public string Link {  get; set; }

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();
        Login login = new Login();

        public Product( int id, string name, string description, string typeOfsoftware, string businessArea, byte[] pdf, string link)
        {
            Id = id;
            Name = name;
            Description = description;
            TypeOfSoftware = typeOfsoftware;
            BusinessArea = businessArea;
            PDF = pdf;
            Link = link;
        }

        public static string insertPdf()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {   //openfiledialog object

                openFileDialog.Filter = "PDF Files |*.pdf";
                //filter for pdf files

                openFileDialog.Title = "Please select a PDF file for attachment";
                //tell user to select a PDF file

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                //verify correct PDF file
                {
                    string filePath = openFileDialog.FileName;

                    return filePath;
                }
                else
                {
                    return null;
                }
            }
        }
        public void addProduct(Queries query, Product product)
        {
            dbconnection.saveProductToDb(query.saveProductToDb(), product.Name, product.Description, product.TypeOfSoftware, product.BusinessArea, product.PDF, product.Link);
        }

        public static DataSet showInventory(DBconnection dbconnection, Queries query)
        {   //an object of DBconnection is used as a parameter because the method is static, therefore, the previously instantiated DBconnection method cannot be accessed.
            DataSet getProduct = dbconnection.getDataSet(query.getProductFromDb());
            return getProduct;
        }

        //overloaded method to view particular company related product
        public static DataSet showInventory(DBconnection dbconnection, Queries query, int Id)
        {   
            DataSet getProduct = dbconnection.getDataSet(query.getProductRelatedToCompany(Id));
            return getProduct;
        }




        public static int currentProductId;
        public static string currentProductName;
        public static string currentProductDescription;
        public static string currentProductTypeOfSoftware;
        public static string currentProductBusinessArea;
        public static byte[] currentProductPDF;
        public static string currentProductURL;

        public static Product displayCurrentProduct(DataRowView dataRowView)
        {
            currentProductId = Convert.ToInt16(dataRowView["Id"]);
            currentProductName = dataRowView["Name"].ToString();
            currentProductDescription= dataRowView["Description"].ToString();
            currentProductTypeOfSoftware = dataRowView["Type_Of_Software"].ToString();
            currentProductBusinessArea = dataRowView["Business_Area"].ToString();
            //currentProductPDF = dataRowView
            currentProductURL = dataRowView["Link"].ToString();

            Product clicked_product = new Product(currentProductId, currentProductName, currentProductDescription, currentProductTypeOfSoftware,currentProductBusinessArea, currentProductPDF, currentProductURL);

            return clicked_product;
        }

        public static void changeCurrentProduct(DBconnection dbconnection, Queries query, int id, string name, string description, string typeOfsoftware, string businessArea, byte[] pdf, string link)
        {
            dbconnection.saveProductToDb(query.updateProduct(id), name, description, typeOfsoftware, businessArea, pdf, link);
            Login.messagePrompt("Product successfully updated");
           
        }


        //overloaded method to pass foreign key to dbconnection class
        public static void changeCurrentProduct(DBconnection dbconnection, Queries query,  int foreignKey)
        {
            dbconnection.saveProductToDb(query.addForeignKeyToNewlyAddedProduct(), foreignKey);
        }

        //overloaded method to delete foreign key
        public static void deletefromProduct(DBconnection dbconnection, Queries query, int Id)
        {
            dbconnection.saveProductToDb(query.removeForeignKey(Id));
        }

        //overloaded method to store foreign key
        public static void changeCurrentProduct(DBconnection dbconnection, Queries query, int id, int foreignKey)
        {
            dbconnection.saveProductToDb(query.updateProduct(id, foreignKey),foreignKey);
        }

        public static DataSet searchProduct(DBconnection dbconnection, Queries query, string name)
        {
            return dbconnection.getDataSet(query.searchProduct(name));
        }
        //delete product
        public static void deleteproduct(DBconnection dbconnection, Queries query, int Id)
        {
            dbconnection.saveProductToDb(query.deleteProduct(Id));
        }



    }
}
