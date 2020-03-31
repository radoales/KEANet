using KEANet.Data;
using KEANet.Services.Implementations;
using KEANet.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace KEANet.Tests.SetUps
{
    public static class Mocks
    {
        public static Database MockDataBase()
        {
            var db = new Mock<Database>().Object;
            db.SeedDatabase();
            return db;
        }

        public static PurchaseService MockPurchaseService()
        {
            return new Mock<PurchaseService>(MockDataBase()).Object;
        }

        public static Database EmptyDatabase()
        {
            return new Database();
        }

        public static PurchaseService MockPurchaseServiceWithEmptyDatabase()
        {
            return new Mock<PurchaseService>(EmptyDatabase()).Object;
        }
    }
}
