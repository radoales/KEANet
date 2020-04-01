namespace KEANet.Tests.SetUps
{
    using KEANet.Data;
    using System.Collections;
    using System.Collections.Generic;
    public class SelectPhoneTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Motorola G99", 800 };
            yield return new object[] { "iPhone 99", 6000 };
            yield return new object[] { "Samsung Galaxy 99", 1000 };
            yield return new object[] { "Sony Xperia 99", 900 };
            yield return new object[] { "Huawei 99", 900 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class BuyTestData : IEnumerable<Product>
    {
        public IEnumerator<Product> GetEnumerator()
        {
            yield return new Product { Id = 1, Name = "Internet Connection", Price = 200, Regularity = Regularity.Monthly };
            yield return new Product { Id = 2, Name = "Phone Line", Price = 150, Regularity = Regularity.Monthly };
            yield return new Product { Id = 3, Name = "Motorola G99", Price = 800, Regularity = Regularity.Once };
            yield return new Product { Id = 4, Name = "iPhone 99", Price = 6000, Regularity = Regularity.Once };
            yield return new Product { Id = 5, Name = "Samsung Galaxy 99", Price = 1000, Regularity = Regularity.Once };
            yield return new Product { Id = 6, Name = "Sony Xperia 99", Price = 900, Regularity = Regularity.Once };
            yield return new Product { Id = 7, Name = "Huawei 99", Price = 900, Regularity = Regularity.Once };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
