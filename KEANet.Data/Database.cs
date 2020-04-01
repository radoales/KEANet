using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using KEANet.Data;

namespace KEANet.Data
{
    public class Database
    {
        public List<Product> Products;

        private readonly IEnumerable<Product> productsSeed = new List<Product>()
            {
                new Product{Id = 1, Name = "Internet Connection", Price = 200, Regularity = Regularity.Monthly},
                new Product{Id = 2, Name = "Phone Line", Price = 150, Regularity = Regularity.Monthly},
                new Product{Id = 3, Name = "Motorola G99", Price = 800, Regularity = Regularity.Once},
                new Product{Id = 4, Name = "iPhone 99", Price = 6000, Regularity = Regularity.Once},
                new Product{Id = 5, Name = "Samsung Galaxy 99", Price = 1000, Regularity = Regularity.Once},
                new Product{Id = 6, Name = "Sony Xperia 99", Price = 900, Regularity = Regularity.Once},
                new Product{Id = 7, Name = "Huawei 99", Price = 900, Regularity = Regularity.Once}
            };

        public Database()
        {
            this.Products = new List<Product>();
        }

        public void SeedDatabase()
        {
            Products.AddRange(productsSeed);
        }
    }
}
