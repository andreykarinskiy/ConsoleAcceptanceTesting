using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace ExampleApp.AcceptanceTests
{
    public abstract class ConsoleAppTestFixture
    {
        public TestContext? TestContext { get; set; }

        protected string? StdOut { get; private set; }

        protected string? StdErr { get; private set; }

        protected string Actual => $"{StdOut}{StdErr}";

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

            process?.WaitForExit(1000);

            return string.IsNullOrEmpty(StdErr);
        }
    }
}
