using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace ParallelSpecflowTest
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver _driver;
        private IConfiguration _configuration;
        private readonly IObjectContainer _objectContainer;
        private ScenarioSettings _scenarioSettings;
        private string _driverMode;

        public Hooks(IObjectContainer objectContainer, ScenarioSettings scenarioSettings)
        {
            _objectContainer = objectContainer;
            _scenarioSettings = scenarioSettings;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
          _configuration =  GetConfig();
          var driverName = _configuration["driverName"];
          _scenarioSettings.BaseUrl = _configuration["url"];
            StartDriver();
        }

        private IConfiguration GetConfig()
        {
            //var filePath = AppContext.BaseDirectory; 
            var builder = new ConfigurationBuilder()
                .AddJsonFile("Configuration.json")
                .Build();
            return builder;

        }

        private void StartDriver()
        {
            _driverMode = _configuration["driverMode"];
            if (_driverMode == "local")
            {
                _driver = new ChromeDriver();
            }
            else //grid
            {
                ChromeOptions chromeOptions = new ChromeOptions()
                {
                    PlatformName = "windows"
                };

                // Java is required on the machine that is going to be used as a hub
                // The remote driver or jar file must be installed on the machine it will be run on else it won't run
                _driver = new RemoteWebDriver(new Uri("http://192.168.0.9:4444/wd/hub"), chromeOptions.ToCapabilities());
            }
            
            _driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
