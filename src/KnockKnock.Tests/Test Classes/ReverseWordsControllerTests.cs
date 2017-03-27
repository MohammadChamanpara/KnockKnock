using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadifyKnockKnock.Controllers;
using FluentAssertions;
using System.Web.Http.Results;

namespace ReadifyKnockKnock.Tests
{
    [TestClass]
    public class ReverseWordsControllerTests
    {
        [TestMethod]
        public void ReverseWords_WithoutParameter_ReturnsOkEmptyString()
        {
            //Arrange
            var controller = new ReverseWordsController();

            //Act
            var result = controller.ReverseWords();

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<string>>();
            (result as OkNegotiatedContentResult<string>)
                .Content
                .ShouldBeEquivalentTo(string.Empty);
        }
        [TestMethod]
        public void ReverseWords_WithMultipleWordSentenceParameter_ReturnsReversedSentence()
        {
            //Arrange
            var controller = new ReverseWordsController();
            string input = "12 345 678";
            string expectedOutput = "21 543 876";

            //Act
            var result = controller.ReverseWords(input);

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<string>>();
            (result as OkNegotiatedContentResult<string>)
                .Content
                .ShouldBeEquivalentTo(expectedOutput, "input is \"{0}\"", input);
        }
        [TestMethod]
        public void ReverseWords_WithOneWordSentenceParameter_ReturnsReversedSentence()
        {
            //Arrange
            var controller = new ReverseWordsController();
            string input = "12345";
            string expectedOutput = "54321";

            //Act
            var result = controller.ReverseWords(input);

            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<string>>();
            (result as OkNegotiatedContentResult<string>)
                .Content
                .ShouldBeEquivalentTo(expectedOutput, "input is \"{0}\"", input);
        }
    }
}
