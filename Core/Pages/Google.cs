using Core.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System.Collections.Generic;

namespace SeleniumCore.Pages
{
    public class Google : Actions
    {
        public Google()
        {
            PageFactory.InitElements(Base.Instance, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement SearchBox { get; set; }

        [FindsBy(How = How.Name, Using = "btnG")]
        private IWebElement FindBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".r>a")]
        private IList<IWebElement> ResultsList { get; set; }

        public void GoTo()
        {
            openPage("https://www.google.pl");
        }

        public void Search(string query)
        {
            WaitForVisible(SearchBox, "Search Box");
            SearchBox.Clear();
            SendKeys(SearchBox, query, "Search Box");
            WaitForClickable(FindBtn, "Find button");
            Click(FindBtn, "Find button");
            WaitFoTitleToContain(query);
        }

        public void VerifyResultsCount(int NrOfResults)
        {
            WaitForElements(ResultsList, "List of query result");
            if (NrOfResults != ResultsList.Count)
            {
                ExtentManager.Test.Log(LogStatus.Error, "Number of results is different than expected, expected " + NrOfResults + " but was " + ResultsList.Count);

            }
            Assert.AreEqual(NrOfResults, ResultsList.Count, "Number of results is different than expected");
        }
    }
}
