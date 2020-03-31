using System.Collections.Generic;

namespace KEANet.Data
{
    public class Purchase
    {
        public int Id { get; set; }
        public bool InternetConnection { get; set; }
        public int PhoneLines { get; set; }
        public IEnumerable<string> CellPhones { get; set; }
        public int Price { get; set; }
    }
}
