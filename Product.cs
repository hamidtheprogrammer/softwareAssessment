using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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

            login.messagePrompt("Product added successfully");

        }

        public static DataSet showInventory(DBconnection dbconnection, Queries query)
        {   //an object of DBconnection is used as a parameter because the method is static, therefore, the previously instantiated DBconnection method cannot be accessed.
            DataSet getProduct = dbconnection.getDataSet(query.getProductFromDb());
            return getProduct;
        }

        


        public static int currentProductId;
        public static string currentProductName;
        public static string currentProductDescription;
        public static string currentProductTypeOfSoftware;
        public static string currentProductBusinessArea;
        public static byte[] currentProductPDF;
        public static string currentProductURL;

        public static DataTable checkProduct(DBconnection dbconnection, Queries query, int index)
        {
            DataSet getproduct = dbconnection.getDataSet(query.getSpecificProduct(index));
            DataTable getProductTable = getproduct.Tables[0]; 

            return getProductTable;
        }

        public static Product displayCurrentProduct(DataTable getProductTable) { 

            if (getProductTable.Rows.Count == 1)
            {
                currentProductId = Convert.ToInt16(getProductTable.Rows[0]["Id"]);
                currentProductName = getProductTable.Rows[0]["Name"].ToString();
                currentProductDescription = getProductTable.Rows[0]["Description"].ToString();
                currentProductTypeOfSoftware = getProductTable.Rows[0]["Type_Of_Software"].ToString();
                currentProductBusinessArea = getProductTable.Rows[0]["Business_Area"].ToString();
                //currentProductPDF = File.ReadAllBytes(Convert.ToString((getProductTable.Rows[0]["PDF"])));
                currentProductURL = getProductTable.Rows[0]["Link"].ToString();
                Product currentProduct = new Product(currentProductId,currentProductName, currentProductDescription, currentProductTypeOfSoftware, currentProductBusinessArea, currentProductPDF,currentProductURL);
                return currentProduct;
            }
            else
            {
                MessageBox.Show("No result found");
                return null;
            }


        }

        public static void changeCurrentProduct(DBconnection dbconnection, Queries query, int id, string name, string description, string typeOfsoftware, string businessArea, byte[] pdf, string link)
        {
            dbconnection.saveProductToDb(query.updateProduct(id), name, description, typeOfsoftware, businessArea, pdf, link);
            MessageBox.Show("Product successfully updated");
           
        }

    }
}
