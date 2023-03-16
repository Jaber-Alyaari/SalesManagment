using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public partial class Product
    {
        public Product()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int? Quantity { get; set; }
        [StringLength(50)]
        public string? Unit { get; set; }
        [Column("CatID")]
        public int? CatId { get; set; }
        [Key]
        [StringLength(50)]
        public string Code { get; set; } = null!;

        [ForeignKey("CatId")]
        [InverseProperty("Products")]
        public virtual Category? Cat { get; set; }
        [InverseProperty("ProductCodeNavigation")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
