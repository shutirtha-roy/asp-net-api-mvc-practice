namespace OOP.MockClasses
{
    public class MimeMessage
    {
        public MimeMessage()
        {
        }

        public List<object> From { get; set; }
        public List<object> To { get; set; }
        public string Subject { get; set; }
        public TextPart Body { get; set; }
    }
}