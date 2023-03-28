using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleApp.AcceptanceTests
{
    [TestClass]
    [TestCategory("Acceptance")]
    [DeploymentItem(Const.ApplicationUnderTest)]
    public class ExampleAppTests : ConsoleAppTestFixture
    {
        [TestMethod]
        public void RunWithArgs()
        {
            // Arrange
            string appArgs = "command=help";

            // Act
            StartApplicationUnderTest(Const.ApplicationUnderTest, appArgs);

            // Assert
            Actual.Should().Contain(appArgs);
        }
    }
}