using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace ExampleApp.AcceptanceTests
{
    /// <summary>
    /// Acceptance testing fixture for console applications.
    /// </summary>
    public abstract class ConsoleAppTestFixture
    {
        /// <summary>
        /// Used to store information that is provided to unit tests.
        /// </summary>
        public TestContext? TestContext { get; set; }

        /// <summary>
        /// Application under test full file name.
        /// Best taken from ApplicationUnderTest constant of Const static class.
        /// </summary>
        protected abstract string AppName { get; }

        /// <summary>
        /// The standard output stream of a console application.
        /// </summary>
        protected string? StdOut { get; private set; }

        /// <summary>
        /// Console application standard error stream.
        /// </summary>
        protected string? StdErr { get; private set; }

        /// <summary>
        /// A textual representation of the result of executing a console application. 
        /// Assembled from StdOut and StdErr (if used).
        /// </summary>
        protected string ConsoleOutput => $"{StdOut}{StdErr}".Trim();

        /// <summary>
        /// The method that starts the application under test. 
        /// Passes input parameters and returns the result in the Actual property.
        /// </summary>
        /// <param name="appArgs">Input parameters</param>
        /// <returns>Success?</returns>
        protected bool RunApplicationUnderTest(string appArgs) => StartApplicationUnderTest(AppName, appArgs);

        /// <summary>
        /// The method that starts the application under test. 
        /// Passes input parameters and returns the result in the Actual property.
        /// </summary>
        /// <param name="appName">Application under test name</param>
        /// <param name="appArgs">Input parameters</param>
        /// <returns>Success?</returns>
        protected bool StartApplicationUnderTest(string appName, string appArgs)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = appName,
                Arguments = appArgs,

                WorkingDirectory = TestContext!.DeploymentDirectory,

                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
            };

            using var process = Process.Start(processInfo);
            
            StdOut = process?.StandardOutput.ReadToEnd();
            StdErr = process?.StandardError.ReadToEnd();

            Console.WriteLine(ConsoleOutput);

            process?.WaitForExit(1000);
            
            return string.IsNullOrEmpty(StdErr);
        }
    }
}
