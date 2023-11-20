using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soft
{
    class Consultant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public String Password { get; set; }

        DBconnection dbconnection = DBconnection.getInstanceOfDBconnection();

        public static Consultant _instanceOfConsultant;

        

        public Consultant(int iD, string name, string email, string password)
        {
            ID = iD;
            Name = name;
            Email = email;
            Password = password;
        }

        public static Consultant getInstanceOfConsultant(int iD, string name, string email, string password)
        {
            if (_instanceOfConsultant == null)
            {
                _instanceOfConsultant = new Consultant(iD, name, email, password);
            }
            return _instanceOfConsultant;
        }

        public void saveConsultantToDb(Queries query, Consultant consultant)
        {
            dbconnection.saveToDb(query.createNewConsultant(), consultant.Name, consultant.Email, consultant.Password);
            Login.messagePrompt("User added successfully");

        }
    
    }
}
