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
    [Migration("20230319141400_modifiinvoice")]
    partial class modifiinvoice
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
                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountNumber"), 1L, 1);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("GroupID");

                    b.Property<bool?>("State")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("SupplierID");

                    b.Property<int?>("UserAdds")
                        .HasColumnType("int");

                    b.HasKey("AccountNumber");

                    b.HasIndex(new[] { "CustomerId" }, "IX_Accounts_CustomerID");

                    b.HasIndex(new[] { "GroupId" }, "IX_Accounts_GroupID");

                    b.HasIndex(new[] { "SupplierId" }, "IX_Accounts_SupplierID");

                    b.HasIndex(new[] { "UserAdds" }, "IX_Accounts_UserAdds");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("shop.Models.AccountGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AUserId")
                        .HasColumnType("int")
                        .HasColumnName("AUser_ID");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("Customer_ID");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<bool?>("IsSales")
                        .HasColumnType("bit");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int")
                        .HasColumnName("MUser_ID");

                    b.Property<DateTime?>("ModifiDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PoNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Remarks")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("SupplierID");

                    b.Property<int?>("UserAddId")
                        .HasColumnType("int");

                    b.Property<int?>("UserModifiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UserAddId");

                    b.HasIndex("UserModifiId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("shop.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int")
                        .HasColumnName("InvoiceID");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "InvoiceId" }, "IX_InvoiceDetails_InvoiceID");

                    b.HasIndex(new[] { "ProductCode" }, "IX_InvoiceDetails_ProductCode");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("shop.Models.Journal", b =>
                {
                    b.Property<int>("ProcessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProcessID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProcessId"), 1L, 1);

                    b.Property<int?>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Creditor")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<bool?>("Debtor")
                        .HasColumnType("bit");

                    b.Property<string>("ProcessType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ReferenceId")
                        .HasColumnType("int")
                        .HasColumnName("ReferenceID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("ProcessId");

                    b.HasIndex(new[] { "AccountNumber" }, "IX_Journal_AccountNumber");

                    b.ToTable("Journal");
                });

            modelBuilder.Entity("shop.Models.Product", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("CatId")
                        .HasColumnType("int")
                        .HasColumnName("CatID");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unit")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Code");

                    b.HasIndex(new[] { "CatId" }, "IX_Products_CatID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("shop.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("shop.Models.Account", b =>
                {
                    b.HasOne("shop.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId");

                    b.HasOne("shop.Models.AccountGroup", "Group")
                        .WithMany("Accounts")
                        .HasForeignKey("GroupId");

                    b.HasOne("shop.Models.Supplier", "Supplier")
                        .WithMany("Accounts")
                        .HasForeignKey("SupplierId");

                    b.HasOne("shop.Models.User", "UserAddsNavigation")
                        .WithMany("Accounts")
                        .HasForeignKey("UserAdds");

                    b.Navigation("Customer");

                    b.Navigation("Group");

                    b.Navigation("Supplier");

                    b.Navigation("UserAddsNavigation");
                });

            modelBuilder.Entity("shop.Models.Invoice", b =>
                {
                    b.HasOne("shop.Models.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId");

                    b.HasOne("shop.Models.Supplier", "Supplier")
                        .WithMany("Invoices")
                        .HasForeignKey("SupplierId");

                    b.HasOne("shop.Models.User", "UserAdd")
                        .WithMany("AddInvoices")
                        .HasForeignKey("UserAddId");

                    b.HasOne("shop.Models.User", "UserModifi")
                        .WithMany("ModifiInvoices")
                        .HasForeignKey("UserModifiId");

                    b.Navigation("Customer");

                    b.Navigation("Supplier");

                    b.Navigation("UserAdd");

                    b.Navigation("UserModifi");
                });

            modelBuilder.Entity("shop.Models.InvoiceDetail", b =>
                {
                    b.HasOne("shop.Models.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("shop.Models.Product", "ProductCodeNavigation")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("ProductCodeNavigation");
                });

            modelBuilder.Entity("shop.Models.Journal", b =>
                {
                    b.HasOne("shop.Models.Account", "AccountNumberNavigation")
                        .WithMany("Journals")
                        .HasForeignKey("AccountNumber");

                    b.Navigation("AccountNumberNavigation");
                });

            modelBuilder.Entity("shop.Models.Product", b =>
                {
                    b.HasOne("shop.Models.Category", "Cat")
                        .WithMany("Products")
                        .HasForeignKey("CatId");

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

                    b.Navigation("AddInvoices");

                    b.Navigation("ModifiInvoices");
                });
#pragma warning restore 612, 618
        }
    }
}
