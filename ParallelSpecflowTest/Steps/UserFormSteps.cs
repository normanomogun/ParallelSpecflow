using System;
using System.Collections.Generic;
using System.Text;
using ExecuteAutomation;
using ExecuteAutomation.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ParallelSpecflowTest.Steps
{
    [Binding]
    public class UserFormSteps
    {
        private IWebDriver _driver;
        private ScenarioSettings _scenarioSettings;
        private UserFormPage _userFormPage;

        public UserFormSteps(IWebDriver driver, ScenarioSettings scenarioSettings)
        {
            _driver = driver;
            _scenarioSettings = scenarioSettings;
        }

        [When(@"I enter the following form details")]
        public void WhenIEnterTheFollowingFormDetails(Table table)
        {
            var details = table.CreateInstance<UserCredentials>();
            _userFormPage = new UserFormPage(_driver);
            _userFormPage.FillForm(details.Initial, details.FirstName, details.MiddleName);
        }

        [When(@"I click save on form page")]
        public void WhenIClickSaveOnFormPage()
        {
            _userFormPage.SaveForm();
        }


    }
}
