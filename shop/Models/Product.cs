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
        [Required(ErrorMessage = "يجب ادخال الاسم")]
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "يجب ادخال السعر")]
        [Range(1, 1000000, ErrorMessage = "price should be greater than 0 and less than 1000000")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "يجب ادخال الكمية")]
        [Range(1, 1000, ErrorMessage = "Quantity should be greater than 0 and less than 1000")]
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
