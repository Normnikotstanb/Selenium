using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace Task20
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        //[Ignore("skip")]
        public void TestMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://tut.by/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Click();
            driver.FindElement(By.XPath("//input[@placeholder='Логин или эл. почта']")).SendKeys("seleniumtests@tut.by");
            driver.FindElement(By.XPath(" //input[@placeholder='Пароль']")).SendKeys("123456789zxcvbn" + Keys.Enter);

            Assert.IsTrue(driver.Url.ToString().Contains("https://www.tut.by/?crnd"));

            driver.Close();
    }
    }
}
