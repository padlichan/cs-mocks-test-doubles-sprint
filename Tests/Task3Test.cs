using cs_mocks_test_doubles_sprint.Task3;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Task3Test
    {
        [Test]
        public void CalculateIndividualItem_InvokeCalculateIndividualItemForEachItem()
        {
            var item1 = new TrolleyItem("Wonderful painted goose", 10.5m, 1);
            var item2 = new TrolleyItem("Excellent crocheted moorhen", 5.1m, 3);
            var item3 = new TrolleyItem("Tiny glass duck", 0.2m, 1);

            var testTrolleyItems = new List<TrolleyItem> { item1, item2, item3 };

            var mockCheckoutUtils = new Mock<ICheckoutUtils>();
            mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(item1)).Returns(10.5m);
            mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(item2)).Returns(15.3m);
            mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(item3)).Returns(0.2m);

            var shoppingTrolley = new ShoppingTrolley(mockCheckoutUtils.Object);

            decimal totalPrice = shoppingTrolley.CalculateTotalPrice(testTrolleyItems);

            Assert.AreEqual(10.5m + 15.3m + 0.2m, totalPrice);
            mockCheckoutUtils.Verify(m => m.CalculateIndividualItem(item1), Times.Once());
            mockCheckoutUtils.Verify(m => m.CalculateIndividualItem(item2), Times.Once());
            mockCheckoutUtils.Verify(m => m.CalculateIndividualItem(item3), Times.Once());
        }
    }
}
