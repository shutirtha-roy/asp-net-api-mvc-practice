using OOP.MockClasses;

namespace OOP
{
    public abstract class EmailService
    {
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;
        private readonly int _port;

        public EmailService(string host, string username, string password, int port)
        {
            _host = host;
            _username = username;
            _password = password;
            _port = port;
        }

        protected SmtpClient CreateClient()
        {
            var client = new SmtpClient();
            client.Connect(_host, _port, false);
            client.Authenticate(_username, _password);
            return client;
        }

        protected MimeMessage CreateMessage(string name, string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Joey Tribbiani", "joey@friends.com"));
            message.To.Add(new MailboxAddress("Mrs. Chandler Bong", "chandler@friends.com"));
            return message;
        }

        public abstract void SendWelcomeEmail(string email, string name, string body);
    }
}