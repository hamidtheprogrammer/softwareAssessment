using System;
using System.Collections;
using System.Collections.Generic;
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

    }
}
