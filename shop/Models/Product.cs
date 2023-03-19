using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    [Index("CatId", Name = "IX_Products_CatID")]
    public partial class Product
    {
        public Product()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        [Key]
        [StringLength(50)]
        public string Code { get; set; } = null!;
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Quantity { get; set; }
        [StringLength(50)]
        public string? Unit { get; set; }
        [Column("CatID")]
        public int? CatId { get; set; }

        [ForeignKey("CatId")]
        [InverseProperty("Products")]
        public virtual Category? Cat { get; set; }
        [InverseProperty("ProductCodeNavigation")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
