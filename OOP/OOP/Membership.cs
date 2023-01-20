using OOP.MockClasses;

namespace OOP
{
    public class Membership
    {
        public void CreateAccount()
        {
            new InputOutput().TakeInput();
            new Validator().ValidatedUsername("samin");
            new DataUtility().StoreData("samin", "password", "samin@gmail.com");
            new HTMLEmailService("samin@gmail.com", "samin", "", 2).SendWelcomeEmail("samin@gmail.com", "samin", "");
        }
    }
}