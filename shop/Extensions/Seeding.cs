
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Extensions
{
    public class Seeding
    {
        private readonly IServiceProvider _serviceProvider;

        public Seeding(IServiceProvider serviceProvider)
        {
            _serviceProvider=serviceProvider;
        }

     


        public  void SeedUsers()
        {
            using (var db = new SalesManagerDBContext(_serviceProvider.GetRequiredService<DbContextOptions<SalesManagerDBContext>>()))
            {
                db.Database.EnsureCreated();
                var user  = db.Users.FirstOrDefault(m => m.UserName == "jaber");
                if (user == null)
                    db.Users.Add(
                        new User {
                            Name ="jaber",
                            UserName  = "jaber",
                            IsAdmin = true,
                            Password="123",
                            Email ="jaber@gmail.com",
                            Phone ="7389475345",
                            StateAcount=true,
                           
                        }
                    );

                 user = db.Users.FirstOrDefault(m => m.UserName == "jaber2");
                if (user == null)
                    db.Users.Add(
                        new User
                        {
                            Name = "jaber2",
                            UserName = "jaber2",
                            IsAdmin = false,
                            Password = "123",
                            Email = "jaber@gmail.com",
                            Phone = "7389475345",
                            StateAcount = true,

                        }
                    );


              var   accountG = db.AccountGroups.FirstOrDefault(m => m.Name == "salse");
                if (accountG == null)
                    db.AccountGroups.Add(
                        new AccountGroup
                        {
                            Name = "salse",
                          
                        }
                    );
                 accountG = db.AccountGroups.FirstOrDefault(m => m.Name == "products");
                if (accountG == null)
                    db.AccountGroups.Add(
                        new AccountGroup
                        {
                            Name = "products",

                        }
                    );
                accountG = db.AccountGroups.FirstOrDefault(m => m.Name == "bank");
                if (accountG == null)
                    db.AccountGroups.Add(
                        new AccountGroup
                        {
                            Name = "bank",

                        }
                    );
                accountG = db.AccountGroups.FirstOrDefault(m => m.Name == "box");
                if (accountG == null)
                    db.AccountGroups.Add(
                        new AccountGroup
                        {
                            Name = "box",

                        }
                    );

               var account = db.Accounts.FirstOrDefault(m => m.AccountNumber == 1);
                if (account == null)
                    db.Accounts.Add(
                        new Account
                        {
                            CreateDate = DateTime.Now,
                            GroupId = 1,
                            State = true,

                        }
                    );
                 account = db.Accounts.FirstOrDefault(m => m.AccountNumber == 2);
                if (account == null)
                    db.Accounts.Add(
                        new Account
                        {
                            CreateDate = DateTime.Now,
                            GroupId = 2,
                            State = true,

                        }
                    );

                 account = db.Accounts.FirstOrDefault(m => m.AccountNumber == 3);
                if (account == null)
                    db.Accounts.Add(
                        new Account
                        {
                            CreateDate = DateTime.Now,
                            GroupId = 3,
                            State = true,

                        }
                    );

                 account = db.Accounts.FirstOrDefault(m => m.AccountNumber == 4);
                if (account == null)
                    db.Accounts.Add(
                        new Account
                        {
                            CreateDate = DateTime.Now,
                            GroupId =4,
                            State=true,
                        }
                    );


               var  sub = db.Suppliers.FirstOrDefault(m => m.Name == "الحساب العام");
                if (sub == null)
                    db.Suppliers.Add(
                        new Supplier
                        {
                            Name = "الحساب العام",
                            Phone = "77777777",

                        }
                    );
                var customer = db.Suppliers.FirstOrDefault(m => m.Name == "الحساب العام");
                if (customer == null)
                    db.Customers.Add(
                        new Customer
                        {
                            Name = "الحساب العام",
                            Phone = "77777777",

                        }
                    );

                account = db.Accounts.FirstOrDefault(m => m.AccountNumber == 10);
                if (account == null)
                    db.Accounts.Add(
                        new Account
                        {
                            CreateDate = DateTime.Now,
                            CustomerId = 1,
                            State = true,
                        }
                    );
                account = db.Accounts.FirstOrDefault(m => m.AccountNumber == 11);
                if (account == null)
                    db.Accounts.Add(
                        new Account
                        {
                            CreateDate = DateTime.Now,
                            SupplierId = 1,
                            State = true,
                        }
                    );
                db.SaveChanges();
            }
        }




    }
}
