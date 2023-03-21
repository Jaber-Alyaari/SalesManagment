using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Models
{
    public partial class User
    {
        //public User()
        //{
        //    Accounts = new HashSet<Account>();
        //    Invoices = new HashSet<Invoice>();
        //}

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string Phone { get; set; } = null!;
        [StringLength(50)]
        public string? Email { get; set; }
        public bool? StateAcount { get; set; }
        [StringLength(50)]
        public string? UserName { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }

        [InverseProperty("UserAddsNavigation")]
        public virtual ICollection<Account>? Accounts { get; set; }

        [InverseProperty("UserAdd")]
        public virtual ICollection<Invoice>? AddInvoices { get; set; }
        [InverseProperty("UserModifi")]
        public virtual ICollection<Invoice>? ModifiInvoices { get; set; }

    }
}
