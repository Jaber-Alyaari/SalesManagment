using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    [Table("Invoice")]
    //[Index("CustomerId", Name = "IX_Invoice_Customer_ID")]
    //[Index("SupplierId", Name = "IX_Invoice_SupplierID")]
    //[Index("UserId", Name = "IX_Invoice_User_ID")]
    public partial class Invoice
    {
        //public Invoice()
        //{
        //    InvoiceDetails = new HashSet<InvoiceDetail>();
        //}

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(15)]
        public string PoNumber { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; } = DateTime.Now;
        public DateTime? ModifiDate { get; set; } = null!;

        public bool? IsDebt { get; set; } = false;
        [Column("Customer_ID")]
        public int? CustomerId { get; set; }
        [StringLength(50)]
        public string? Remarks { get; set; }
        [Column("AUser_ID")]
        public int? AUserId { get; set; }
        [Column("MUser_ID")]
        public int? MUserId { get; set; }

        [Column("SupplierID")]
        public int? SupplierId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Invoices")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("Invoices")]
        public virtual Supplier? Supplier { get; set; }
        //[ForeignKey("AUserId")]
        public virtual User? UserAdd { get; set; }

        //[ForeignKey("MUserId")]
        public virtual User? UserModifi { get; set; }

        [InverseProperty("Invoice")]
        public virtual List<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
        [NotMapped]
        public decimal Total { get; set; }
    }
}
