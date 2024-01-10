using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VVSTestOlx
{
    public class HomePage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement _searchtxtbox;

        [FindsBy(How = How.Name, Using = "btnK")]
        private IWebElement _searchbtn;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Search(string searchText)
        {
            _searchtxtbox.SendKeys(searchText);
            _searchbtn.Click();
        }
    }
}
