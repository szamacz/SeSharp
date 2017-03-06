using Core.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumCore.Pages;
using System.Configuration;

namespace SeleniumCore
{
    public class Base
    {
        public static IWebDriver Instance { get; set; }
        private static string browser = ConfigurationManager.AppSettings["Browser"];
        public Google Google;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            Initialize();
            Google = new Google();
            ExtentManager.Extent = ExtentManager.Instance;
            ExtentManager.AddSystemInfo("Browser", browser);
        }

        [SetUp]
        public void BeforeEach()
        {
            ExtentManager.StartTest();
        }

        [TearDown]
        public void AfterEach()
        {
            ExtentManager.SetTestStatus();
            ExtentManager.AddScreenshotToReport();
            ExtentManager.EndTest();
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            ExtentManager.EndReport();
            CleanUp();
        }

        private static void Initialize()
        {
            Instance = GetDriver();
            Instance.Manage().Window.Maximize();
        }

        private static void CleanUp()
        {
            Instance.Quit();
        }

        private static IWebDriver GetDriver()
        {
            IWebDriver driver;
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    System.Environment.SetEnvironmentVariable("webdriver.ie.driver", Constant.PATH_TO_IE_DRIVER_SERVER);
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            return driver;
        }
    }
}
