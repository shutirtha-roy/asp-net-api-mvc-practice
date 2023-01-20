namespace OOP.MockClasses
{
    internal class SqlCommand
    {
        private string cmd;
        private SqlConnection connection;

        public SqlCommand(string cmd, SqlConnection connection)
        {
            this.cmd = cmd;
            this.connection = connection;
        }

        public List<object> Parameters { get; internal set; }

        internal void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }
    }
}