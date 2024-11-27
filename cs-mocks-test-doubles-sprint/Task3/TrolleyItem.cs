namespace cs_mocks_test_doubles_sprint.Task3
{
    public class TrolleyItem(string name, decimal price, int quantity)
    {
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public int Quantity { get; set; } = quantity;

    }
}
