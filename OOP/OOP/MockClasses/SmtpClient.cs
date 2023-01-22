namespace OOP.MockClasses
{
    public class SmtpClient : IDisposable
    {
        public void Connect(string v1, int v2, bool v3)
        {
            throw new NotImplementedException();
        }

        public void Authenticate(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public void Send(MimeMessage message)
        {
            throw new NotImplementedException();
        }

        public void Disconnect(bool v)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}