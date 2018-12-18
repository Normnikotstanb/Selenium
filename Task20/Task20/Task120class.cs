using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using NUnit.Framework.Interfaces;

namespace SeleniumTrainig
{
    [TestFixture]
    public class Task120class
    {
        private IWebDriver driver;

        //Windows 10, Microsoft Edge (latest version)
        [Test]
        public void SauceTest1()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserName", "MicrosoftEdge");
            caps.SetCapability("platform", "Windows 10");
            caps.SetCapability("version", "latest");
            caps.SetCapability("username", "VladY");
            caps.SetCapability("accessKey", "2b036351-7b91-4424-b0b8-e3887ad7e54d");

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(600));
            driver.Url = "https://tut.by/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Click();
            driver.FindElement(By.XPath("//input[@placeholder='Логин или эл. почта']")).SendKeys("seleniumtests@tut.by");
            driver.FindElement(By.XPath("//input[@placeholder='Пароль']")).SendKeys("123456789zxcvbn" + Keys.Enter);

            Assert.IsTrue(driver.Url.ToString().Contains("https://www.tut.by/?crnd"));
        }

        //Windows 8.1, Mozilla Firefox 39.0
        [Test]
        public void SauceTest2()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserName", "Firefox");
            caps.SetCapability("platform", "Windows 8.1");
            caps.SetCapability("version", "39");
            caps.SetCapability("username", "VladY");
            caps.SetCapability("accessKey", "2b036351-7b91-4424-b0b8-e3887ad7e54d");

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps, TimeSpan.FromSeconds(600));
            driver.Url = "https://tut.by/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Click();
            driver.FindElement(By.XPath("//input[@placeholder='Логин или эл. почта']")).SendKeys("seleniumtests@tut.by");
            driver.FindElement(By.XPath("//input[@placeholder='Пароль']")).SendKeys("123456789zxcvbn" + Keys.Enter);

            Assert.IsTrue(driver.Url.ToString().Contains("https://www.tut.by/?crnd"));
        }

        //Linux, Google Chrome 40
        [Test]
        public void SauceTest3()
        {
            var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);

            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability(CapabilityType.Version, "40", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Linux", true);
            options.AddAdditionalCapability("username", sauceUserName, true);
            options.AddAdditionalCapability("accessKey", sauceAccessKey, true);
            options.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));
            driver.Url = "https://tut.by/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Click();
            driver.FindElement(By.XPath("//input[@placeholder='Логин или эл. почта']")).SendKeys("seleniumtests@tut.by");
            driver.FindElement(By.XPath("//input[@placeholder='Пароль']")).SendKeys("123456789zxcvbn" + Keys.Enter);

            Assert.IsTrue(driver.Url.ToString().Contains("https://www.tut.by/?crnd"));
        }

        [TearDown]
        public void CleanUp()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            driver?.Quit();
        }
    }
}