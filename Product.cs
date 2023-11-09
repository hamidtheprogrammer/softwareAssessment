using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soft
{
    public class Product
    {
        public string Name {  get; set; }
        public string Description {  get; set; }
        public string TypeOfSoftware {  get; set; }
        public string BusinessArea {  get; set; }
        public byte[] PDF {  get; set; }
        public string Link {  get; set; }

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();

        public Product( string name, string description, string typeOfsoftware, string businessArea, byte[] pdf, string link)
        {
            Name = name;
            Description = description;
            TypeOfSoftware = typeOfsoftware;
            BusinessArea = businessArea;
            PDF = pdf;
            Link = link;
        }
        public void addProduct()
        {
            

        }
    }
}
