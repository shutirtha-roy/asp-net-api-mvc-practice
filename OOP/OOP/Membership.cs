using OOP.MockClasses;

namespace OOP
{
    public class Membership
    {
        private readonly EmailService _emailService;

        public Membership(EmailService emailService)
        {
            _emailService = emailService;
        }

        public void CreateAccount()
        {
            new InputOutput().TakeInput();
            new Validator().ValidatedUsername("samin");
            new DataUtility().StoreData("samin", "password", "samin@gmail.com");
            _emailService.SendWelcomeEmail("samin@gmail.com", "samin", "");
        }
    }
}