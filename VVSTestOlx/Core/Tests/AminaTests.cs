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
    public class AminaTests
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
        public void PrijavaNaOlxProfil_NeuspjesnaPrijavaPogresanUsernameILozinka()
        {
            HomePage hp = new HomePage(_driver);
            _driver.Navigate().GoToUrl("https://olx.ba/");
            PrihvatiCookie();

            IWebElement prijavaLink = _driver.FindElement(By.LinkText("Prijavi se"));
            prijavaLink.Click();
            Thread.Sleep(5000);

            IWebElement usernameInput = _driver.FindElement(By.CssSelector("input[name='username']"));
            usernameInput.SendKeys("VVSTestttt");  //username

            IWebElement passwordInput = _driver.FindElement(By.CssSelector("input[name='password']"));
            passwordInput.SendKeys("VVSTest2025");  //password
            Thread.Sleep(5000);

            IWebElement prijaviSeButton = _driver.FindElement(By.CssSelector("button.my-lg"));

            prijaviSeButton.Click();
            Thread.Sleep(5000);

            string expectedUrl = "https://olx.ba/login";

            Assert.AreEqual(expectedUrl, _driver.Url);
        }

        [Test]
        public void PrijavaNaOlxProfil_NeuspjesnaPrijavaPogresanUsername()
        {
            HomePage hp = new HomePage(_driver);
            _driver.Navigate().GoToUrl("https://olx.ba/");
            PrihvatiCookie();

            IWebElement prijavaLink = _driver.FindElement(By.LinkText("Prijavi se"));
            prijavaLink.Click();
            Thread.Sleep(5000);

            IWebElement usernameInput = _driver.FindElement(By.CssSelector("input[name='username']"));
            usernameInput.SendKeys("VVSTestttt");  //username

            IWebElement passwordInput = _driver.FindElement(By.CssSelector("input[name='password']"));
            passwordInput.SendKeys("VVSTest2024");  //password
            Thread.Sleep(5000);

            IWebElement prijaviSeButton = _driver.FindElement(By.CssSelector("button.my-lg"));

            prijaviSeButton.Click();
            Thread.Sleep(5000);

            string expectedUrl = "https://olx.ba/login";

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
