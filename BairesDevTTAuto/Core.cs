using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BairesDevTTAuto
{
    internal class Core : IDisposable
    {
        private readonly IWebDriver _driver;

        public Core()
        {
            _driver = new ChromeDriver();
        }

        public void Go()
        {
            _driver.Navigate().GoToUrl("https://timetracker.bairesdev.com/");
            _driver.FindElement(By.Id("ctl00_ContentPlaceHolder_UserNameTextBox")).SendKeys("eliaquin.encarnacion");
            _driver.FindElement(By.Id("ctl00_ContentPlaceHolder_PasswordTextBox")).SendKeys("K1r4m1h$E1976");
            var button = _driver.FindElement(By.ClassName("btn-blue"));
            button.Click();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
