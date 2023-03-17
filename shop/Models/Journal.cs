using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    [Table("Journal")]
    public partial class Journal
    {
        [Key]
        [Column("ProcessID")]
        public int ProcessId { get; set; }
        [StringLength(50)]
        public string? ProcessType { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [Column("ReferenceID")]
        [StringLength(10)]
        public int? ReferenceId { get; set; }
        public int? AccountNumber { get; set; }
        [StringLength(10)]
        public decimal Amount { get; set; }
        public bool? Creditor { get; set; } = false;
        public bool? Debtor { get; set; } = false;
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey("AccountNumber")]
        [InverseProperty("Journals")]
        public virtual Account? AccountNumberNavigation { get; set; }
    }
}
