using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace shop.Models
{
    public partial class SalesManagerDBContext : DbContext
    {
        public SalesManagerDBContext()
        {
        }

        public SalesManagerDBContext(DbContextOptions<SalesManagerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountGroup> AccountGroups { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
        public virtual DbSet<Journal> Journals { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<View1> View1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=SalesManagerDB;Trusted_Connection = yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Accounts_Customer");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Accounts_Group");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Accounts_Suppliers");

                entity.HasOne(d => d.UserAddsNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserAdds)
                    .HasConstraintName("FK_Accounts_User");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Bills_Customers");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Invoice_Suppliers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Bills_Users");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_BillDetails_Bills");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_BillDetails_Products");
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.Property(e => e.Amount).IsFixedLength();

                entity.Property(e => e.ReferenceId).IsFixedLength();

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Journals)
                    .HasForeignKey(d => d.AccountNumber)
                    .HasConstraintName("FK_Journal_Accounts");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.ToView("View_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
