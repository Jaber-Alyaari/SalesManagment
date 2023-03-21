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
        public int Id { get; set; }
        [StringLength(50)]
        [Required (ErrorMessage ="يجب ادخال الاسم")]
        [Range(1, 1000, ErrorMessage = "Quantity should be greater than 0 and less than 1000")]
        public string Name { get; set; } = null!;
        [StringLength(100)]
        [Required(ErrorMessage = "يجب ادخال الوصف")]
        public string? Describtion { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
