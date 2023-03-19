using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    [Table("Journal")]
    [Index("AccountNumber", Name = "IX_Journal_AccountNumber")]
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
        public int? ReferenceId { get; set; }
        public int? AccountNumber { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public bool? Creditor { get; set; }
        public bool? Debtor { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey("AccountNumber")]
        [InverseProperty("Journals")]
        public virtual Account? AccountNumberNavigation { get; set; }



    }
}
