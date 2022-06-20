using ShopManager;
using Moq;
using Xunit;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DBInterfaceTests
    {

        [TestMethod]
        public void Test_GetItems()
        {
            var dbInteface = new Mock<DBInterface>();
            dbInteface.Setup(x => x.getItems()).Returns(
                new List<Item> {
                    new Item{Id = 0, Name = "Item01", Quantity = 1, Price = 1.99},
                    new Item{Id = 1, Name = "Item02", Quantity = 2, Price = 2.99},
                    new Item{Id = 2, Name = "Item03", Quantity = 3, Price = 3.99},
                }
            );
           

            var dbManager = new DBManager(dbInteface.Object);
            var result = dbManager.GetItems();

            Xunit.Assert.Equal(3, result.Count);
        }
    }
}
