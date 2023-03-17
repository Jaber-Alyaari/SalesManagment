using System.ComponentModel.DataAnnotations;

namespace shop.Models
{
    public class AccoutDetails
    {
        public AccoutDetails()
        {
            Account account = new Account();
            Customer customer = new Customer(); 
            Supplier supplier = new Supplier(); 
            List<Journal> journals = new List<Journal>();
        }





    }
}
