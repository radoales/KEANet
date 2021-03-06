﻿namespace KEANet.Services.Implementations
{
    using KEANet.Data;
    using KEANet.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PurchaseService : IPurchaseService
    {
        public readonly Database _db;
        public List<Product> basket;

        public PurchaseService(Database db)
        {
            this._db = db;
            this.basket = new List<Product>();
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
                if (!basket.Contains(internetConnectionfromDb))
                {
                    throw new ArgumentException("There is no Internet Connection to be removed");
                }
                basket.Remove(internetConnectionfromDb);
            }

            return basket.Sum(x => x.Price);
        }

        public int AddPhoneLines()
        {
            const string productName = "Phone Line";

            var phoneLinefromDb = _db.Products.
                    FirstOrDefault(x => x.Name == productName);

            if (phoneLinefromDb == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (basket.Count(x => x.Name == productName) <= 7)
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
                throw new ArgumentException("Please select service!");
            }

            StringBuilder basketList = new StringBuilder();

            foreach (var product in basket)
            {
                basketList.Append($"{product.Name} - {product.Price} - {product.Regularity}");
                basketList.AppendLine();
            }

            return basketList.ToString().Trim();
        }

        public int RemovePhoneLines()
        {
            const string productName = "Phone Line";

            var phoneLinefromDb = _db.Products.
                    FirstOrDefault(x => x.Name == productName);

            if (phoneLinefromDb == null)
            {
                throw new ArgumentException("Product not found");
            }

            var phoneLineInBasket = basket.FirstOrDefault(x => x.Name == productName);
            if (phoneLineInBasket == null)
            {
                throw new ArgumentException("There are no lines to remove");
            }

            var phoneLineIndexInBasket = basket.FindIndex(x => x.Name == productName);
            basket.Remove(phoneLinefromDb);

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
                throw new ArgumentException("No selected model to remove");
            }

            var modelInBasket = basket.FirstOrDefault(x => x.Name == modelName);
            if (modelInBasket == null)
            {
                throw new ArgumentException("No such model in the basket");
            }

            var modelIndexInBasket = basket.FindIndex(x => x.Name == modelName);

            basket.RemoveAt(modelIndexInBasket);

            return basket.Sum(x => x.Price);
        }
    }
}
