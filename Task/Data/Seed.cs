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
                            Name = "Test3",
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
                            BrandName = "BrandTest",
                            CategoryId = 1,
                            Name= "Envanter item 1",
                            QuantityInStock = 300,
                            SKUCode = "ENVTRITEM1",
                           
                        },
                        new Envanter()
                        {
                            BrandName = "BrandTest",
                            CategoryId = 2,
                            Name= "Envanter item 2",
                            QuantityInStock = 45000,
                            SKUCode = "ENVTRITEM2",
                        },

                    });
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        // Envanter 1 fake products:
                        new Product()
                        {
                            EnvanterId = 1,
                            Description = "Envanter 1 test ürün 1",
                            Name = "ENVANTER1 12'li test ürünü1",
                            Parcel =12,
                            Quantity = 1,
                            Price= 120

                        },
                        new Product()
                        {
                            EnvanterId = 1,
                            Description = "Envanter 1 test ürün 3",
                            Name = "ENVANTER1 6'li test ürünü2",
                            Parcel =6,
                            Quantity = 1,
                            Price= 80
                        },
                        new Product()
                        {
                            EnvanterId = 1,
                            Description = "Envanter 1 test ürün 2",
                            Name = "ENVANTER1 12'li 2 paket test ürünü3",
                            Parcel =12,
                            Quantity = 2,
                            Price= 200
                        },
                        new Product()
                        {
                            EnvanterId = 1,
                            Description = "Envanter 1 test ürün 3",
                            Name = "ENVANTER1 8'li test ürünü 4",
                            Parcel =8,
                            Quantity = 1,
                            Price= 100
                        },
                        // Envanter 2 fake products:
                        new Product()
                        {
                            EnvanterId = 2,
                            Description = "Envanter 2 test ürün 1",
                            Name = "ENVANTER2 12'li test ürünü 1",
                            Parcel =12,
                            Quantity = 1,
                            Price= 130

                        },
                        new Product()
                        {
                            EnvanterId = 2,
                            Description = "Envanter 2 test ürün 3",
                            Name = "ENVANTER2 12'li test ürünü 2",
                            Parcel =6,
                            Quantity = 1,
                            Price= 68
                        },
                        new Product()
                        {
                            EnvanterId = 2,
                            Description = "Envanter 2 test ürün 2",
                            Name = "ENVANTER2  5'li 2 paket toplam 10 adet test ürünü3",
                            Parcel =5,
                            Quantity = 2,
                            Price= 85
                        },
                        new Product()
                        {
                            EnvanterId = 2,
                            Description = "Envanter 2 test ürün 3",
                            Name = "ENVANTER2 6'li 3 paket test ürünü 4",
                            Parcel =6,
                            Quantity = 3,
                            Price= 155
                        }

                    });
                    context.SaveChanges();
                }

            }  
        }
           

    }
}
