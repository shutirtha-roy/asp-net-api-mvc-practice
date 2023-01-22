namespace StructuralPattern.Adapter
{
    public class EmailAdapter : IEmailService
    {
        public void Send(string email, string receiverName, string receiverEmail, string subject, string body)
        {
            EmailSender.SendEmail(receiverEmail, receiverName, body, subject, email);
        }
    }
}