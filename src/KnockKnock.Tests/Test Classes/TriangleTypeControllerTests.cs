using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadifyKnockKnock.Controllers;
using FluentAssertions;
using System.Web.Http.Results;

namespace ReadifyKnockKnock.Tests
{
    [TestClass]
    public class TriangleTypeControllerTests
    {
        [TestMethod]
        public void TriangleType_WithEqualSides_ReturnsEquilateral()
        {
            //Arrange
            var controller = new TriangleTypeController();

            //Act
            var result = controller.TriangleType(5, 5, 5);

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<string>>();
            (result as OkNegotiatedContentResult<string>)
                .Content
                .ShouldBeEquivalentTo(TriangleTypeController.TriangleTypes.Equilateral.ToString());
        }
        [TestMethod]
        public void TriangleType_WithTwoEqualSides_ReturnsIsosceles()
        {
            //Arrange
            var controller = new TriangleTypeController();

            //Act
            var result = controller.TriangleType(4, 5, 5);

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<string>>();
            (result as OkNegotiatedContentResult<string>)
                .Content
                .ShouldBeEquivalentTo(TriangleTypeController.TriangleTypes.Isosceles.ToString());
        }

        [TestMethod]
        public void TriangleType_WithNoEqualSides_ReturnsScalene()
        {
            //Arrange
            var controller = new TriangleTypeController();

            //Act
            var result = controller.TriangleType(3, 4, 5);

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<string>>();
            (result as OkNegotiatedContentResult<string>)
                .Content
                .ShouldBeEquivalentTo(TriangleTypeController.TriangleTypes.Scalene.ToString());
        }
        [TestMethod]
        public void TriangleType_WithImpossibleSides_ReturnsError()
        {
            //Arrange
            var controller = new TriangleTypeController();

            //Act
            var result = controller.TriangleType(1, 1, 5);

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<string>>();
            (result as OkNegotiatedContentResult<string>)
                .Content
                .ShouldBeEquivalentTo(TriangleTypeController.TriangleTypes.Error.ToString());
        }
    }
}
