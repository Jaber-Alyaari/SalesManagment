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
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "يجب ادخال الاسم")]
        public string? Name { get; set; }
        [StringLength(50)]
        //[Required(ErrorMessage = "يجب ادخال الرقم")]
        [Range(700000000, 799999999, ErrorMessage = "رقم الهاتف غير صحيح")]
        public string? Phone { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Invoice> Invoices { get; set; }



        [NotMapped]
        public virtual decimal? TotalDeptor { get; set; } = 0;

        [NotMapped]
        public virtual decimal? TotalCreditor { get; set; }= 0;
        [NotMapped]

        public virtual decimal? Total { get; set; } = 0;
    }
}
