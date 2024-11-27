using cs_mocks_test_doubles_sprint.Task3;
using FluentAssertions;
using Moq;

namespace Tests;

public class Task3Test
{
    TrolleyItem item1;
    TrolleyItem item2;
    TrolleyItem item3;
    List<TrolleyItem> testTrolleyItems;

    TrolleyItem itemB1;
    TrolleyItem itemB2;
    TrolleyItem itemB3;
    List<TrolleyItem> trolleyItemsB;

    TrolleyItem itemC1;
    TrolleyItem itemC2;
    TrolleyItem itemC3;
    List<TrolleyItem> trolleyItemsC;

    [SetUp]
    public void SetUp()
    {
        //Doesn't have discounted items
        item1 = new TrolleyItem("Wonderful painted goose", 10.5m, 1);
        item2 = new TrolleyItem("Excellent crocheted moorhen", 10m, 4);
        item3 = new TrolleyItem("Tiny glass duck", 0.2m, 1);
        testTrolleyItems = new List<TrolleyItem> { item1, item2, item3 };


        //Has discounted items
        itemB1 = new TrolleyItem("Wonderful painted goose", 10m, 1);
        itemB2 = new TrolleyItem("Excellent crocheted moorhen", 30m, 3);
        itemB3 = new TrolleyItem("Exceptional porcelain sandpiper", 49.99m, 1);
        trolleyItemsB = new List<TrolleyItem> { itemB1, itemB2, itemB3 };
        

        //Total is less than 30
        itemC1 = new TrolleyItem("Wonderful painted goose", 1m, 1);
        itemC2 = new TrolleyItem("Excellent crocheted moorhen", 1m, 1);
        itemC3 = new TrolleyItem("Exceptional porcelain sandpiper", 1m, 1);
        trolleyItemsC = new List<TrolleyItem> { itemC1, itemC2, itemC3 };
    }

    [Test, Description("Checks if CalculateIndividualItems is correctly called")]
    public void CalculateIndividualItem_InvokeCalculateIndividualItemForEachItem()
    {
        var mockCheckoutUtils = new Mock<ICheckoutUtils>();
        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(item1)).Returns(10.5m);
        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(item2)).Returns(30m);
        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(item3)).Returns(0.2m);

        var shoppingTrolley = new ShoppingTrolley(mockCheckoutUtils.Object);

        decimal totalPrice = shoppingTrolley.CalculateTotalPrice(testTrolleyItems);

        mockCheckoutUtils.Verify(m => m.CalculateIndividualItem(item1), Times.Once());
        mockCheckoutUtils.Verify(m => m.CalculateIndividualItem(item2), Times.Once());
        mockCheckoutUtils.Verify(m => m.CalculateIndividualItem(item3), Times.Once());
    }

    [Test, Description("Checks if CalculateIndividualItem returns correct value")]
    public void CalculateIndividualItem_ReturnCorrectValue()
    {
        var checkOutUtil = new CheckoutUtils();

        var result = checkOutUtil.CalculateIndividualItem(item2);

        Assert.That(result, Is.EqualTo(40m));
    }

    [Test, Description("Checks if ShoppingTrolley returns correct value")]
    public void ShoppingTrolley_ReturnsCorrectValue()
    {
        var checkOutUtil = new CheckoutUtils();
        var shoppingTrolley = new ShoppingTrolley(checkOutUtil);

        decimal result =  shoppingTrolley.CalculateTotalPrice(testTrolleyItems);

        Assert.That(result, Is.EqualTo(50.7m));
    }

    [Test]
    public void DiscountPurchase_ReturnDiscountPriceSingleItem()
    {
        var item = new TrolleyItem("Wonderful painted goose", 100m, 1);
        var checkoutUtil = new CheckoutUtils();

        decimal result = checkoutUtil.DiscountPurchase(item);
        result.Should().Be(90m);    
    }

    [Test]
    public void DiscountPurchase_ReturnDiscountPriceMultipleItems()
    {
        var item = new TrolleyItem("Wonderful painted goose", 10m, 10);
        var checkoutUtil = new CheckoutUtils();

        decimal result = checkoutUtil.DiscountPurchase(item);
        result.Should().Be(80m);
    }

    [Test, Description("Checks if CalculateTotalPrice calls DiscountPurchase the correct amount of times")]
    public void CalculateTotalPrice_InvokeDiscountPurchoseOnlyWithQualifyingItems()
    {
        

        var mockCheckoutUtils = new Mock<ICheckoutUtils>();

        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(itemB1)).Returns(10m);
        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(itemB2)).Returns(90m);
        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(itemB3)).Returns(49.99m);
        mockCheckoutUtils.Setup(m => m.DiscountPurchase(itemB2)).Returns(81m);

        var shoppingTrolley = new ShoppingTrolley(mockCheckoutUtils.Object);

        shoppingTrolley.CalculateTotalPrice(trolleyItemsB);

        mockCheckoutUtils.Verify(m => m.DiscountPurchase(itemB1), Times.Never());
        mockCheckoutUtils.Verify(m => m.DiscountPurchase(itemB2), Times.Once());
        mockCheckoutUtils.Verify(m => m.DiscountPurchase(itemB3), Times.Never());
    }

    [Test, Description("Checks if CalculateTotalPrice returns the correct value for discounted items")]
    public void CalculateTotalPrice_ReturnCorrectValue()
    {
        var checkoutUtils = new CheckoutUtils();
        var shoppingTrolley = new ShoppingTrolley(checkoutUtils);

        var result = shoppingTrolley.CalculateTotalPrice(trolleyItemsB);

        result.Should().Be(140.99m);
    }

    [Test, Description("Checks if LogOfferMessage is called when totalprice >= 30m")]
    public void CalculateTotalPrice_CallLogOfferMessageWhenTotalPriceMoreThan30()
    {
        var mockCheckoutUtils = new Mock<ICheckoutUtils>();

        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(item1)).Returns(10.5m);
        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(item2)).Returns(40m);
        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(item3)).Returns(0.6m);


        var shoppingTrolley = new ShoppingTrolley(mockCheckoutUtils.Object);

        shoppingTrolley.CalculateTotalPrice(testTrolleyItems);

        mockCheckoutUtils.Verify(m => m.LogOfferMessage(It.IsAny<decimal>()), Times.Once());
    }

    [Test]
    public void CalculateTotalPrice_DoNotCallLogOfferMessageWhenTotalPriceLessThan30()
    {
        var mockCheckoutUtils = new Mock<ICheckoutUtils>();

        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(itemC1)).Returns(1m);
        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(itemC2)).Returns(1m);
        mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(itemC3)).Returns(1m);

        var shoppingTrolley = new ShoppingTrolley(mockCheckoutUtils.Object);

        shoppingTrolley.CalculateTotalPrice(testTrolleyItems);
        mockCheckoutUtils.Verify(m => m.LogOfferMessage(It.IsAny<decimal>()), Times.Never());
    }

}
