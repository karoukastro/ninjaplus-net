using NUnit.Framework;
using NinjaPlus.Pages;
using NinjaPlus.Common;

namespace NinjaPlus.Tests
{
    public class LoginTests : BaseTest
    {
        private LoginPage _login;
        private SideBar _side;

        [SetUp]
        public void Start()
        {
            _login = new LoginPage(Browser);
            _side = new SideBar(Browser);
        }

        [Test]
        [Category("Critical")]
        public void ShouldSeeLoggedUser()
        {
            _login.With("root@carol.com", "pwd123");
            Assert.AreEqual("Carol", _side.LoggedUser());
        }

        //DDT - Data Driven Testing 
        [TestCase("root@carol.com", "123456", "Usuário e/ou senha inválidos")]
        [TestCase("404@carol.com", "pwd123", "Usuário e/ou senha inválidos")]
        [TestCase("", "pwd123", "Opps. Cadê o email?")]
        [TestCase("root@carol.com", "", "Opps. Cadê a senha?")]
        public void ShouldSeeAlertMessage(string email, string pass, string expectMessage)
        {
            _login.With(email, pass);
            Assert.AreEqual(expectMessage, _login.AlertMessage());
        }
    }
}