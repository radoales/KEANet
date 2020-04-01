namespace KEANet.Tests.SetUps
{
    using KEANet.Data;
    using KEANet.Services.Implementations;
    using Moq;

    public static class Mocks
    {
        public static Database MockDataBase()
        {
            var db = new Database();
            db.SeedDatabase();
            return db;
        }

        public static PurchaseService MockPurchaseService()
        {
            var db = new Database();
            db.SeedDatabase();
            return new Mock<PurchaseService>(db).Object;
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
