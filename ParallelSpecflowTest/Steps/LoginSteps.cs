using System;
using System.Collections.Generic;
using System.Text;
using ExecuteAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ParallelSpecflowTest.Steps
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage _loginPage;
        private IWebDriver _driver;
        private ScenarioSettings _scenarioSettings;
        private UserFormPage _userFormPage;

        public LoginSteps(IWebDriver driver, ScenarioSettings scenarioSettings )
        {

            _driver = driver;
            _scenarioSettings = scenarioSettings;
        }


        [Given(@"I am on the execute automation website")]
        public void GivenIAmOnTheExecuteAutomationWebsite()
        {
            var url = _scenarioSettings.BaseUrl;
            _driver.Navigate().GoToUrl(url);
        }


        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage = new LoginPage(_driver);
            Assert.IsTrue(_loginPage.IsBrowserOnLoginPage(), "browser not on login page");
        }

        [When(@"I enter (.*) and (.*)")]
        public void WhenIEnterAdminAnd(string username, string password)
        {
            _loginPage.EnterLoginInfo(username, password);
        }

        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            _loginPage.ClickLoginButton();
        }

        [Then(@"i should be redirected to the form page")]
        public void ThenIShouldBeRedirectedToTheFormPage()
        {
            _userFormPage = new UserFormPage(_driver);
            Assert.IsTrue(_userFormPage.IsBrowserOnUserFormPage(), "Browser not on user form page");
        }

    }

  
}
