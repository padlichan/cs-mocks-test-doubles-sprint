namespace cs_mocks_test_doubles_sprint.Task3
{
    public interface ICheckoutUtils
    {
        decimal CalculateIndividualItem(TrolleyItem item);

        decimal DiscountPurchase(TrolleyItem item);

        void LogOfferMessage(decimal amount);
    }
}