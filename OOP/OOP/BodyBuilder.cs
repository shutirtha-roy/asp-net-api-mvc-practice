using OOP.MockClasses;

namespace OOP
{
    public class BodyBuilder
    {
        public BodyBuilder()
        {
        }

        public string HtmlBody { get; set; }

        public TextPart ToMessageBody()
        {
            throw new NotImplementedException();
        }
    }
}