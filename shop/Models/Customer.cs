using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public partial class Customer
    {
        public Customer()
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
        [StringLength(50)]
        public string? Address { get; set; }
        public bool? State { get; set; }
        public bool? IsSupplier { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
