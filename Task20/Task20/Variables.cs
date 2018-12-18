using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace Task20
{
    [TestFixture]
    public class Variables
    {
        [Test]
        //[Ignore("skip")]
        public void TestMethod()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://tut.by/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            try
            {
                Assert.IsTrue(driver.FindElement(By.CssSelector("div.l-outer:nth-child(3) div.l-main div.b-top:nth-child(3) div.b-top-c div.header:nth-child(1) div.l-i div.header-search:nth-child(3) div.b-search:nth-child(1) form:nth-child(1) div.hold:nth-child(3) div.search-controls > input.button.big")).Displayed);
                Assert.IsTrue(driver.FindElement(By.ClassName("header-logo")).Displayed);
                Assert.IsTrue(driver.FindElement(By.Id("pageLogo")).Displayed);
                Assert.IsTrue(driver.FindElement(By.LinkText("Instagram")).Displayed);
                Assert.IsTrue(driver.FindElement(By.PartialLinkText("Insta")).Displayed);
                Assert.IsTrue(driver.FindElement(By.Name("str")).Displayed);
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Doesn't found something");
            }

            driver.Close();
        }
    }
}
