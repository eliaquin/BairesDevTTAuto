using System;
using System.Threading;
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
            var button = _driver.FindElement(By.Id("ctl00_ContentPlaceHolder_LoginButton"));
            button.Click();

            const int counter = 0;
            Sleep(counter, "BairesDev :: TimeTracker");

            if (_driver.Title != "BairesDev :: TimeTracker")
            {
                Console.WriteLine("Unable to continue any further. Please, check your script.");
                return;
            }

            var btn = _driver.FindElement(By.ClassName("btn-blue"));
            btn.Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.Id("ctl00_ContentPlaceHolder_idProyectoDropDownList")).SendKeys("Indus");

            Console.WriteLine("Yatta");
        }

        private void Sleep(int counter, string title)
        {
            while (_driver.Title != title)
            {
                Thread.Sleep(1000);
                counter += 1;
                if (counter > 5)
                {
                    break;
                }
            }
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
