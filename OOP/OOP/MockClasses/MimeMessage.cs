namespace OOP.MockClasses
{
    internal class MimeMessage
    {
        public MimeMessage()
        {
        }

        public List<object> From { get; internal set; }
        public List<object> To { get; internal set; }
        public string Subject { get; internal set; }
        public TextPart Body { get; internal set; }
    }
}