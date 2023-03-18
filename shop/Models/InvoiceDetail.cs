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
        public int Id { get; set; }
        [Column("InvoiceID")]
        public int? InvoiceId { get; set; }
        [StringLength(50)]
        public int? ProductId { get; set; } 
        public decimal Quantity { get; set; }

        [ForeignKey("InvoiceId")]
        [InverseProperty("InvoiceDetails")]
        public virtual Invoice? Invoice { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("InvoiceDetails")]
        public virtual Product Product { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }


        [MaxLength(75)]
        [NotMapped]
        public string Description { get; set; } = "";

        [MaxLength(25)]
        [NotMapped]
        public string? UnitName { get; set; } = "Pcs";

        [NotMapped]
        public bool IsDeleted { get; set; } = false;
        [NotMapped]
        public decimal Total { get; set; }
    }
}
