using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumTest
{
    [TestClass]
    public class SeleniumTypescript
    {
        private static string driverFolder = "C:\\Users\\Daniel\\Desktop\\SeleniumDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _driver = new ChromeDriver(driverFolder);
        }

        [TestMethod]
        public void TestCorrectHomepageTab()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("WhatToDo", title);

            IWebElement GetList = _driver.FindElement(By.Id("App"));
        }
    }
}