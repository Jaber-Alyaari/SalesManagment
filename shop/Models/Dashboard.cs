namespace shop.Models
{
    public class Dashboard
    {
        public int Sales { get; set; }
        public int Purchases
        {
            get; set;
        }
        public int Supplires
        {
            get; set;
        }
        public int Customers
        {
            get; set;
        }

        public List<InvoiceDetail> TopProducts { get; set; }

    }
}
