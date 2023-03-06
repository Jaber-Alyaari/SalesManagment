using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            Invoices = new HashSet<Invoice>();
        }

        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Phone { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        public bool? StateAcount { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }

        [InverseProperty("UserAddsNavigation")]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
