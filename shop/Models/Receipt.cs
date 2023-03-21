using Microsoft.EntityFrameworkCore.Metadata.Internal;
using shop.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace shop.Models
{
    [Table("Receipt")]
    public class Receipt
    {

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(15)]
        public string PoNumber { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; } = DateTime.Now;
        [Column(TypeName = "date")]
        public DateTime? ModifiDate { get; set; } = null!;

        public bool? IsCatch { get; set; } = true;

        public string? Remarks { get; set; }
        [Column("AUser_ID")]
        public int? AUserId { get; set; }
        [Column("MUser_ID")]
        public int? MUserId { get; set; }


        public virtual User? UserAdd { get; set; }
        public virtual User? UserModifi { get; set; }
        public decimal Amount { get; set; }
        public int? AccountNumber { get; set; }

        [ForeignKey("AccountNumber")]
        [InverseProperty("Receipt")]
        public virtual Account? Accounts { get; set; }


    }
}