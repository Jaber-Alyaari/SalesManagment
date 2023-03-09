using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [StringLength(50,ErrorMessage ="لايجب ان يكون الاسم طويلا",MinimumLength =2)]
        [Required(ErrorMessage ="يجب ادخال اسم الصنف ")]
        public string Name { get; set; }
        [StringLength(100)]
        public string? Describtion { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
