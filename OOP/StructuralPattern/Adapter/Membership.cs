namespace StructuralPattern.Adapter
{
    public class Membership
    {
        private readonly IEmailService _emailService;

        public Membership(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void CreateAccount(string email, string name, string password)
        {
            //code for creating account

            //code for sending account
            _emailService.Send("samin@test.com", name, email, "Welcome", "Your account is ready");
        }
    }
}