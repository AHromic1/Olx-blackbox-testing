using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVSTestOlx.Core.Pages;

namespace VVSTestOlx.Core.Tests
{
    internal class EminaTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {

            _driver = new ChromeDriver();
        }

        private void PrihvatiCookie()
        {
            try
            {
                IWebElement slazemSeBttn = _driver.FindElement(By.CssSelector("button.css-1sjubqu")); // "Slazem se" dugme
                if (slazemSeBttn != null && slazemSeBttn.Displayed)
                {
                    slazemSeBttn.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Ne postoji cookie.");
            }
        }

        [Test]
        public void PrikazAutomobilaIzKategorijeVozila_UspjesanPrikaz()
        {
            _driver.Navigate().GoToUrl("https://olx.ba/");

            PrihvatiCookie();

            IWebElement kategorijeLink = _driver.FindElement(By.LinkText("Kategorije"));
            kategorijeLink.Click();

            Thread.Sleep(3000);
            IWebElement automobiliLink = _driver.FindElement(By.XPath(".//a[@href='/pretraga?category_id=18']"));
            automobiliLink.Click();

            Thread.Sleep(3000);

            string expectedUrl = "https://olx.ba/pretraga?category_id=18";

            Assert.That(_driver.Url, Is.EqualTo(expectedUrl));
        }

        [Test]
        public void PrikazSpecifikacijaUnutarMarketinga_UspjesanPrikaz()
        {
            _driver.Navigate().GoToUrl("https://olx.ba/");

            PrihvatiCookie();

            IWebElement marketingLink = _driver.FindElement(By.LinkText("Marketing"));
            string originalWindow = _driver.CurrentWindowHandle;
            marketingLink.Click();
            Thread.Sleep(3000);
            // prelazak na novi tab
            foreach (string windowHandle in _driver.WindowHandles)
            {
                if (windowHandle != originalWindow)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
            Thread.Sleep(3000);
            IWebElement specifikacijaLink = _driver.FindElement(By.XPath("//*[@id=\"menu-item-110\"]/a"));
            specifikacijaLink.Click();
            Thread.Sleep(3000);
            string expectedUrl = "https://marketing.olx.ba/specifikacije/";

            Assert.That(_driver.Url, Is.EqualTo(expectedUrl));

        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
