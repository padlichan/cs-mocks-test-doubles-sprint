using cs_mocks_test_doubles_sprint.Task1;
using cs_mocks_test_doubles_sprint.Task2;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Task2Test
    {
        [Test]
        public void MultiplyIntsAndAddFive_ReturnCorrectResult()
        {
            // Arrange
            var mockBasicMaths = new Mock<IBasicMaths>();
            mockBasicMaths.Setup(m => m.Multiply(40, 2)).Returns(80);
            mockBasicMaths.Setup(m => m.Add(80, 5)).Returns(85);

            var advancedMaths = new AdvancedMaths(mockBasicMaths.Object);

            // Act

            int result = advancedMaths.MultiplyIntsAndAddFive(40, 2);

            // Assert
            result.Should().Be(85);
            
            mockBasicMaths.Verify(m => m.Multiply(40,2), Times.Once());

        }
        [Test]
        public void SubtractAndMultiply_ReturnCorrectResult()
        {
            var mockBasicMaths = new Mock<IBasicMaths>();
            mockBasicMaths.Setup(m => m.Subtract(10, 5)).Returns(5);
            mockBasicMaths.Setup(m => m.Multiply(5, 5)).Returns(25);
            var advancedMaths = new AdvancedMaths(mockBasicMaths.Object);

            int result = advancedMaths.SubtractAndMultiply(10, 5, 5);

            result.Should().Be(25);

            mockBasicMaths.Verify(m => m.Subtract(10, 5), Times.Once());
            mockBasicMaths.Verify(m => m.Multiply(5,5), Times.Once());  
        }
    }
}
