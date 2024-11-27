using cs_mocks_test_doubles_sprint.Task1;

namespace Tests
{
    public class TaskOneTests
    {
        [Test, Description("Returns the result when one integer is evenly divided by a factor of itself")]
        public void Divide_Evenly()
        {
            //Arrange
            var testBasicMaths = new BasicMaths();
            //Act
            var result = testBasicMaths.Divide(4, 2);
            //Assert
            Assert.That(result, Is.EqualTo(2));
        }
        [Test, Description("Returns the result when the divisor is not a factor of the dividend")]
        public void Divide_Unevenly()
        {
            //Arrange
            var testBasicMaths = new BasicMaths();
            //Act
            var result = testBasicMaths.Divide(5, 2);
            //Assert
            Assert.That(result, Is.EqualTo(2.5));
        }
        [Test, Description("Throws an error if an attempt is made to pass 0 as a divisor")]
        public void Divide_ByZero()
        {
            //Arrange
            var testBasicMaths = new BasicMaths();
            //Act
            //Assert
            Assert.That(() => testBasicMaths.Divide(5, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}