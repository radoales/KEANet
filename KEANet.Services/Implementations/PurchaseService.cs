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
            if (internetConnection == true)
            {
                var internetConnectionfromDb = _db.Products.
                    FirstOrDefault(x => x.Name == "Internet Connection");

                if (internetConnectionfromDb == null)
                {
                    throw new ArgumentException();
                }

                basket.Add(internetConnectionfromDb);
            }
            else
            {
                basket.Remove(_db.Products.FirstOrDefault(x => x.Name == "Internet Connection"));
            }

            return basket.Sum(x => x.Price);
        }

        public int AddPhoneLines()
        {
            if (basket.Count(x => x.Name == "Phone Lines") <= 7)
            {
                try
                {
                    basket.Add(_db.Products.FirstOrDefault(x => x.Name == "Phone Line"));
                }
                catch (Exception e)
                {

                    throw new ArgumentException(e.Message);
                }
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
            if (basket.Count(x => x.Name == "Phone Lines") > 0)
            {
                basket.Remove(_db.Products.FirstOrDefault(x => x.Name == "Phone Line"));
            }
            else
            {
                throw new ArgumentException("There are no lines to remove");
            }

            return basket.Sum(x => x.Price);
        }

        public int SelectPhone(string modelName)
        {
            try
            {
                basket.Add(_db.Products.FirstOrDefault(x => x.Name == modelName));
            }
            catch (Exception e)
            {

                throw new ArgumentException("No selected model to add");
            }

            return basket.Sum(x => x.Price);
        }

        public int UnSelectPhone(string modelName)
        {
            try
            {
                basket.Remove(_db.Products.FirstOrDefault(x => x.Name == modelName));
            }
            catch (Exception e)
            {

                throw new ArgumentException("No selected model to remove");
            }

            return basket.Sum(x => x.Price);
        }
    }
}
