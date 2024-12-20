﻿using cs_mocks_test_doubles_sprint.Task1;

namespace cs_mocks_test_doubles_sprint.Task2
{
    public class AdvancedMaths
    {
        private readonly IBasicMaths _basicMaths;

        public AdvancedMaths(IBasicMaths basicMaths)
        {
            _basicMaths = basicMaths;
        }

        public int MultiplyIntsAndAddFive(int a, int b)
        {
            int result = _basicMaths.Multiply(a, b);
            return _basicMaths.Add(result, 5);
        }

        public int SubtractAndMultiply(int a, int b, int c)
        {
            int result = _basicMaths.Subtract(a, b);
            return _basicMaths.Multiply(result, c);
        }

        public double AddIntsAndDivideByTwo(int a, int b)
        {
            return _basicMaths.Divide(_basicMaths.Add(a,b), 2);
        }

        public int QuarterAndSubtractOne(int value)
        {
            int quarter = (int)Math.Round((double)_basicMaths.Divide(value, 4));
            return _basicMaths.Subtract(quarter, 1);
        }

        public double MultiplyAndDivide(int a, int b, int c)
        {
            return _basicMaths.Divide(_basicMaths.Multiply(a,b),c);
        }
    }
}
