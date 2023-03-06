using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    [Keyless]
    public partial class View1
    {
        [StringLength(50)]
        public string? Name { get; set; }
        [Column("ID")]
        public long Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        public bool? IsSales { get; set; }
        [StringLength(50)]
        public string? Expr1 { get; set; }
    }
}
