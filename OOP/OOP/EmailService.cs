using OOP.MockClasses;

namespace OOP
{
    internal class EmailService
    {
        public void SendWelcomeEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Joey Tribbiani", "joey@friends.com"));
            message.To.Add(new MailboxAddress("Mrs. Chandler Bong", "chandler@friends.com"));
            message.Subject = "How you doing?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.friends.com", 587, false);
                client.Authenticate("joey", "password");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}