using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


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

        [TestMethod]
        public void TestSelection()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            IWebElement inoroutElement = _driver.FindElement(By.Id("InOrOut"));


            inoroutElement.SendKeys(Keys.Space);
            string enviromentelementValue2 = inoroutElement.GetAttribute("checked");
            Assert.AreEqual(null, enviromentelementValue2);


            inoroutElement.SendKeys(Keys.Space);
            string inoroutElementValue = inoroutElement.GetAttribute("checked");

            Assert.AreEqual("true", inoroutElementValue);


            IWebElement enviromentElement = _driver.FindElement(By.Id("InOrOut"));


            inoroutElement.SendKeys(Keys.Space);
            string inoroutElementValue2 = inoroutElement.GetAttribute("checked");
            Assert.AreEqual(null, inoroutElementValue2);


            enviromentElement.SendKeys(Keys.Space);
            string enviromentelementValue = enviromentElement.GetAttribute("checked");

            Assert.AreEqual("true", enviromentelementValue);
        }

        [TestMethod]
        public void TestGetRandomActivity()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            var randomButton = _driver.FindElement(By.Id("findRandomActivity"));
            randomButton.Click();

            
            
            var enviromentElement = _driver.FindElement(By.Id("NewRandomActivity"));
            var enviromentelementValue = enviromentElement.GetAttribute("Value");

            Assert.AreEqual("hej", enviromentelementValue);
        }

        [TestMethod]
        public void TestLogin()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");

            var loginNavButton = _driver.FindElement(By.Id("navLogin"));
            loginNavButton.Click();

            var usernameInput = _driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("Benjamin");

            var passwordInput = _driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("kode3");

            var loginButton = _driver.FindElement(By.Id("loginButton"));
            loginButton.Click();
        }

        [TestMethod]
        public void TestLoginFail()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Navigate().GoToUrl("http://localhost:3000/");

            var loginNavButton = _driver.FindElement(By.Id("navLogin"));
            loginNavButton.Click();

            var usernameInput = _driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("Benjamin");

            var passwordInput = _driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("kode2");

            var loginButton = _driver.FindElement(By.Id("loginButton"));
            loginButton.Click();

            var ErrorMessage = wait.Until(ExpectedConditions.ElementExists(By.Id("ErrorMessage")));

            string Text = ErrorMessage.Text;
            
            Assert.AreEqual("Wrong username or password!", Text);
        }

    }
}