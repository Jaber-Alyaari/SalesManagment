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
        public long ProcessId { get; set; }
        [StringLength(50)]
        public string? ProcessType { get; set; }
        [Column("UserID")]
        public long? UserId { get; set; }
        [Column("ReferenceID")]
        [StringLength(10)]
        public long? ReferenceId { get; set; }
        public long? AccountNumber { get; set; }
        [StringLength(10)]
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
