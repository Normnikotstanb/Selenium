using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.CSharp;

namespace SeleniumTrainig
{
    [TestFixture]
    public class Task50class
    {
        [Test]
        //[Ignore("Skip")]
        public void Waiters()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://tut.by/";

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(condition =>
            {
                try
                {
                    var loginPopup = driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']"));
                    return loginPopup.Displayed;
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

            driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Click();
            driver.FindElement(By.XPath("//input[@placeholder='Логин или эл. почта']")).SendKeys("seleniumtests@tut.by");
            driver.FindElement(By.XPath("//input[@placeholder='Пароль']")).SendKeys("123456789zxcvbn" + Keys.Enter);

            try
            {
                Thread.Sleep(5000); //Explicit waiter
            }
            catch (ThreadInterruptedException ie)
            {
                Console.WriteLine("Sheep Сounting");
            }

            Assert.IsTrue(driver.FindElement(By.ClassName("uname")).Displayed);

            driver.Close();
            driver.Dispose();
        }

        [Test]
        [Ignore("Skip")]
        public void DataDriven()
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Open(@"D:\Selenium training\Final\Task20\Addons\data2.xlsx");
            Excel.Worksheet worksheet = (Excel.Worksheet)app.Worksheets["Sheet1"];
            Excel.Range range = worksheet.UsedRange;

            string username;
            string password;

            for (int i = 1; i < 2; i++)
            {
                username = range.Cells[i][1].value2;
                password = range.Cells[2][i].value2;

                IWebDriver driver = new ChromeDriver();
                driver.Url = "https://tut.by/";

                driver.FindElement(By.XPath("//a[@data-target-popup='authorize-form']")).Click();
                driver.FindElement(By.XPath("//input[@placeholder='Логин или эл. почта']")).SendKeys(username.ToString());
                driver.FindElement(By.XPath("//input[@placeholder='Пароль']")).SendKeys(password + Keys.Enter);
                Assert.IsTrue(driver.FindElement(By.XPath("//span[@class='uname']")).Displayed);
                driver.Close();
            }
        }


    }
}
