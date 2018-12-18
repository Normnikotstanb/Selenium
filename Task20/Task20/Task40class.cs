using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumTrainig
{
    [TestFixture]
    public class Task40class
    {
        [Test]
        //[Ignore("Skip")]
        public void Locators()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://tut.by/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Click();
            driver.FindElement(By.XPath("//input[@placeholder='Логин или эл. почта']")).SendKeys("seleniumtests@tut.by");
            driver.FindElement(By.XPath("//input[@placeholder='Пароль']")).SendKeys("123456789zxcvbn" + Keys.Enter);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(condition =>
            {
                try
                {
                    var ElementToBeDisplayed = driver.FindElement(By.XPath("//*[@id='mainmenu']/ul/li[3]"));
                    return ElementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException e)
                {
                    return false;
                }
                catch (NoSuchElementException n)
                {
                    return false;
                }
            });

            driver.FindElement(By.XPath("//*[@id='mainmenu']/ul/li[3]")).Click();

            try
            {
                Thread.Sleep(5000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Sheep Counting");
            }

            driver.FindElement(By.XPath("//a[contains(text(),'Лёгкая версия')]")).Click();

            try
            {
                Thread.Sleep(5000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Sheep Counting");
            }

            driver.FindElement(By.XPath("//a[@aria-label='Написать']")).Click();

            try
            {
                //a) Search Input
                //Assert.IsTrue(driver.FindElement(By.XPath("//input[@id='search_from_str']")).Displayed);
                //Assert.IsTrue(driver.FindElement(By.CssSelector("#search_from_str")).Displayed);
                //b) Find Button
                //Assert.IsTrue(driver.FindElement(By.XPath("//input[@value='Найти']")).Displayed);
                //Assert.IsTrue(driver.FindElement(By.CssSelector("#search")).Displayed);
                //c) Remember me label
                //Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='authorize']")).Displayed);
                //Assert.IsTrue(driver.FindElement(By.CssSelector("#authorize")).Displayed);
                //d) Remember me input
                //Assert.IsTrue(driver.FindElement(By.XPath("//input[@id='memory']")).Displayed);
                //Assert.IsTrue(driver.FindElement(By.CssSelector("#memory")).Displayed);
                //e)Register button
                //Assert.IsTrue(driver.FindElement(By.XPath("//a[@class='button wide auth__reg']")).Displayed);
                //Assert.IsTrue(driver.FindElement(By.CssSelector("#a.button.wide.auth__reg")).Displayed);
                //f) Write email button
                //Assert.IsTrue(driver.FindElement(By.XPath("//a[@aria-label='Написать']")).Displayed);
                //Assert.IsTrue(driver.FindElement(By.CssSelector("a[aria-label=Написать]")).Displayed);
                //g) Logout link
                //Assert.IsTrue(driver.FindElement(By.XPath("//a[@class='b-header__link b-header__link_exit']")).Displayed);
                //Assert.IsTrue(driver.FindElement(By.CssSelector("a.b-header__link.b-header__link_exit")).Displayed);
                //h) Settings link
                //Assert.IsTrue(driver.FindElement(By.XPath("//a[@class='b-header__link b-header__link_setup']")).Displayed);
                //Assert.IsTrue(driver.FindElement(By.CssSelector("a.b-header__link.b-header__link_setup")).Displayed);
                //i Inbox, Sent, Deleted and Spam links
                //Assert.IsTrue(driver.FindElement(By.XPath("//a[@class='b-header__link b-header__link_setup']")).Displayed);
                //Assert.IsTrue(driver.FindElement(By.CssSelector("a.b-header__link.b-header__link_setup")).Displayed);

                //j) To input
                Assert.IsTrue(driver.FindElement(By.XPath("//*[@name='to']")).Displayed);
                Assert.IsTrue(driver.FindElement(By.CssSelector("[name=to]")).Displayed);
                //k) Topic input
                Assert.IsTrue(driver.FindElement(By.XPath("//*[@name='subj']")).Displayed);
                Assert.IsTrue(driver.FindElement(By.CssSelector("[name=subj]")).Displayed);
                //l) Find button
                Assert.IsTrue(driver.FindElement(By.XPath("//input[@value='Найти']")).Displayed);
                Assert.IsTrue(driver.FindElement(By.CssSelector("input[value=Найти]")).Displayed);

            }
            catch (Exception e)
            {
                Console.WriteLine("Doesn't found something");
            }

            driver.Close();
            driver.Dispose();
        }
    }
}
