using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace ExecuteAutomation.PageObjects
{
    public class UserFormPage
    {
        private IWebDriver _driver;
        private By _saveBtn = By.Name("Save");
        public IWebElement SaveBtn
        {
            get { return _driver.FindElement(_saveBtn); }
        }

        public UserFormPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsBrowserOnUserFormPage()
        {
            return _driver.FindElement(_saveBtn).Displayed;
        }

        public void FillForm(string detailsInitial, string detailsFirstName, string detailsMiddleName)
        {
            var initial = _driver.FindElement(By.Id("Initial"));
            initial.SendKeys(detailsInitial);
            var firstname = _driver.FindElement(By.Id("FirstName"));
            firstname.SendKeys(detailsFirstName);
            var middleName = _driver.FindElement(By.Id("MiddleName"));
            middleName.SendKeys(detailsMiddleName);



        }

        public void SaveForm()
        {
            SaveBtn.Click();
        }
    }
}
