using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTrainig
{
    [TestFixture]
    public class Task50_Frame
    {
        private IWebDriver driver;
        private string KeyCode = "\u0002";

        [SetUp]
        public void BrowserOpen()
        {
            driver = new ChromeDriver();
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
        }

        [Test]
        public void FrameTest()
        {
            IWebElement frameLoc = driver.FindElement(By.Id("mce_0_ifr"));

            driver.SwitchTo().Frame(frameLoc);
            driver.FindElement(By.Id("tinymce")).Clear();
            driver.FindElement(By.Id("tinymce")).SendKeys("Hello ");
            driver.FindElement(By.Id("tinymce")).SendKeys(KeyCode);
            driver.FindElement(By.Id("tinymce")).SendKeys("World!");
            driver.FindElement(By.Id("tinymce")).SendKeys(KeyCode);

            string currentText = driver.FindElement(By.TagName("p")).Text;
            Assert.IsTrue(currentText.Contains("World!") && currentText.Contains("Hello"));
        }

        [TearDown]
        public void BrowserClose()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
