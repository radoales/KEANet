using KEANet.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KEANet.Tests.SetUps
{
    public class BuyTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
            new Product { Id = 1, Name = "Internet Connection", Price = 200, Regularity = Regularity.Monthly },
            new Product { Id = 2, Name = "Phone Line", Price = 150, Regularity = Regularity.Monthly},
            new Product { Id = 2, Name = "Phone Line", Price = 150, Regularity = Regularity.Monthly }
            };
            yield return new object[]
           {
            new Product { Id = 1, Name = "Internet Connection", Price = 200, Regularity = Regularity.Monthly },
            new Product { Id = 2, Name = "Phone Line", Price = 150, Regularity = Regularity.Monthly},
            new Product { Id = 7, Name = "Huawei 99", Price = 900, Regularity = Regularity.Once }
           };
            yield return new object[]
           {
            new Product { Id = 1, Name = "Internet Connection", Price = 200, Regularity = Regularity.Monthly },
            new Product { Id = 2, Name = "Phone Line", Price = 150, Regularity = Regularity.Monthly},
            new Product { Id = 5, Name = "Samsung Galaxy 99", Price = 1000, Regularity = Regularity.Once },
           };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
