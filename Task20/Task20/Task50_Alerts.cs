using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTrainig
{
    [TestFixture]
    public class Task50_Alerts
    {
        private IWebDriver driver;

        [SetUp]
        public void BrowserOpen()
        {
            driver = new ChromeDriver();
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
            driver.Manage().Window.Maximize();
            Console.WriteLine("1");
        }

        [Test]
        public void Alert()
        {
            driver.FindElement(By.XPath("//button[@onclick='jsAlert()']")).Click();
            string alertText = driver.SwitchTo().Alert().Text;
            Assert.AreEqual(alertText, "I am a JS Alert");
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void Confirm()
        {
            driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();
            driver.SwitchTo().Alert().Dismiss();
            string dismissResult = driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual(dismissResult, "You clicked: Cancel");
            driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();
            driver.SwitchTo().Alert().Accept();
            string acceptResult = driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual(acceptResult, "You clicked: Ok");
            Console.WriteLine("test");
        }

        [Test]
        public void Prompt()
        {
            driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']")).Click();
            driver.SwitchTo().Alert().SendKeys("Test Message");
            driver.SwitchTo().Alert().Dismiss();
            string dismissResult = driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual(dismissResult, "You entered: null");
            driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']")).Click();
            driver.SwitchTo().Alert().SendKeys("Test Message");
            driver.SwitchTo().Alert().Accept();
            string acceptResult = driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual(acceptResult, "You entered: Test Message");
            Console.WriteLine("test");
        }

        [TearDown]
        public void BrowserClose()
        {
            driver.Close();
            driver.Dispose();
            Console.WriteLine("3");
        }
    }
}
