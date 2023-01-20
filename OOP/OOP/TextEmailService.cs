using OOP.MockClasses;

namespace OOP
{
    public class TextEmailService : EmailService
    {
        public TextEmailService(string host, string username,
            string password, int port)
            : base(host, username, password, port) { }

        public override void SendWelcomeEmail(string email, string name,
            string body)
        {
            using var client = CreateClient();
            var message = CreateMessage(name, email);
            message.Subject = "How you doin'?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey {email},
I just wanted to let you know that Monica and I were going to go play some paintball, you in?
-- Joey"
            };

            client.Send(message);
        }

        private dynamic CreateMessage(string name, string email)
        {
            return new { Subject = "", Body = "" };
        }
    }
}