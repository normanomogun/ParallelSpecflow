using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace ExecuteAutomation.PageObjects
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterLoginInfo(string userName, string password)
        {
            var userNameTextBox = _driver.FindElement(By.Name("UserName"));
            userNameTextBox.SendKeys(userName);
            var passw0rdTextBox = _driver.FindElement(By.Name("Password"));
            passw0rdTextBox.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            var loginButton = _driver.FindElement(By.Name("Login"));
            loginButton.Submit();
        }

        public bool IsBrowserOnLoginPage()
        {
            return _driver.FindElement(By.Name("Login")).Displayed;
        }
    }
}
