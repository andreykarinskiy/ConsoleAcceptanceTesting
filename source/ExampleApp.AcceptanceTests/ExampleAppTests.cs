using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExampleApp.AcceptanceTests
{
    [TestClass]
    [TestCategory("Acceptance")]
    [DeploymentItem(Const.ApplicationUnderTest)]
    public class ExampleAppTests : ConsoleAppTestFixture
    {
        protected override string AppName => Const.ApplicationUnderTest;

        [DataTestMethod]
        [DataRow("command=help", "Command executed: command=help")]
        public void RunWithArgs(string appArgs, string expected)
        {
            // Arrange, Act
            StartApplicationUnderTest(appArgs);

            // Assert
            Actual.Should().Be(expected);
        }
    }
}