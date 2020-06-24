
using System;
using Coypu;
using Coypu.Drivers.Selenium;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace NinjaPlus.Common
{
    public class BaseTest
    {
        //Convencao :
        //public String nome;
        //private String _nome;
        //protected String Nome;

        protected BrowserSession Browser;

        [SetUp]
        public void Setup()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();
            
            var sessionConfig = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                //Browser = Coypu.Drivers.Browser.Firefox,
                Timeout = TimeSpan.FromSeconds(10)
            };

            if (config["browser"].Equals("chrome"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Chrome;
            }

            if (config["browser"].Equals("firefox"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Firefox;
            }

            Browser = new BrowserSession(sessionConfig);

            Browser.MaximiseWindow();

        }

        public string CoverPath()
        {
            var outputPath = Environment.CurrentDirectory;
            return outputPath = outputPath + "/Images/";

        }

        [TearDown]
        public void Finish()
        {
            Browser.Dispose();
        }
    }
}