﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    [Table("AccountGroup")]
    public partial class AccountGroup
    {
        public AccountGroup()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string? Description { get; set; }

        [InverseProperty("Group")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
