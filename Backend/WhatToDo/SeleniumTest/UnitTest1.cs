using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumTest
{
    [TestClass]
    public class SeleniumTypescript
    {
        private static string driverFolder = "C:\\Users\\West\\Desktop\\SeleniumChromeDriver";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestGetAllListActivities()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("WhatToDo", title);
        }
    }
}