using Xunit;
using FluentAssertions;
using Moq;
using System;
using System.Reflection;

namespace HelloWorld.Tests
{
    public class ATests
    {
        [Fact]
        public void f1_Should_Return_Correct_Value()
        {
            // Arrange
            int input = 1;
            int expected = 2;

            // Act
            int result = A.f1(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void f2_Should_Return_Correct_Value()
        {
            // Arrange
            int input = 2;
            int expected = 4;

            // Act
            int result = A.f2(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void f5_Should_Return_Correct_Value()
        {
            // Arrange
            int x = 5;
            int y = 2;
            double expected = 2.0;

            // Act
            double result = A.f5(x, y);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void f6_Should_Return_Correct_Value()
        {
            // Arrange
            int input = 3;
            int expected = 8;

            // Act
            int result = A.f6(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void f7_Should_Return_Correct_String()
        {
            // Arrange
            string input = "hello";
            string expected = "hello more stuff";

            // Act
            string result = A.f7(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void f8_Should_Return_Correct_Value()
        {
            // Arrange
            int input = 1;
            int expected = 9;
            var mockA = new Mock<IA>();
            mockA.Setup(a => a.f8(It.IsAny<int>())).Returns(expected);

            // Act
            int result = B.g1(input, mockA.Object);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Test_Private_Method_Using_Reflection()
        {
            // Arrange
            int input = 1;
            int expected = 5;
            var methodInfo = typeof(A).GetMethod("f4", BindingFlags.NonPublic | BindingFlags.Static);
            var parameters = new object[] { input };

            // Act
            int result = (int)methodInfo.Invoke(null, parameters);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Test_Protected_Method_Using_Reflection()
        {
            // Arrange
            int input = 1;
            int expected = 4;
            var methodInfo = typeof(A).GetMethod("f3", BindingFlags.NonPublic | BindingFlags.Static);
            var parameters = new object[] { input };

            // Act
            int result = (int)methodInfo.Invoke(null, parameters);

            // Assert
            result.Should().Be(expected);
        }
    }
}
