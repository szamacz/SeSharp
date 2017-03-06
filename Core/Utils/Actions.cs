using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Utils
{
    public class Actions
    {
        private static WebDriverWait wait()
        {
            return new WebDriverWait(Base.Instance, TimeSpan.FromSeconds(Constant.TIMEOUT_IN_SECONDS));
        }

        /// <summary>
        /// Waits for element to be visible
        /// </summary>
        /// <param name="element"></param>
        /// <param name="elementName"></param>
        public static void WaitForVisible(IWebElement element, String elementName)
        {
            try
            {
                ExtentManager.Test.Log(LogStatus.Info, "Waiting for " + elementName + " to be visible");
                wait().Until(d => element.Displayed);
                Helper.Highligh(element);
                ExtentManager.Test.Log(LogStatus.Pass, "Element " + elementName + " is visible");
            }
            catch (NoSuchElementException)
            {
                ExtentManager.Test.Log(LogStatus.Error, "Element " + elementName + " is not visible or not found");
                throw;
            }
        }
        /// <summary>
        /// Waits for element to be clickable
        /// </summary>
        /// <param name="element"></param>
        /// <param name="elementName"></param>
        public static void WaitForClickable(IWebElement element, String elementName)
        {
            try
            {
                ExtentManager.Test.Log(LogStatus.Info, "Waiting for " + elementName + " to be clickable");
                wait().Until(ExpectedConditions.ElementToBeClickable(element));
                Helper.Highligh(element);
                ExtentManager.Test.Log(LogStatus.Pass, "Element " + elementName + " is clickable");
            }
            catch (NoSuchElementException e)
            {
                ExtentManager.Test.Log(LogStatus.Error, "Element " + elementName + " is not visible or not found");
                throw e;
            }
        }

        /// <summary>
        /// Clicks on element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="elementName"></param>
        public static void Click(IWebElement element, String elementName)
        {
            try
            {
                ExtentManager.Test.Log(LogStatus.Info, "Trying to click on " + elementName);
                Helper.Highligh(element);
                element.Click();
                ExtentManager.Test.Log(LogStatus.Pass, "Clicked on element " + elementName);
            }
            catch (NoSuchElementException e)
            {
                ExtentManager.Test.Log(LogStatus.Error, "Element " + elementName + " cannot be clicked");
                throw e;
            }
        }

        /// <summary>
        /// Waits for title to contain text
        /// </summary>
        /// <param name="text"></param>
        public static void WaitFoTitleToContain(string text)
        {
            try
            {
                ExtentManager.Test.Log(LogStatus.Info, "Waiting for title to contains " + text);
                wait().Until(ExpectedConditions.TitleContains(text));
                ExtentManager.Test.Log(LogStatus.Pass, "Title contains " + text);
            }
            catch (Exception e)
            {
                ExtentManager.Test.Log(LogStatus.Pass, "Title not contain " + text + "Title was: " + Base.Instance.Title);
                throw e;
            }

        }

        /// <summary>
        /// Sends text to element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        /// <param name="elementName"></param>
        public static void SendKeys(IWebElement element, String text, String elementName)
        {
            try
            {
                ExtentManager.Test.Log(LogStatus.Info, "Sending " + text + " to element " + elementName);
                Helper.Highligh(element);
                element.SendKeys(text);
                ExtentManager.Test.Log(LogStatus.Pass, text + " sent to " + elementName);
            }
            catch (NoSuchElementException e)
            {
                ExtentManager.Test.Log(LogStatus.Error, "Element " + elementName + " not found");
                throw e;
            }
        }

        /// <summary>
        /// Opens page
        /// </summary>
        /// <param name="URL"></param>
        public static void openPage(String URL)
        {
            try
            {
                ExtentManager.Test.Log(LogStatus.Info, "Opening page " + URL);
                Base.Instance.Url = URL;
                wait().Until(ExpectedConditions.UrlContains(URL));
                ExtentManager.Test.Log(LogStatus.Pass, "Page " + URL + " opened");
            }
            catch (Exception)
            {
                ExtentManager.Test.Log(LogStatus.Error, "Page " + URL + " cannot be open");
                throw;
            }
        }

        /// <summary>
        /// Waits for all elements to be visible
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="elementsName"></param>
        public static void WaitForElements(IList<IWebElement> elements, String elementsName)
        {
            try
            {
                ExtentManager.Test.Log(LogStatus.Info, "Waiting for " + elementsName + " to be visible");
                foreach (IWebElement element in elements)
                {
                    wait().Until((d => element.Displayed));
                }
                foreach (IWebElement element in elements)
                {
                    Helper.Highligh(element);
                }
                ExtentManager.Test.Log(LogStatus.Pass, "Element " + elementsName + " is visible");
            }
            catch (Exception)
            {
                ExtentManager.Test.Log(LogStatus.Error, "Element " + elementsName + " is not visible or not found");
                throw;
            }

        }
    }
}
