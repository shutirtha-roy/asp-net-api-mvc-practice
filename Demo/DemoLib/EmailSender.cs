using MailKit.Net.Smtp;
using MimeKit;

namespace DemoLib
{
    public class EmailSender
    {
        public void Send(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("info@roy.com", "info@roy.com"));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = "How you doing?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey",
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.friends.com", 587, false);
                //Note: only needed if the SMTP server requires authentication
                client.Authenticate("joey", "password");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
