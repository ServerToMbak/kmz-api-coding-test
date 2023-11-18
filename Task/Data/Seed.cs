using Task.Entities;

namespace Task.Data
{
    public static class Seed
    {
        public static void SeedDataForTest(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Name = "Test1",
                        },
                        new Category()
                        {
                            Name = "Test2",
                        },

                    });
                    context.SaveChanges();
                }

                if (!context.Envanters.Any())
                {
                    context.Envanters.AddRange(new List<Envanter>()
                    {
                        new Envanter()
                        {
                            Name = "TENİS RAKETi",
                            SKUCode="RKT",
                            StockQuantity=110

                        },
                        new Envanter()
                        {
                            Name = "TENİS TOPU",
                            SKUCode="RKT",
                            StockQuantity=300

                        },
                        new Envanter()
                        {
                            Name = "TEST1 ",
                            SKUCode="TEST1",
                            StockQuantity=120

                        },
                         new Envanter()
                         {
                            Name = "TEST2 ",
                            SKUCode="TEST2",
                            StockQuantity=100
                         },
                         new Envanter()
                         {
                            Name = "TEST3 ",
                            SKUCode="TEST3",
                            StockQuantity=100
                         },

                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        
                        new Product()
                        {
                            EnvanterItems= new List<EnvanterItem>()
                            {
                                new EnvanterItem() { EnvanterId =1,Parcel=1, Quantity=50},
                                new EnvanterItem() { EnvanterId =2,Parcel=1, Quantity=5 },
                            },
                            BrandName = "Marka Test",
                            CategoryId=1,
                            Description = "Category 1 için test ürünü; tenis raketi ve topu",
                            Name = "Test prouct1 itemler; raket ve top",
                            Price = 520,
                            
                        },
                        new Product()
                        {
                            EnvanterItems= new List<EnvanterItem>()
                            {
                                new EnvanterItem() { EnvanterId =1,Parcel=3, Quantity=50},
                                new EnvanterItem() { EnvanterId =2,Parcel=1, Quantity=5 },
                            },
                            BrandName = "Marka Test1",
                            CategoryId=1,
                            Description = "Category 1 için test ürünü; tenis raketi ve topu",
                            Name = "Test prouct2 itemler; raket ve top",
                            Price = 600,

                        },
                        new Product()
                        {
                            EnvanterItems= new List<EnvanterItem>()
                            {
                                new EnvanterItem() { EnvanterId =3,Parcel=2, Quantity=6},
                                new EnvanterItem() { EnvanterId =2,Parcel=1, Quantity=10 },
                            },
                            BrandName = "Marka Test2",
                            CategoryId=2,
                            Description = "Category 2 için test ürünleri",
                            Name = "Test prouct3 itemler; raket ve top",
                            Price = 405,

                        },
                        new Product()
                        {
                            EnvanterItems= new List<EnvanterItem>()
                            {
                                new EnvanterItem() { EnvanterId =3,Parcel=2, Quantity=6},
                                new EnvanterItem() { EnvanterId =5,Parcel=10, Quantity=3 },
                            },
                            BrandName = "Marka Test1",
                            CategoryId=2,
                            Description = "Category 2 için test ürünleri",
                            Name = "Test prouct3 itemler; raket ve top",
                            Price = 425,

                        },
                       new Product()
                        {
                            EnvanterItems= new List<EnvanterItem>()
                            {
                                new EnvanterItem() { EnvanterId =1,Parcel=1, Quantity=50},
                                new EnvanterItem() { EnvanterId =2,Parcel=1, Quantity=5 },
                            },
                            BrandName = "Marka Test",
                            CategoryId=1,
                            Description = "Category 1 için test ürünleri",
                            Name = "Test prouct1 itemler; raket ve top",
                            Price = 300,

                        },
                        // Envanter 2 fake products:
                        new Product()
                        {
                            EnvanterItems= new List<EnvanterItem>()
                            {
                                new EnvanterItem() { EnvanterId =1,Parcel=1, Quantity=50},
                                new EnvanterItem() { EnvanterId =2,Parcel=1, Quantity=5 },
                            },
                            BrandName = "Marka Test",
                            CategoryId=1,
                            Description = "Category 1 için test ürünü",
                            Name = "Test prouct1 itemler; raket ve top",
                            Price = 350,

                        },
                    });
                    context.SaveChanges();
                }

            }
        }


    }
}
