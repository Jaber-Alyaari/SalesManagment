﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shop.Models;

#nullable disable

namespace shop.Migrations
{
    [DbContext(typeof(SalesManagerDBContext))]
    [Migration("20230312231201_addProductIDString")]
    partial class addProductIDString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("shop.Models.Account", b =>
                {
                    b.Property<long>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("AccountNumber");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AccountNumber"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("date");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("CustomerID");

                    b.Property<long?>("GroupId")
                        .HasColumnType("bigint")
                        .HasColumnName("GroupID");

                    b.Property<bool?>("State")
                        .HasColumnType("bit");

                    b.Property<long?>("SupplierId")
                        .HasColumnType("bigint")
                        .HasColumnName("SupplierID");

                    b.Property<long?>("UserAdds")
                        .HasColumnType("bigint");

                    b.HasKey("AccountNumber");

                    b.HasIndex("CustomerId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UserAdds");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("shop.Models.AccountGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AccountGroup");
                });

            modelBuilder.Entity("shop.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Describtion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("shop.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("shop.Models.Invoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("Customer_ID");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<bool?>("IsSales")
                        .HasColumnType("bit");

                    b.Property<string>("PoNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Remarks")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("SupplierId")
                        .HasColumnType("bigint")
                        .HasColumnName("SupplierID");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("User_ID");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UserId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("shop.Models.InvoiceDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("InvoiceId")
                        .HasColumnType("bigint")
                        .HasColumnName("InvoiceID");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("shop.Models.Journal", b =>
                {
                    b.Property<long>("ProcessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ProcessID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProcessId"), 1L, 1);

                    b.Property<long?>("AccountNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Amount")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<bool?>("Creditor")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<bool?>("Debtor")
                        .HasColumnType("bit");

                    b.Property<string>("ProcessType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ReferenceId")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .HasColumnName("ReferenceID")
                        .IsFixedLength();

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("UserID");

                    b.HasKey("ProcessId");

                    b.HasIndex("AccountNumber");

                    b.ToTable("Journal");
                });

            modelBuilder.Entity("shop.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ID");

                    b.Property<long?>("CatId")
                        .HasColumnType("bigint")
                        .HasColumnName("CatID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CatId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("shop.Models.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("shop.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("StateAcount")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("shop.Models.View1", b =>
                {
                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Expr1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    b.Property<bool?>("IsSales")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToView("View_1");
                });

            modelBuilder.Entity("shop.Models.Account", b =>
                {
                    b.HasOne("shop.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Accounts_Customer");

                    b.HasOne("shop.Models.AccountGroup", "Group")
                        .WithMany("Accounts")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Accounts_Group");

                    b.HasOne("shop.Models.Supplier", "Supplier")
                        .WithMany("Accounts")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK_Accounts_Suppliers");

                    b.HasOne("shop.Models.User", "UserAddsNavigation")
                        .WithMany("Accounts")
                        .HasForeignKey("UserAdds")
                        .HasConstraintName("FK_Accounts_User");

                    b.Navigation("Customer");

                    b.Navigation("Group");

                    b.Navigation("Supplier");

                    b.Navigation("UserAddsNavigation");
                });

            modelBuilder.Entity("shop.Models.Invoice", b =>
                {
                    b.HasOne("shop.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Bills_Customers");

                    b.HasOne("shop.Models.Supplier", "Supplier")
                        .WithMany("Invoices")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK_Invoice_Suppliers");

                    b.HasOne("shop.Models.User", "User")
                        .WithMany("Invoices")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Bills_Users");

                    b.Navigation("Customer");

                    b.Navigation("Supplier");

                    b.Navigation("User");
                });

            modelBuilder.Entity("shop.Models.InvoiceDetail", b =>
                {
                    b.HasOne("shop.Models.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_BillDetails_Bills");

                    b.HasOne("shop.Models.Product", "Product")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BillDetails_Products");

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("shop.Models.Journal", b =>
                {
                    b.HasOne("shop.Models.Account", "AccountNumberNavigation")
                        .WithMany("Journals")
                        .HasForeignKey("AccountNumber")
                        .HasConstraintName("FK_Journal_Accounts");

                    b.Navigation("AccountNumberNavigation");
                });

            modelBuilder.Entity("shop.Models.Product", b =>
                {
                    b.HasOne("shop.Models.Category", "Cat")
                        .WithMany("Products")
                        .HasForeignKey("CatId")
                        .HasConstraintName("FK_Products_Categories");

                    b.Navigation("Cat");
                });

            modelBuilder.Entity("shop.Models.Account", b =>
                {
                    b.Navigation("Journals");
                });

            modelBuilder.Entity("shop.Models.AccountGroup", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("shop.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("shop.Models.Customer", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("shop.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("shop.Models.Product", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("shop.Models.Supplier", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("shop.Models.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
