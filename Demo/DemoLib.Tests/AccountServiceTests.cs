using NUnit.Framework;

namespace DemoLib.Tests
{
    public class AccountServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Category("UnitTest")]
        public void Email_ValidEmails_Valid()
        {
            string username = "roy";
            string password = "12344";
            string email = "info@roy.com";

            AccountService accountService = new AccountService(new FakeEmailSender());
            accountService.CreateAccount(username, password, email);
        }
    }
}
