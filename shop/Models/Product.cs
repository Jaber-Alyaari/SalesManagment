using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public partial class Product
    {
        public Product()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        //[Remote("IsProductCodeValid", "Product", AdditionalFields = "Name", ErrorMessage = "Product Code Exists Already")]
        [Key]
        [StringLength(6)]
        public string Code { get; set; }

        //[Key]
        [Column("ID")]
        public long Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage ="يجب ادخال اسم المنتج")]
        [DataType(DataType.Text,ErrorMessage ="يجب ان يكون الاسم احرف فث")]
        public string Name { get; set; }
        [Required(ErrorMessage = "يجب ادخال سعر المنتج")]

        public int Price { get; set; }
        public int? Quantity { get; set; }
        [StringLength(50)]
        public string? Unit { get; set; }
        [Column("CatID")]
        public long? CatId { get; set; }

        [ForeignKey("CatId")]
        [InverseProperty("Products")]
        public virtual Category? Cat { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
