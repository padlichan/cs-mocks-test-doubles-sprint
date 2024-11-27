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
                //invoke your method here
            }
            return totalPrice;
        }
    }
}
