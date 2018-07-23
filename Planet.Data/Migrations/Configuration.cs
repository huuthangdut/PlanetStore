using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Planet.Data.Core.Domain;
using Planet.Data.Persistence;

namespace Planet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Planet.Data.Persistence.PlanetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PlanetContext context)
        {
            //            SeedOrderStatus(context);
            //            SeedShippingMethod(context);
            //            SeedAttribute(context);
            //            SeedAttributeValue(context);
            //
            //            SeedSupplier(context);
            //            SeedManufacturer(context);
            //
            //            SeedFunction(context);
            //            SeedRoleAndPermission(context);
            //            SeedUser(context);
            //            SeedProductCategory(context);
            //            SeedProduct(context);
            //            SeedContactDetail(context);
            //            SeedPaymentMethod(context);
            //            SeedMenu(context);
            //            SeedSlide(context);
            //            context.SaveChanges();
        }

        private void SeedManufacturer(PlanetContext context)
        {
            context.Manufacturers.AddOrUpdate(m => m.CompanyName,
                new Manufacturer { CompanyName = "Samsung", Logo = "", Ranking = 5, Website = "samsung.com", Note = "Note" });
        }

        private void SeedSlide(PlanetContext context)
        {
            context.Slides.AddOrUpdate(s => s.Name,
                new Slide { Name = "Shop to get what you loves", Description = "Timepieces that make a statement up to 40% off", ImageUrl = "/Assets/client/images/slider/banner-1.jpg" },
                new Slide { Name = "The new standard", Description = "Under favorable smartwatches from $749", ImageUrl = "/Assets/client/images/slider/banner-1.jpg" });
            context.SaveChanges();
        }

        private void SeedSupplier(PlanetContext context)
        {
            context.Suppliers.AddOrUpdate(s => s.CompanyName,
                new Supplier { CompanyName = "Samsung" });
            context.SaveChanges();
        }

        private void SeedAttributeValue(PlanetContext context)
        {
            context.AttributeValues.AddOrUpdate(a => a.AttributeId,
                new AttributeValue { AttributeId = 1, Value = "Red" },
                new AttributeValue { AttributeId = 1, Value = "Yellow" },
                new AttributeValue { AttributeId = 1, Value = "Blue" },
                new AttributeValue { AttributeId = 1, Value = "White" },
                new AttributeValue { AttributeId = 1, Value = "Black" },
                new AttributeValue { AttributeId = 1, Value = "Red" },
                new AttributeValue { AttributeId = 1, Value = "Orange" },
                new AttributeValue { AttributeId = 1, Value = "Green" },
                new AttributeValue { AttributeId = 1, Value = "Purple" },
                new AttributeValue { AttributeId = 2, Value = "XS" },
                new AttributeValue { AttributeId = 2, Value = "S" },
                new AttributeValue { AttributeId = 2, Value = "M" },
                new AttributeValue { AttributeId = 2, Value = "L" },
                new AttributeValue { AttributeId = 2, Value = "XL" },
                new AttributeValue { AttributeId = 2, Value = "XXL" });

            //            +----------------+--------------------+-----------------+
            //                | attribute_name | attribute_value_id | attribute_value |
            //                +----------------+--------------------+-----------------+
            //                | Color | 6 | White |
            //                | Color | 7 | Black |
            //                | Color | 8 | Red |
            //                | Color | 9 | Orange |
            //                | Color | 10 | Yellow |
            //                | Color | 11 | Green |
            //                | Color | 12 | Blue |
            //                | Color | 13 | Indigo |
            //                | Color | 14 | Purple |
            //                | Size | 1 | S |
            //                | Size | 2 | M |
            //                | Size | 3 | L |
            //                | Size | 4 | XL |
            //                | Size | 5 | XXL |
            //                +----------------+--------------------+-----------------+

            context.SaveChanges();
        }

        private void SeedAttribute(PlanetContext context)
        {
            context.Attributes.AddOrUpdate(a => a.Name,
                new Core.Domain.Attribute { Name = "Color" },
                new Core.Domain.Attribute { Name = "Size" });

            context.SaveChanges();
        }

        private void SeedShippingMethod(PlanetContext context)
        {
            context.ShippingMethods.AddOrUpdate(s => s.Name,
                new ShippingMethod { Name = "Standard Shipping" },
                new ShippingMethod { Name = "Express Shipping" });

            context.SaveChanges();
        }

        private void SeedMenu(PlanetContext context)
        {
            context.Menus.AddOrUpdate(m => m.Name,
                new Menu { Name = "Trang chủ", ParentId = null, Status = true, Url = "/" },
                new Menu { Name = "Giới thiệu", ParentId = null, Status = true, Url = "/gioi-thieu" },
                new Menu { Name = "Hot Deal", ParentId = null, Status = true, Url = "/" },
                new Menu { Name = "Tin tức", ParentId = null, Status = true, Url = "/tin-tuc" },
                new Menu { Name = "Liên hệ", ParentId = null, Status = true, Url = "/lien-he" });

            context.SaveChanges();
        }

        private void SeedPaymentMethod(PlanetContext context)
        {
            context.PaymentMethods.AddOrUpdate(m => m.Name,
                new PaymentMethod { Name = "Cash On Delivery", Description = "Immediately after receiving the order, Planet will confirm to you by email, carry out the order and delivery within the specified time. Planet will also regularly update your order status via email or SMS" },
                new PaymentMethod { Name = "Credit Card", Description = "Immediately after receiving the order, Planet will check the payment transaction. If the transaction is not successful, Planet will contact you to inform. If the transaction is successful, Planet will carry out the order immediately and delivery within the specified time." },
                new PaymentMethod { Name = "ATM Card", Description = @"The condition for choosing ATM payment form is that your card is already registered for online banking. Planet.vn now supports payment by ATM card to 33 banks via NAPAS payment gateway.
                    As soon as the order is received,
                    Planet will check the payment transaction.If the transaction is successful,
                    Planet will conduct information verification and order fulfillment." });

            context.SaveChanges();
        }

        private void SeedOrderStatus(PlanetContext context)
        {
            context.OrderStatuses.AddOrUpdate(s => s.Name,
                new OrderStatus { Name = "Pending" },
                new OrderStatus { Name = "Processing" },
                new OrderStatus { Name = "Completed" },
                new OrderStatus { Name = "Canceled" });

            context.SaveChanges();
        }

        private void SeedContactDetail(PlanetContext context)
        {
            context.Contacts.AddOrUpdate(c => c.Name,
                new Contact
                {
                    Name = "Planet Store",
                    Email = "huuthangit.dn@gmail.com",
                    Address = "08 Hà Văn Tính, KTX DMC",
                    Ward = "Hoà Khánh Nam",
                    District = "Liên Chiểu",
                    Province = "Đà Nẵng",
                    Website = "planetstore.com",
                    Status = true,
                    PhoneNumber = "01695922599",
                    Latitude = 16.067872,
                    Longitude = 108.154789
                });
            context.SaveChanges();
        }

        private void SeedProduct(PlanetContext context)
        {
            context.Products.AddOrUpdate(p => p.Name,
                    new Product { Name = "Apple iPhone X", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 29000000, PromotionPrice = 28500000, OriginalPrice = 28000000, Alias = "apple-iphone-x", CategoryId = 1, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPhone 6", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 29000000, PromotionPrice = 28500000, OriginalPrice = 28000000, Alias = "apple-iphone-x", CategoryId = 1, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPhone 7", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 29000000, PromotionPrice = 28500000, OriginalPrice = 28000000, Alias = "apple-iphone-x", CategoryId = 1, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPhone 8", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 29000000, PromotionPrice = 28500000, OriginalPrice = 28000000, Alias = "apple-iphone-x", CategoryId = 1, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPhone 9", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 29000000, PromotionPrice = 28500000, OriginalPrice = 28000000, Alias = "apple-iphone-x", CategoryId = 1, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPhone 10", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 29000000, PromotionPrice = 28500000, OriginalPrice = 28000000, Alias = "apple-iphone-x", CategoryId = 1, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPhone 11", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 29000000, PromotionPrice = 28500000, OriginalPrice = 28000000, Alias = "apple-iphone-x", CategoryId = 1, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },

                    new Product { Name = "Apple iPad Mini 4", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 10000000, PromotionPrice = 8500000, OriginalPrice = 80000000, Alias = "apple-ipad-mini-4", CategoryId = 2, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPad Mini 5", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 10000000, PromotionPrice = 8500000, OriginalPrice = 80000000, Alias = "apple-ipad-mini-4", CategoryId = 2, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPad Mini 6", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 10000000, PromotionPrice = 8500000, OriginalPrice = 80000000, Alias = "apple-ipad-mini-4", CategoryId = 2, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPad Mini 7", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 10000000, PromotionPrice = 8500000, OriginalPrice = 80000000, Alias = "apple-ipad-mini-4", CategoryId = 2, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPad Mini 8", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 10000000, PromotionPrice = 8500000, OriginalPrice = 80000000, Alias = "apple-ipad-mini-4", CategoryId = 2, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPad Mini 9", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 10000000, PromotionPrice = 8500000, OriginalPrice = 80000000, Alias = "apple-ipad-mini-4", CategoryId = 2, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Apple iPad Mini 10", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 10000000, PromotionPrice = 8500000, OriginalPrice = 80000000, Alias = "apple-ipad-mini-4", CategoryId = 2, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },

                    new Product { Name = "Sony Action Cam A1", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 20000000, OriginalPrice = 185000000, Alias = "sony-action-cam-a4", CategoryId = 3, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Sony Action Cam A2", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 20000000, OriginalPrice = 185000000, Alias = "sony-action-cam-a4", CategoryId = 3, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Sony Action Cam A3", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 20000000, OriginalPrice = 185000000, Alias = "sony-action-cam-a4", CategoryId = 3, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Sony Action Cam A4", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 20000000, OriginalPrice = 185000000, Alias = "sony-action-cam-a4", CategoryId = 3, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Sony Action Cam A5", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 20000000, OriginalPrice = 185000000, Alias = "sony-action-cam-a4", CategoryId = 3, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Sony Action Cam A6", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 20000000, OriginalPrice = 185000000, Alias = "sony-action-cam-a4", CategoryId = 3, IncludedVAT = true, Status = 1, SupplierId = 1, ManufacturerId = 1 },

                    new Product { Name = "Headphone LG G3", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 500000, PromotionPrice = 300000, OriginalPrice = 285000, Alias = "headphone-lg-g3", CategoryId = 4, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Headphone LG G3 Fake", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 500000, PromotionPrice = 300000, OriginalPrice = 285000, Alias = "headphone-lg-g3", CategoryId = 4, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Headphone LG G3 Prime", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 500000, PromotionPrice = 300000, OriginalPrice = 285000, Alias = "headphone-lg-g3", CategoryId = 4, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Headphone LG G4 Prime", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 500000, PromotionPrice = 300000, OriginalPrice = 285000, Alias = "headphone-lg-g3", CategoryId = 4, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Headphone LG G5 Prime", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 500000, PromotionPrice = 300000, OriginalPrice = 285000, Alias = "headphone-lg-g3", CategoryId = 4, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Headphone LG G6 Prime", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 500000, PromotionPrice = 300000, OriginalPrice = 285000, Alias = "headphone-lg-g3", CategoryId = 4, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },

                    new Product { Name = "Mouse Logitech G205", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 450000, PromotionPrice = 320000, OriginalPrice = 300000, Alias = "mouse-logitech-g205", CategoryId = 5, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Mouse Logitech G215", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 450000, PromotionPrice = 320000, OriginalPrice = 300000, Alias = "mouse-logitech-g205", CategoryId = 5, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Mouse Logitech G225", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 450000, PromotionPrice = 320000, OriginalPrice = 300000, Alias = "mouse-logitech-g205", CategoryId = 5, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Mouse Logitech G235", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 450000, PromotionPrice = 320000, OriginalPrice = 300000, Alias = "mouse-logitech-g205", CategoryId = 5, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Mouse Logitech G245", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 450000, PromotionPrice = 320000, OriginalPrice = 300000, Alias = "mouse-logitech-g205", CategoryId = 5, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Mouse Logitech G256", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 450000, PromotionPrice = 320000, OriginalPrice = 300000, Alias = "mouse-logitech-g205", CategoryId = 5, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Mouse Logitech G207", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 450000, PromotionPrice = 320000, OriginalPrice = 300000, Alias = "mouse-logitech-g205", CategoryId = 5, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 },
                    new Product { Name = "Mouse Logitech G208", ThumbnailImage = "/Assets/client/images/products/1.jpg", UnitPrice = 450000, PromotionPrice = 320000, OriginalPrice = 300000, Alias = "mouse-logitech-g205", CategoryId = 5, IncludedVAT = false, Status = 1, SupplierId = 1, ManufacturerId = 1 }
                );

            context.SaveChanges();
        }

        private void SeedFunction(PlanetContext context)
        {
            context.Functions.AddOrUpdate(f => f.Id,
                    // Dashboard Module
                    new Function { Id = "Dashboard", Name = "Dashboard", ParentId = null, DisplayOrder = 1, Status = true, Url = "/dashboard", IconCss = "icon-home" },

                    new Function { Id = "Authorization", Name = "Authorization", ParentId = null, DisplayOrder = 2, Status = true, Url = "/auth" },
                    new Function { Id = "Roles", Name = "Roles", ParentId = "Authorization", DisplayOrder = 1, Status = true, Url = "/auth/roles" },
                    new Function { Id = "Users", Name = "Users", ParentId = "Authorization", DisplayOrder = 2, Status = true, Url = "/auth/users" },


                    // eCommerce Module
                    new Function { Id = "Ecommerce", Name = "Ecommerce", ParentId = null, DisplayOrder = 3, Status = true, Url = "/ecommerce", IconCss = "icon-basket" },
                    new Function { Id = "ProductCategories", Name = "Categories", ParentId = "Ecommerce", DisplayOrder = 1, Status = true, Url = "/ecommerce/categories" },
                    new Function { Id = "Products", Name = "Products", ParentId = "Ecommerce", DisplayOrder = 2, Status = true, Url = "/ecommerce/products", IconCss = "icon-handbag" },
                    new Function { Id = "Orders", Name = "Orders", ParentId = "Ecommerce", DisplayOrder = 3, Status = true, Url = "/ecommerce/orders", IconCss = "icon-basket" },

                    // Content Module
                    new Function { Id = "Content", Name = "Content", ParentId = null, DisplayOrder = 4, Status = true, Url = "/content", IconCss = "fa fa-table" },
                    new Function { Id = "PostCategories", Name = "Categories", ParentId = "Content", DisplayOrder = 1, Status = true, Url = "content/categories" },
                    new Function { Id = "Posts", Name = "Posts", ParentId = "Content", DisplayOrder = 2, Status = true, Url = "content/posts" },

                    //Report Module
                    new Function { Id = "Report", Name = "Report", ParentId = null, DisplayOrder = 5, Status = true, Url = "/report" },
                    new Function { Id = "Revenues", Name = "Revenues", ParentId = "Report", DisplayOrder = 1, Status = true, Url = "/report/revenues" },
                    new Function { Id = "Access", Name = "Access", ParentId = "Report", DisplayOrder = 2, Status = true, Url = "/report/visitor" },
                    new Function { Id = "Reader", Name = "Reader", ParentId = "Report", DisplayOrder = 3, Status = true, Url = "/report/reader" }

                //Settings Module


                );

            context.SaveChanges();
        }

        private void SeedRoleAndPermission(PlanetContext context)
        {
            var roleManager = new RoleManager<AppRole>(new RoleStore<AppRole>(new PlanetContext()));
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new AppRole { Name = "Admin", Description = "Quản trị viên" });
                roleManager.Create(new AppRole { Name = "Member", Description = "Người dùng" });
                roleManager.Create(new AppRole { Name = "Author", Description = "Biên tập viên" });

                var functions = context.Functions.ToList();
                var roles = roleManager.Roles.ToList();

                foreach (var function in functions)
                {
                    foreach (var role in roles)
                    {
                        if (role.Name == "Admin")
                        {
                            context.Permissions.Add(new Permission
                            {
                                FunctionId = function.Id,
                                RoleId = role.Id,
                                CanRead = true,
                                CanUpdate = true,
                                CanCreate = true,
                                CanDelete = true
                            });
                        }
                        else
                        {
                            context.Permissions.Add(new Permission
                            {
                                FunctionId = function.Id,
                                RoleId = role.Id,
                                CanRead = false,
                                CanUpdate = false,
                                CanCreate = false,
                                CanDelete = false
                            });
                        }
                    }
                }
            }

            context.SaveChanges();
        }

        private void SeedUser(PlanetContext context)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new PlanetContext()));
            //if (!manager.Users.Any())
            //{
            var user = new AppUser
            {
                UserName = "admin@planetstore.com",
                Email = "admin@planetstore.com",
                EmailConfirmed = true,
                Birthdate = DateTime.Now,
                FirstName = "Trần Hữu",
                LastName = "Thắng",
                Gender = true,
                Status = false,
                District = "Liên Chiểu",
                Province = "Đà Nẵng"
            };
            var user1 = new AppUser
            {
                UserName = "admin1@planetstore.com",
                Email = "admin1@planetstore.com",
                EmailConfirmed = true,
                Birthdate = DateTime.Now,
                FirstName = "Trần Hữu",
                LastName = "Toàn",
                Gender = true,
                Status = false,
                District = "Liên Chiểu",
                Province = "Đà Nẵng"
            };
            var user2 = new AppUser
            {
                UserName = "admin2@planetstore.com",
                Email = "admin2@planetstore.com",
                EmailConfirmed = true,
                Birthdate = DateTime.Now,
                FirstName = "Trần Hữu",
                LastName = "Nguyên Khôi",
                Gender = true,
                Status = false,
                District = "Liên Chiểu",
                Province = "Đà Nẵng"
            };
            var user3 = new AppUser
            {
                UserName = "admin3@planetstore.com",
                Email = "admin3@planetstore.com",
                EmailConfirmed = true,
                Birthdate = DateTime.Now,
                FirstName = "Trần Hữu",
                LastName = "Tiến Đạt",
                Gender = true,
                Status = false,
                District = "Liên Chiểu",
                Province = "Đà Nẵng"
            };
            var user4 = new AppUser
            {
                UserName = "admin4@planetstore.com",
                Email = "admin4@planetstore.com",
                EmailConfirmed = true,
                Birthdate = DateTime.Now,
                FirstName = "Trần Hữu",
                LastName = "Gia Huy",
                Gender = true,
                Status = false,
                District = "Liên Chiểu",
                Province = "Đà Nẵng"
            };
            var user5 = new AppUser
            {
                UserName = "admin5@planetstore.com",
                Email = "admin5@planetstore.com",
                EmailConfirmed = true,
                Birthdate = DateTime.Now,
                FirstName = "Trần Hữu",
                LastName = "Tình",
                Gender = true,
                Status = false,
                District = "Liên Chiểu",
                Province = "Đà Nẵng"
            };

            manager.Create(user, "1234566");
            manager.Create(user1, "1234566");
            manager.Create(user2, "1234566");
            manager.Create(user3, "1234566");
            manager.Create(user4, "1234566");
            manager.Create(user5, "1234566");
            manager.AddToRoles(user.Id, "Admin", "Author", "Member");
            manager.AddToRoles(user1.Id, "Admin", "Author", "Member");
            manager.AddToRoles(user2.Id, "Admin", "Author", "Member");
            manager.AddToRoles(user3.Id, "Admin", "Author", "Member");
            manager.AddToRoles(user4.Id, "Admin", "Author", "Member");
            manager.AddToRoles(user5.Id, "Admin", "Author", "Member");
            //}

            context.SaveChanges();
        }

        private void SeedProductCategory(PlanetContext context)
        {
            context.ProductCategories.AddOrUpdate(c => c.Name,
                new ProductCategory { Name = "Điện thoại - Máy tính bảng", Alias = "dien-thoai-may-tinh-bang", Status = 1 },
                new ProductCategory { Name = "Tivi - Thiết bị nghe nhìn", Alias = "tivi-thiet-bi-nghe-nhin", Status = 1 },
                new ProductCategory { Name = "Phụ kiện - Thiết bị số", Alias = "phu-kien-thiet-bi-so", Status = 1 },
                new ProductCategory { Name = "Laptop - Máy vi tính", Alias = "laptop-thiet-bi-it", Status = 1 },
                new ProductCategory { Name = "Máy ảnh - Quay phim", Alias = "may-anh-quay-phim", Status = 1 },
                new ProductCategory { Name = "Điện gia dụng - Điện lạnh", Alias = "dien-gia-dung-dien-lanh", Status = 1 },
                new ProductCategory { Name = "Nhà cửa đời sống", Alias = "nha-cua-doi-song", Status = 1 },
                new ProductCategory { Name = "Hàng tiêu dùng - Thực phẩm", Alias = "hang-tieu-dung-thuc-pham", Status = 1 },
                new ProductCategory { Name = "Làm đẹp - Sức khoẻ", Alias = "lam-dep-suc-khoe", Status = 1 },
                new ProductCategory { Name = "Thời trang - Phụ kiện", Alias = "thoi-trang-phu-kien", Status = 1 },
                new ProductCategory { Name = "Thể thao - Dã ngoại", Alias = "the-thao-da-ngoai", Status = 1 },
                new ProductCategory { Name = "Sách - Văn phòng phẩm", Alias = "sach-van-phong-pham", Status = 1 }
                );

            context.SaveChanges();

            context.ProductCategories.AddOrUpdate(c => c.Name,
                new ProductCategory { Name = "Smartphone", Alias = "smart-phone", ParentId = 1, Status = 1 },
                new ProductCategory { Name = "Điện thoại phổ thông", Alias = "dien-thoai-pho-thong", ParentId = 1, Status = 1 },
                new ProductCategory { Name = "Máy tính bảng", Alias = "may-tinh-bang", ParentId = 1, Status = 1 },

                new ProductCategory { Name = "Tivi", Alias = "tivi", ParentId = 2, Status = 1 },
                new ProductCategory { Name = "Loa", Alias = "loa", ParentId = 2, Status = 1 },
                new ProductCategory { Name = "Dàn âm thanh", Alias = "dan-am-thanh", ParentId = 2, Status = 1 },
                new ProductCategory { Name = "Android TV Box, Smart Box", Alias = "android-tv-smart-box", ParentId = 2, Status = 1 },
                new ProductCategory { Name = "Micro", Alias = "micro", ParentId = 2, Status = 1 },
                new ProductCategory { Name = "Phụ kiện Tivi", Alias = "phu-kien-tivi", ParentId = 2, Status = 1 },

                new ProductCategory { Name = "Thiết bị âm thanh", Alias = "thiet-bi-am-thanh", ParentId = 3, Status = 1 },
                new ProductCategory { Name = "Thiết bị đeo công nghệ", Alias = "thiet-bi-deo-cong-nghe", ParentId = 3, Status = 1 },
                new ProductCategory { Name = "Thiết bị game", Alias = "thiet-bi-game", ParentId = 3, Status = 1 },
                new ProductCategory { Name = "Thiết bị mạng", Alias = "thiet-bi-mang", ParentId = 3, Status = 1 },
                new ProductCategory { Name = "Phụ kiện điện thoại", Alias = "phu-kien-dien-thoai", ParentId = 3, Status = 1 },

                new ProductCategory { Name = "Laptop", Alias = "laptop", ParentId = 4, Status = 1 },
                new ProductCategory { Name = "Máy vi tính", Alias = "may-vi-tinh", ParentId = 4, Status = 1 },
                new ProductCategory { Name = "Thiết bị văn phòng", Alias = "thiet-bi-van-phong", ParentId = 4, Status = 1 },
                new ProductCategory { Name = "Linh kiện, phụ kiện máy tính", Alias = "linh-phu-kien-may-tinh", ParentId = 4, Status = 1 },

                new ProductCategory { Name = "Máy ảnh DSLR", Alias = "may-anh-dslr", ParentId = 5, Status = 1 },
                new ProductCategory { Name = "Ống kính (Lens)", Alias = "lens", ParentId = 5, Status = 1 },
                new ProductCategory { Name = "Máy ảnh du lịch", Alias = "may-anh-du-lich", ParentId = 5, Status = 1 },
                new ProductCategory { Name = "Máy quay phim", Alias = "may-quay-phim", ParentId = 5, Status = 1 },
                new ProductCategory { Name = "Phụ kiện máy ảnh", Alias = "phu-kien-may-anh", ParentId = 5, Status = 1 },
                new ProductCategory { Name = "Webcam", Alias = "webcam", ParentId = 5, Status = 1 },


                new ProductCategory { Name = "Đồ dùng nhà bếp", Alias = "do-dung-nha-bep", ParentId = 6, Status = 1 },
                new ProductCategory { Name = "Thiết bị gia đình", Alias = "thiet-bi-gia-dinh", ParentId = 6, Status = 1 },
                new ProductCategory { Name = "Điện lạnh", Alias = "dien-lanh", ParentId = 6, Status = 1 },

                new ProductCategory { Name = "Dụng cụ nhà bếp", Alias = "dung-cu-nha-bep", ParentId = 7, Status = 1 },
                new ProductCategory { Name = "Đồ dùng phòng ăn", Alias = "do-dung-phong-an", ParentId = 7, Status = 1 },
                new ProductCategory { Name = "Đồ dùng phòng ngủ", Alias = "do-dung-phong-ngu", ParentId = 7, Status = 1 },
                new ProductCategory { Name = "Đồ dùng nhà tắm", Alias = "do-dung-phong-tam", ParentId = 7, Status = 1 },
                new ProductCategory { Name = "Nội thất", Alias = "noi-that", ParentId = 7, Status = 1 },
                new ProductCategory { Name = "Đèn - Thiết bị chiếu sáng", Alias = "den-thiet-bi-chieu-sang", ParentId = 7, Status = 1 },
                new ProductCategory { Name = "Trang trí nhà cửa", Alias = "trang-tri-nha-cua", ParentId = 7, Status = 1 },

                new ProductCategory { Name = "Bánh kẹo", Alias = "banh-keo", ParentId = 8, Status = 1 },
                new ProductCategory { Name = "Gia vị", Alias = "gia-vi", ParentId = 8, Status = 1 },
                new ProductCategory { Name = "Chăm sóc thú cưng", Alias = "cham-soc-thu-cung", ParentId = 8, Status = 1 },
                new ProductCategory { Name = "Thực phẩm", Alias = "thuc-pham", ParentId = 8, Status = 1 },
                new ProductCategory { Name = "Đồ uống - giải khát", Alias = "do-uong-giai-khat", ParentId = 8, Status = 1 },
                new ProductCategory { Name = "Chăm sóc nhà cửa", Alias = "cham-soc-nha-cua", ParentId = 8, Status = 1 },
                new ProductCategory { Name = "Bia - nước ngọt", Alias = "bia-nuoc-ngot", ParentId = 8, Status = 1 },


                new ProductCategory { Name = "Chăm sóc da mặt", Alias = "cham-soc-da-mat", ParentId = 9, Status = 1 },
                new ProductCategory { Name = "Chăm sóc cơ thể", Alias = "cham-soc-co-the", ParentId = 9, Status = 1 },
                new ProductCategory { Name = "Dược mỹ phẩm", Alias = "duoc-my-pham", ParentId = 9, Status = 1 },
                new ProductCategory { Name = "Sản phẩm thiên nhiên", Alias = "san-pham-thien-nhien", ParentId = 9, Status = 1 },
                new ProductCategory { Name = "Chăm sóc tóc và da đầu", Alias = "cham-soc-toc-va-da-dau", ParentId = 9, Status = 1 },
                new ProductCategory { Name = "Thực phẩm chức năng", Alias = "thuc-pham-chuc-nang", ParentId = 9, Status = 1 },
                new ProductCategory { Name = "Thiết bị làm đẹp", Alias = "thiet-bi-lam-dep", ParentId = 9, Status = 1 },
                new ProductCategory { Name = "Bộ sản phẩm làm đẹp", Alias = "bo-san-pham-lam-dep", ParentId = 9, Status = 1 },
                new ProductCategory { Name = "Nước hoa", Alias = "nuoc-hoa", ParentId = 9, Status = 1 },
                new ProductCategory { Name = "Tinh dầu spa", Alias = "tinh-dau-spa", ParentId = 9, Status = 1 },

                new ProductCategory { Name = "Thời trang nam", Alias = "thoi-trang-nam", ParentId = 10, Status = 1 },
                new ProductCategory { Name = "Thời trang nữ", Alias = "thoi-trang-nu", ParentId = 10, Status = 1 },
                new ProductCategory { Name = "Mắt kính", Alias = "mat-kinh", ParentId = 10, Status = 1 },
                new ProductCategory { Name = "Đồng hồ", Alias = "dong-ho", ParentId = 10, Status = 1 },
                new ProductCategory { Name = "Trang sức", Alias = "trang-suc", ParentId = 10, Status = 1 },
                new ProductCategory { Name = "Balo", Alias = "balo", ParentId = 10, Status = 1 },

                new ProductCategory { Name = "Đấm bốc và võ thuật", Alias = "dam-boc-va-vo-thuat", ParentId = 11, Status = 1 },
                new ProductCategory { Name = "Dụng cụ tập thể hình", Alias = "dung-cu-tap-the-hinh", ParentId = 11, Status = 1 },
                new ProductCategory { Name = "Hoạt động dã ngoại", Alias = "hoat-dong-da-ngoai", ParentId = 11, Status = 1 },
                new ProductCategory { Name = "Các môn thể thao chơi vợt", Alias = "the-thao-choi-vot", ParentId = 11, Status = 1 },
                new ProductCategory { Name = "Giày và trang phục thể thao", Alias = "giay-trang-phuc-the-thao", ParentId = 11, Status = 1 },
                new ProductCategory { Name = "Thể thao dưới nước", Alias = "the-thao-duoi-nuoc", ParentId = 11, Status = 1 },
                new ProductCategory { Name = "Phụ kiện thể thao, dã ngoại", Alias = "phu-kien-the-thao", ParentId = 11, Status = 1 },

                new ProductCategory { Name = "Sách tiếng Anh", Alias = "sach-tieng-anh", ParentId = 12, Status = 1 },
                new ProductCategory { Name = "Sách tiếng Việt", Alias = "sach-tieng-viet", ParentId = 12, Status = 1 },
                new ProductCategory { Name = "Văn phòng phẩm - Quà lưu niệm", Alias = "van-phong-pham", ParentId = 12, Status = 1 },
                new ProductCategory { Name = "Ebook", Alias = "ebook", ParentId = 12, Status = 1 }


            );

            context.SaveChanges();


        }
    }
}
