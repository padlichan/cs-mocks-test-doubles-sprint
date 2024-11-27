namespace cs_mocks_test_doubles_sprint.Task1
{
    public class BasicMaths : IBasicMaths
    {
        public double Divide(int x, int y)
        {
            if (y == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }
            return (double)x / y;
        }
        public int Add(int x, int y)
        {
            return x + y; 
        }
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        public int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
