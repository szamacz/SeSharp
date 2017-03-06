using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumCore;


namespace Core.Utils
{
    public class Helper
    {
        /// <summary>
        /// Highlights element
        /// </summary>
        /// <param name="element"></param>
        public static void Highligh(IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)Base.Instance;
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: green"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }

    }
}
