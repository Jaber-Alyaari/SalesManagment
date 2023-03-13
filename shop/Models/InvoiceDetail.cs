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
        public long ProductId { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Quantity should be greater than 0 and less than 1000")]
        public int Quantity { get; set; }


        [NotMapped]
        public decimal Price { get; set; }


        [MaxLength(75)]
        [NotMapped]
        public string Description { get; set; } = "";

        [MaxLength(25)]
        [NotMapped]
        public string UnitName { get; set; } = "Pcs";

        [NotMapped]
        public bool IsDeleted { get; set; } = false;
        [NotMapped]
        public decimal Total { get; set; }


        [Required]
        [ForeignKey("Product")]
        [MaxLength(6)]
        public string ProductCode { get; set; }
        [InverseProperty("InvoiceDetails")]
        public virtual Product Product { get; private set; }



        [ForeignKey("InvoiceId")]
        [InverseProperty("InvoiceDetails")]
        public virtual Invoice? Invoice { get; set; }
        //[ForeignKey("ProductId")]
        //[InverseProperty("InvoiceDetails")]
        //public virtual Product? Product { get; set; }
    }
}
