using FluentAssertions;

namespace cs_mocks_test_doubles_sprint.Task3
{
       public class ShoppingTrolley
    {
        private readonly ICheckoutUtils _checkoutUtils;

        public ShoppingTrolley(ICheckoutUtils checkoutUtils)
        {
            _checkoutUtils = checkoutUtils;
        }

        public decimal CalculateTotalPrice(List<TrolleyItem> trolleyItems)
        {
            decimal totalPrice = 0.0m;
            foreach (TrolleyItem item in trolleyItems)
            {
                var itemPrice = _checkoutUtils.CalculateIndividualItem(item);
                totalPrice += itemPrice >= 50m ? _checkoutUtils.DiscountPurchase(item) : itemPrice;
            }
            Console.WriteLine(totalPrice);
            if(totalPrice >= 30m) _checkoutUtils.LogOfferMessage(totalPrice);
            return totalPrice;
        }
    }
}
