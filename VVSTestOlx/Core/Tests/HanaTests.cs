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
        public void PrikazKomentaraNakonSubmitanja_NeuspjesanPrikaz()
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
            // Assert.IsNotNull(kontaktLink);

            Thread.Sleep(4000);
            Console.WriteLine(_driver.Url);
            // Assert.IsTrue(_driver.Url.Contains("https://blog.olx.ba/kontakt.html"), "Niste na željenoj stranici (https://blog.olx.ba).");

            IWebElement saznajViseButton = _driver.FindElement(By.CssSelector(".eltd-btn.eltd-btn-medium.eltd-btn-solid.eltd-read-more"));
            saznajViseButton.Click();
            Thread.Sleep(4000);

            // popunjavanje forme za komentar
            IWebElement commentTextArea = _driver.FindElement(By.Id("comment"));
            IWebElement authorInput = _driver.FindElement(By.Id("author"));
            IWebElement emailInput = _driver.FindElement(By.Id("email"));
            IWebElement websiteInput = _driver.FindElement(By.Id("url"));

            // Popunite formu sa potrebnim informacijama
            commentTextArea.SendKeys("Ovo je moj test komentar.");
            authorInput.SendKeys("MojeIme");
            emailInput.SendKeys("mojemail@example.com");
            websiteInput.SendKeys("http://www.mojawebsite.com");

            // klik na consent button
            IWebElement consentCheckbox = _driver.FindElement(By.Id("wp-comment-cookies-consent"));
            consentCheckbox.Click();

            // klik na submit button
            IWebElement submitButton = _driver.FindElement(By.Id("submit_comment"));
            submitButton.Click();

            Thread.Sleep(4000);
            Assert.IsTrue(_driver.PageSource.Contains("Ovo je moj test komentar."), "Komentar se ne prikazuje na stranici.");

            _driver.Close();
            _driver.SwitchTo().Window(originalWindow);
        }

        [Test]
        public void PrikazKontaktStranice_NeuspjesanPrikaz()
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
            // Assert.IsNotNull(kontaktLink);

            Thread.Sleep(4000);
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
