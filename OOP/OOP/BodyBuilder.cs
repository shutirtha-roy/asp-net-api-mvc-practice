using OOP.MockClasses;

namespace OOP
{
    internal class BodyBuilder
    {
        public BodyBuilder()
        {
        }

        public string HtmlBody { get; internal set; }

        internal TextPart ToMessageBody()
        {
            throw new NotImplementedException();
        }
    }
}