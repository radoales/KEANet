using KEANet.Data;
using KEANet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KEANet.Services.Implementations
{
    public class PurchaseService : IPurchaseService
    {
        public readonly Database _db;
        public static List<Product> basket = new List<Product>();

        public PurchaseService(Database db)
        {
            this._db = db;
        }
        public int AddInternetConnection(bool internetConnection)
        {
            var internetConnectionfromDb = _db.Products.
                    FirstOrDefault(x => x.Name == "Internet Connection");

            if (internetConnectionfromDb == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (internetConnection == true)
            {

                basket.Add(internetConnectionfromDb);
            }
            else
            {
                basket.Remove(internetConnectionfromDb);
            }

            return basket.Sum(x => x.Price);
        }

        public int AddPhoneLines()
        {
            var phoneLinefromDb = _db.Products.
                    FirstOrDefault(x => x.Name == "Phone Lines");

            if (phoneLinefromDb == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (basket.Count(x => x.Name == "Phone Lines") <= 7)
            {
                basket.Add(phoneLinefromDb);
            }
            else
            {
                throw new ArgumentException("You cannot buy more than 8 lines");
            }

            return basket.Sum(x => x.Price);
        }

        public string Buy()
        {
            if (basket.Count() == 0)
            {
                return "Please select service!";
            }
            else
            {
                StringBuilder basketList = new StringBuilder();

                foreach (var product in basket)
                {
                    basketList.Append($"{product.Name} - {product.Price} - {product.Regularity}");
                    basketList.AppendLine();
                }

                return basketList.ToString();
            }
        }

        public int RemovePhoneLines()
        {
            var phoneLinefromDb = _db.Products.
                    FirstOrDefault(x => x.Name == "Phone Lines");

            if (phoneLinefromDb == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (basket.Count(x => x.Name == "Phone Lines") > 0)
            {
                basket.Remove(phoneLinefromDb);
            }
            else
            {
                throw new ArgumentException("There are no lines to remove");
            }

            return basket.Sum(x => x.Price);
        }

        public int SelectPhone(string modelName)
        {
            var phoneModelFromDb = _db.Products
                .FirstOrDefault(x => x.Name == modelName);

            if (phoneModelFromDb == null)
            {
                throw new ArgumentException("No selected model to add");
            }

            basket.Add(phoneModelFromDb);

            return basket.Sum(x => x.Price);
        }

        public int UnSelectPhone(string modelName)
        {
            var phoneModelFromDb = _db.Products
               .FirstOrDefault(x => x.Name == modelName);

            if (phoneModelFromDb == null)
            {
                throw new ArgumentException("No selected model to add");
            }

            basket.Remove(phoneModelFromDb);

            return basket.Sum(x => x.Price);
        }
    }
}
