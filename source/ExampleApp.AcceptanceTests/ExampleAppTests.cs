using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleApp.AcceptanceTests
{
    [TestClass]
    [TestCategory("Acceptance")]
    [DeploymentItem(Const.ApplicationUnderTest)]
    public class ExampleAppTests : ConsoleAppTestFixture
    {
        [DataTestMethod]
        [DataRow("command=help", "Command executed: command=help")]
        public void RunWithArgs(string args, string expected)
        {
            // Arrange, Act
            StartApplicationUnderTest(Const.ApplicationUnderTest, args);

            // Assert
            Actual.Should().Be(expected);
        }
    }
}