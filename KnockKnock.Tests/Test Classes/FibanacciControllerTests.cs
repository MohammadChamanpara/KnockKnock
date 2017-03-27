using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadifyKnockKnock.Controllers;
using System.Web.Http;
using FluentAssertions;
using System.Web.Http.Results;

namespace ReadifyKnockKnock.Tests
{
    [TestClass]
    public class FibanacciControllerTests
    {
        /* I use Action_Condition_Expectation naming convention in my unit test methods.*/

        [TestMethod]
        public void Fibonacci_WithPositiveParameter_ReturnsNthNumber()
        {
            //Arrange
            FibonacciController controller = new FibonacciController();
            var expectedResults = new long[] { 0, 1, 1, 2, 3, 5 };
            var actualResults = new IHttpActionResult[expectedResults.Length];

            //Act
            for (int i = 0; i < expectedResults.Length; i++)
            {
                actualResults[i] = controller.Fibonacci(i);
            }

            //Assert
            for (int i = 0; i < expectedResults.Length; i++)
            {
                actualResults[i].Should().BeOfType<OkNegotiatedContentResult<long>>();
                (actualResults[i] as OkNegotiatedContentResult<long>)
                    .Content
                    .ShouldBeEquivalentTo
                    (
                        expectedResults[i],
                        "Fibonacci({0})={1}", i, expectedResults[i]
                    );
            }
        }
        [TestMethod]
        public void Fibonacci_WithNegativeParameter_ReturnsMinusNthNumber()
        {
            //Arrange
            FibonacciController controller = new FibonacciController();
            var expectedResults = new long[] { 0, 1, -1, 2, -3, 5 };
            var actualResults = new IHttpActionResult[expectedResults.Length];

            //Act
            for (int i = 0; i < expectedResults.Length; i++)
            {
                actualResults[i] = controller.Fibonacci(-i);
            }

            //Assert
            for (int i = 0; i < expectedResults.Length; i++)
            {
                actualResults[i].Should().BeOfType<OkNegotiatedContentResult<long>>();
                (actualResults[i] as OkNegotiatedContentResult<long>)
                    .Content
                    .ShouldBeEquivalentTo
                    (
                        expectedResults[i],
                        "Fibonacci({0})={1}", i, expectedResults[i]
                    );
            }
        }
        [TestMethod]
        public void Fibonacci_WithBigNumber_ReturnsBadRequest()
        {
            //Arrange
            FibonacciController controller = new FibonacciController();

            //Act
            IHttpActionResult actionResult = controller.Fibonacci(1000);

            //Assert
            actionResult.Should().BeOfType<BadRequestResult>();
        }


    }
}
