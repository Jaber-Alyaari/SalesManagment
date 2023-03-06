using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public partial class InvoiceDetail
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column("InvoiceID")]
        public long? InvoiceId { get; set; }
        [Column("ProductID")]
        public long? ProductId { get; set; }
        public int? Quantity { get; set; }

        [ForeignKey("InvoiceId")]
        [InverseProperty("InvoiceDetails")]
        public virtual Invoice? Invoice { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("InvoiceDetails")]
        public virtual Product? Product { get; set; }
    }
}
