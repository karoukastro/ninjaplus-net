using Coypu;
using Coypu.Drivers.Selenium;

namespace NinjaPlus.Pages
{
    public class LoginPage
    {
        private readonly BrowserSession _browser;

        public LoginPage(BrowserSession browser)
        {
            _browser = browser;
        }

        public void Load()
        {
            _browser.Visit("/login");
        }
        public void With(string email, string senha)
        {
            this.Load();
            _browser.FillIn("email").With(email);
            _browser.FindCss("#passId").SendKeys(senha);
            _browser.ClickButton("Entrar");

        }

        public string AlertMessage()
        {
            return _browser.FindCss(".alert span").Text;
        }

    }
}