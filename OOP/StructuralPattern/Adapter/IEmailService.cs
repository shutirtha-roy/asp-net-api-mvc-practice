namespace StructuralPattern.Adapter
{
    public interface IEmailService
    {
        void Send(string email, string receiverName, string receiverEmail, string subject, string body);
    }
}