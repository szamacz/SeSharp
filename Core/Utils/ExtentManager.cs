using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;


namespace Core.Utils
{
    public class ExtentManager
    {
        public static ExtentReports Extent { get; set; }

        public static ExtentTest Test { get; set; }

        private static readonly ExtentReports _instance = new ExtentReports(Constant.PATH_TO_TEST_REPORT + "TestReport.html", DisplayOrder.OldestFirst);

        static ExtentManager() { }

        public ExtentManager() { }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Set status of test on test report
        /// </summary>
        public static void SetTestStatus()
        {
            var status = GetTestStatus();
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                     ? ""
                     : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);

            LogStatus logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = LogStatus.Skip;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            Test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
        }

        /// <summary>
        /// Ends test report
        /// </summary>
        public static void EndReport()
        {
            Extent.Flush();
        }

        /// <summary>
        /// Ends test on test report
        /// </summary>
        public static void EndTest()
        {
            Extent.EndTest(Test);
        }

        private static TestStatus GetTestStatus()
        {
            return TestContext.CurrentContext.Result.Outcome.Status;
        }

        /// <summary>
        /// Starts test on test report
        /// </summary>
        public static void StartTest()
        {
            Test = Extent.StartTest(TestContext.CurrentContext.Test.Name);
        }

        /// <summary>
        /// Ads screenshot to test report
        /// </summary>
        public static void AddScreenshotToReport()
        {
            string fileName = Constant.PATH_TO_SCREENSHOTS + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".jpg";
            Screenshot.TakeScreenshot(fileName);
            Test.Log(LogStatus.Info, "Snapshot from last step below: " + Test.AddScreenCapture(fileName));
        }

        /// <summary>
        /// Asings test category for test in test report
        /// </summary>
        /// <param name="Categories"></param>
        public static void AssignTestCategory(params string[] Categories)
        {
            Test.AssignCategory(Categories);
        }

        /// <summary>
        /// Ads system info
        /// </summary>
        /// <param name="Param"></param>
        /// <param name="Value"></param>
        public static void AddSystemInfo(string Param, string Value)
        {
            Extent.AddSystemInfo(Param, Value);
        }
    }

}
