using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    [Table("Invoice")]
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        public bool? IsSales { get; set; }
        [Column("Customer_ID")]
        public long? CustomerId { get; set; }
        [StringLength(50)]
        public string? Remarks { get; set; }
        [Column("User_ID")]
        public long? UserId { get; set; }
        [Column("SupplierID")]
        public long? SupplierId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Invoices")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("Invoices")]
        public virtual Supplier? Supplier { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Invoices")]
        public virtual User? User { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
