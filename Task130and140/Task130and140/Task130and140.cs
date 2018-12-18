using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using Allure.Commons;
using Allure.NUnit.Attributes;
using Allure.Commons.Model;


namespace CItests
{
    [TestFixture]
    public class TestClass : AllureReport
    {
        [Test]
        [Parallelizable]
        public void RemoteTest()
        {
            ChromeOptions options = new ChromeOptions();
            IWebDriver driver;
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));
            driver.Url = "https://tut.by/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Click();
            driver.FindElement(By.XPath("//input[@placeholder='Логин или эл. почта']")).SendKeys("seleniumtests@tut.by");
            driver.FindElement(By.XPath("//input[@placeholder='Пароль']")).SendKeys("123456789zxcvbn" + Keys.Enter);

            Assert.IsTrue(driver.Url.ToString().Contains("https://www.tut.by/?crnd"));

            driver.Close();
        }

        [Test]
        [Parallelizable]
        public void LocalTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://tut.by/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Click();
            driver.FindElement(By.XPath("//input[@placeholder='Логин или эл. почта']")).SendKeys("seleniumtests@tut.by");
            driver.FindElement(By.XPath("//input[@placeholder='Пароль']")).SendKeys("123456789zxcvbn" + Keys.Enter);

            Assert.IsTrue(driver.Url.ToString().Contains("https://www.tut.by/?crnd"));

            driver.Close();
        }
    }
}
