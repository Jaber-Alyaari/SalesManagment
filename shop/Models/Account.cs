using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public partial class Account
    {
        public Account()
        {
            Journals = new HashSet<Journal>();
        }

        [Key]
        public int AccountNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }
        public int? UserAdds { get; set; }
        [Column("GroupID")]
        public int? GroupId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column("SupplierID")]
        public int? SupplierId { get; set; }
        public bool State { get; set; } = false;

        [ForeignKey("CustomerId")]
        [InverseProperty("Accounts")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey("GroupId")]
        [InverseProperty("Accounts")]
        public virtual AccountGroup? Group { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("Accounts")]
        public virtual Supplier? Supplier { get; set; }
        [ForeignKey("UserAdds")]
        [InverseProperty("Accounts")]
        public virtual User? UserAddsNavigation { get; set; }
        [InverseProperty("AccountNumberNavigation")]
        public virtual ICollection<Journal> Journals { get; set; }
    }
}
