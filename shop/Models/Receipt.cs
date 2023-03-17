using Microsoft.EntityFrameworkCore.Metadata.Internal;
using shop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace shop.Models
{
    [Table("Receipt")]
    public class Receipt
    {
        [Required]
        [MaxLength(15)]
        public string PoNumber { get; set; }

        [Key]

        [Column(name: "ID", TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; } = DateTime.Now;
        public bool? IsCatch { get; set; }
        [Column(name: "Account_Num", TypeName = "int")]
        public int? AccountNum { get; set; }
        [StringLength(50)]
        public string? Remarks { get; set; }
        [Column("User_ID")]
        public int? UserId { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("AccountNum")]
        [InverseProperty("AccountNumber")]
        public virtual Account? Account { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Id")]
        public virtual User? User { get; set; }
    }
}