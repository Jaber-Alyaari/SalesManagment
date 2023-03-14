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
        //public Invoice()
        //{
        //    InvoiceDetails = new HashSet<InvoiceDetail>();
        //}
        [Required]
        [MaxLength(15)]
        public string PoNumber { get; set; }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; } = DateTime.Now;
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
        public virtual List<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

        [NotMapped]
        public decimal Total { get; set; }
    }
}
