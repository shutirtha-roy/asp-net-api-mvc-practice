namespace OOP
{
    public class HTMLEmailService : EmailService
    {
        public HTMLEmailService(string host, string username,
            string password, int port)
            : base(host, username, password, port) { }

        public override void SendWelcomeEmail(string email, string name,
            string body)
        {
            using var client = CreateClient();
            var message = CreateMessage(name, email);
            message.Subject = "How you doin'?";

            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            message.Body = builder.ToMessageBody();

            client.Send(message);
        }
    }
}