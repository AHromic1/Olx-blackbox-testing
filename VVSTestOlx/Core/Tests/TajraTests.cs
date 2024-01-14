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
    internal class TajraTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Init()
        {

            _driver = new ChromeDriver();
        }
        
        // Test 1
        [Test]
        public void RegistracijaNaOLX_NecheckiranoSlazemSe_NeuspješnaRegistracija()
        {
            HomePage hp = new HomePage(_driver);
            _driver.Navigate().GoToUrl("https://olx.ba/");
            PrihvatiCookie();

            IWebElement registracijaLink = _driver.FindElement(By.LinkText("Registracija"));
            registracijaLink.Click();
            Thread.Sleep(1000);

            IWebElement emailInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div:nth-child(1)>div>input[type=text]"));
            emailInput.SendKeys("tselimovic2@etf.unsa.ba");  // email
            Thread.Sleep(500);

            IWebElement sifraInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div:nth-child(2)>div>input[type=password]"));
            sifraInput.SendKeys("nekasifra");  // sifra
            Thread.Sleep(500);

            IWebElement vaseImeInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div:nth-child(3)>div>input[type=text]\r\n"));
            vaseImeInput.SendKeys("nekoimezafax");  // vase olx ime
            Thread.Sleep(500);

            IWebElement spolInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div.flex.flex-col.mb-3>select"));
            spolInput.SendKeys("Ženski");  // spol
            Thread.Sleep(500);

            IWebElement regijaInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div:nth-child(6)>div.flex.flex-col.overall>div:nth-child(2)>select"));
            regijaInput.SendKeys("Kanton Sarajevo");  // regija
            Thread.Sleep(500);

            IWebElement mjestoInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md > div.flex.flex-col.w-full>div>div>div:nth-child(6)>div.mt-md>div>div:nth-child(2)>select"));
            mjestoInput.SendKeys("Sarajevo - Centar");  // mjesto
            Thread.Sleep(500);

            
            IWebElement registrujSeButton = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>button"));

            registrujSeButton.Click();
            Thread.Sleep(5000);

            string expectedUrl = "https://olx.ba/register";

            Assert.That(_driver.Url, Is.EqualTo(expectedUrl));
        }

        // Test 2
        [Test]
        public void RegistracijaNaOLX_NedozvoljeneRijeci_NeuspješnaRegistracija()
        {
            HomePage hp = new HomePage(_driver);
            _driver.Navigate().GoToUrl("https://olx.ba/");
            PrihvatiCookie();

            IWebElement registracijaLink = _driver.FindElement(By.LinkText("Registracija"));
            registracijaLink.Click();
            Thread.Sleep(3000);

            IWebElement emailInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div:nth-child(1)>div>input[type=text]"));
            emailInput.SendKeys("tselimovic2@etf.unsa.ba");  // email
            Thread.Sleep(500);

            IWebElement sifraInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div:nth-child(2)>div>input[type=password]"));
            sifraInput.SendKeys("nekasifra");  // sifra
            Thread.Sleep(500);

            IWebElement vaseImeInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div:nth-child(3)>div>input[type=text]\r\n"));
            vaseImeInput.SendKeys("mojeOLXime");  // vase olx ime
            Thread.Sleep(500);

            IWebElement spolInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div.flex.flex-col.mb-3>select"));
            spolInput.SendKeys("Ženski");  // spol
            Thread.Sleep(500);

            IWebElement regijaInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>div:nth-child(6)>div.flex.flex-col.overall>div:nth-child(2)>select"));
            regijaInput.SendKeys("Kanton Sarajevo");  // regija
            Thread.Sleep(500);

            IWebElement mjestoInput = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md > div.flex.flex-col.w-full>div>div>div:nth-child(6)>div.mt-md>div>div:nth-child(2)>select"));
            mjestoInput.SendKeys("Ilidža");  // mjesto
            Thread.Sleep(500);

            IWebElement checkInput = _driver.FindElement(By.CssSelector("#checkbox"));
            checkInput.Click();  // check
            Thread.Sleep(500);


            IWebElement registrujSeButton = _driver.FindElement(By.CssSelector("#__layout>div>div.w-full.register-wrap.relative.z-2>div.form-wrapper.relative.m-auto.flex.flex-col.justify-center.items-center.py-md.rounded-sm.sm\\:w-full.px-md>div.flex.flex-col.w-full>div>div>button"));

            registrujSeButton.Click();
            Thread.Sleep(5000);

            string expectedUrl = "https://olx.ba/register";

            Assert.That(_driver.Url, Is.EqualTo(expectedUrl));
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
