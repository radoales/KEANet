using System;
using System.Collections.Generic;
using System.Text;

namespace KEANet.Data
{
    public enum Regularity
    {
        Once,
        Monthly
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Regularity Regularity { get; set; }
    }
}
