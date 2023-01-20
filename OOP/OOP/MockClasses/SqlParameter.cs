namespace OOP.MockClasses
{
    internal class SqlParameter
    {
        private string v;
        private object username;

        public SqlParameter(string v, object username)
        {
            this.v = v;
            this.username = username;
        }
    }
}