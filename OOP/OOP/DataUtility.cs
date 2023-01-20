using OOP.MockClasses;

namespace OOP
{
    internal class DataUtility
    {
        public void StoreData(string username, string password, string email)
        {
            var connectionString = @"Server = ...";
            SqlConnection connection = new SqlConnection(connectionString);
            string cmd = "INSERT Query";
            connection.Open();
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.Add(new SqlParameter("username", username));
            command.Parameters.Add(new SqlParameter("password", password));
            command.Parameters.Add(new SqlParameter("email", email));
            command.ExecuteNonQuery();
        }
    }
}