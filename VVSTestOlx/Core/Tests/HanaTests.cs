using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VVSTestOlx.Core.Pages;
using System.Runtime.Intrinsics.X86;
using OpenQA.Selenium.Support.UI;


namespace VVSTestOlx.Core.Tests
{
    public class HanaTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {

            _driver = new ChromeDriver();
        }




        [Test]

        public void PrijavaNaOlxProfil_UspjesnaPrijava()
        {
            HomePage hp = new HomePage(_driver);
            _driver.Navigate().GoToUrl("https://olx.ba/");
            PrihvatiCookie();

            IWebElement prijavaLink = _driver.FindElement(By.LinkText("Prijavi se"));
            prijavaLink.Click();
            Thread.Sleep(5000);

            IWebElement usernameInput = _driver.FindElement(By.CssSelector("input[name='username']"));
            usernameInput.SendKeys("VVSTest");  //username

            IWebElement passwordInput = _driver.FindElement(By.CssSelector("input[name='password']"));
            passwordInput.SendKeys("VVSTest2024");  //password
            Thread.Sleep(5000);

            IWebElement prijaviSeButton = _driver.FindElement(By.CssSelector("button.my-lg"));

            prijaviSeButton.Click();
            Thread.Sleep(5000);

            IWebElement vvstestElement = _driver.FindElement(By.CssSelector("p.font-semibold.cursor-pointer"));
            vvstestElement.Click();
            Thread.Sleep(5000);

            string expectedUrl = "https://olx.ba/profil/VVSTest/aktivni";

            Assert.AreEqual(expectedUrl, _driver.Url);
        }

        
        [Test]
        public void PrikazStavkiKuceKategorije_UspjesanPrikaz()
        {
            HomePage hp = new HomePage(_driver);
            _driver.Navigate().GoToUrl("https://olx.ba/");

            PrihvatiCookie();

            IWebElement kategorijeLink = _driver.FindElement(By.LinkText("Kategorije"));
            kategorijeLink.Click();

            Thread.Sleep(5000);
            IWebElement kuceLink = _driver.FindElement(By.XPath(".//a[@href='/pretraga?category_id=24']"));
            kuceLink.Click();
         
            Thread.Sleep(5000);
           
            string expectedUrl = "https://olx.ba/pretraga?category_id=24"; 
           
            Assert.AreEqual(expectedUrl, _driver.Url);
        }

        [Test]
        public void VerifyProductDetails()
        {
            // Navigacija do OLX.ba
            _driver.Navigate().GoToUrl("https://www.olx.ba/");

            // klik na slazem se
            PrihvatiCookie();

            // klik na blog button
            IWebElement blogButton = _driver.FindElement(By.CssSelector("#__layout>div>header>div>div.headerbar.bg-white.flex.flex-col.w-full.sm\\:items-center.sm\\:max-w-full.sm\\:px-md.sm\\:py-md.sm\\:flex-row>div.flex.flex-row.items-center.justify-between.mb-md.sm\\:mb-0>div:nth-child(1)>div.sm\\:hidden.flex.flex-row.ml-lg>ul>li:nth-child(5)>a"));
            string originalWindow = _driver.CurrentWindowHandle;
            blogButton.Click();

            // prelazak na novi tab
            foreach (string windowHandle in _driver.WindowHandles)
            {
                if (windowHandle != originalWindow)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            // klik na kontakt link
            IWebElement kontaktLink = _driver.FindElement(By.XPath("//ul[@id='menu-main']//a[contains(@href,'kontakt')]"));
            kontaktLink.Click();
            Assert.IsNotNull(kontaktLink);

            Thread.Sleep(10000);
            Console.WriteLine(_driver.Url);
            Assert.IsTrue(_driver.Url.Contains("https://blog.olx.ba/kontakt.html"), "Niste na željenoj stranici (https://blog.olx.ba).");

            _driver.Close();
            _driver.SwitchTo().Window(originalWindow);
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

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
