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
}