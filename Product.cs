using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void addProduct(Queries query, Product product)
        {
            dbconnection.saveProductToDb(query.saveProductToDb(), product.Name, product.Description, product.TypeOfSoftware, product.BusinessArea, product.PDF, product.Link);

            login.messagePrompt("Product added successfully");

        }

        public Product viewProduct(Queries query,int index)
        {
            DataSet getproduct = dbconnection.getDataSet(query.getSpecificProduct(index));
            DataTable getProductTable = getproduct.Tables[0];
            if( getProductTable.Rows.Count == 1 ) 
            {
                int Id = Convert.ToInt16(getProductTable.Rows[0]["Id"]);
                string productName = getProductTable.Rows[0]["Name"].ToString();
                string productDescription = getProductTable.Rows[0]["Description"].ToString();
                string productTypeOfSoftware = getProductTable.Rows[0]["Type_Of_Software"].ToString();
                string productBusinessArea = getProductTable.Rows[0]["Business_Area"].ToString();
                byte[] productPDF = Convert.ToByte(getProductTable.Rows[0]["PDF"]);              
                string productURL = getProductTable.Rows[0]["Link"].ToString();

                Product product = new Product(Id, productName, productDescription, productTypeOfSoftware, productBusinessArea, productPDF, productURL );

                return product;
                
            }
        }

    }
}
