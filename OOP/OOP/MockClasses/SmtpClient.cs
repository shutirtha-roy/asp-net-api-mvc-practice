namespace OOP.MockClasses
{
    public class SmtpClient : IDisposable
    {
        internal void Connect(string v1, int v2, bool v3)
        {
            throw new NotImplementedException();
        }

        internal void Authenticate(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal void Send(MimeMessage message)
        {
            throw new NotImplementedException();
        }

        internal void Disconnect(bool v)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}