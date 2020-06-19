using NUnit.Framework;
using Coypu;
using Coypu.Drivers.Selenium;
using System.Threading;

namespace NinjaPlus.Tests
{
    public class LoginTests
    {
        public BrowserSession browser;

        [SetUp]
        public void Setup()
        {
            var configs = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome
            };
            browser = new BrowserSession(configs);

            browser.MaximiseWindow();
        }

        [TearDown]
        public void Finish()
        {
            browser.Dispose();
        }
        [Test]
        public void SuccessfullyLogin()
        {
            browser.Visit("/login");

            browser.FillIn("email").With("root@carol.com");
            browser.FindCss("input[placeholder=senha]").SendKeys("pwd123");
            browser.ClickButton("Entrar");

            var loggedUser = browser.FindCss(".user .info span");
            Assert.AreEqual("Carol", loggedUser.Text);
        }
    }
}