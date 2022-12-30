using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;

namespace DemoLib.Tests
{
    public class AccountServiceTests
    {
        private AutoMock _mock;
        private Mock<IEmailSender> _emailSender;
        private AccountService _accountService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mock = AutoMock.GetLoose();
        }

        [SetUp]
        public void Setup()
        {
            _emailSender = _mock.Mock<IEmailSender>();
            _accountService = _mock.Create<AccountService>();
        }

        [TearDown]
        public void Teardown()
        {
            _emailSender.Reset();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _mock?.Dispose();
        }

        [Test, Category("UnitTest")]
        public void Email_ValidEmails_Valid()
        {
            string username = "roy";
            string password = "12344";
            string email = "info@roy.com";

            _emailSender.Setup(x => x.Send(email)).Verifiable();

            _accountService.CreateAccount(username, password, email);

            _emailSender.VerifyAll();
        }

        [Test, Category("UnitTest")]
        public void GetCampaignReport_ValidCampaignName_SendsEmail()
        {
            string campaignName = "Test";
            string email = "roy@gmail.com";

            _emailSender.Setup(x => x.GetEmailSeen(campaignName)).Returns(5).Verifiable();
            _emailSender.Setup(x => x.Send(email)).Verifiable();

            _accountService.GetCampaignReport(campaignName);

            _emailSender.VerifyAll();
        }
    }
}
