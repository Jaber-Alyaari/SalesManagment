using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required(ErrorMessage = "يجب ادخال الاسم")]

        public string Name { get; set; } = null!;
        [StringLength(100)]
        [Required(ErrorMessage = "يجب ادخال الوصف")]
        public string? Describtion { get; set; }

        [InverseProperty("Cat")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
