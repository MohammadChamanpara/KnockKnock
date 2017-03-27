using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadifyKnockKnock.Controllers;
using System.Web.Http;
using FluentAssertions;
using System.Web.Http.Results;

namespace ReadifyKnockKnock.Tests
{
    [TestClass]
    public class TokenControllerTests
    {
        [TestMethod]
        public void Token_Always_ReturnsOkMyToken()
        {
            //Arrange
            TokenController controller = new TokenController();

            //Act
            IHttpActionResult actionResult = controller.Token();

            //Assert
            actionResult.Should().BeOfType<OkNegotiatedContentResult<string>>("Token action always returns Ok");
            (actionResult as OkNegotiatedContentResult<string>)
                .Content
                .ShouldBeEquivalentTo(TokenController.MyToken);
        }
    }
}
