using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests_Core
{
    [TestClass]
    public class UnitTest1
    {
        private DbContextOptionsBuilder<CoffeeShopContext> optionsBuilder 
            = new DbContextOptionsBuilder<CoffeeShopContext>();

        [TestMethod]
        public void HasNoSeedData()
        {
            optionsBuilder.UseInMemoryDatabase("HasNoSeedData");
            using (var context = new CoffeeShopContext(optionsBuilder.Options))
            {
                var locations = context.Locations.ToList();
                Assert.AreEqual(0, locations.Count());
            }
        }

        [TestMethod]
        public void HasSeedData()
        {
            optionsBuilder.UseInMemoryDatabase("HasSeedData");
            using (var context = new CoffeeShopContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
                Assert.AreNotEqual(0, context.Locations.Count());
            }
        }

        [TestMethod]
        public void RetainChanges()
        {
            optionsBuilder.UseInMemoryDatabase("RetainChanges");
            using (var context = new CoffeeShopContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }
            using (var newContextSameDbName = new CoffeeShopContext(optionsBuilder.Options))
            {
                Assert.AreNotEqual(0, newContextSameDbName.Locations.Count());
            }
        }

        [TestMethod]
        public void ResetWithNoSeedData()
        {
            optionsBuilder.UseInMemoryDatabase("ResetWithSeedData");
            using (var context = new CoffeeShopContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }
            optionsBuilder.UseInMemoryDatabase("NewInMemory");
            using (var newContextNewDbName = new CoffeeShopContext(optionsBuilder.Options))
            {
                Assert.AreEqual(0, newContextNewDbName.Locations.Count());
            }
        }
    }
}