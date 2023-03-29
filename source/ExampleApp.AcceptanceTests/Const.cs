namespace ExampleApp.AcceptanceTests
{
    /// <summary>
    /// Global constants of test set.
    /// </summary>
    public static class Const
    {
        /// <summary>
        /// Application under test file name (with extension).
        /// </summary>
        public const string AppFile = "ExampleApp.exe";

        /// <summary>
        /// Application under test publishing path.
        /// </summary>
        public const string PublishingDir = "../../../../ExampleApp/publish/";

        /// <summary>
        /// Application under test full file name.
        /// </summary>
        public const string ApplicationUnderTest = PublishingDir + AppFile;
    }
}
