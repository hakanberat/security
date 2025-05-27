using MySql.Data.MySqlClient;

public class UserRepository
{
    private string connectionString = "server=localhost;user=root;password=1234;database=SafeVault";

    public void AddUser(string username, string email)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            var query = "INSERT INTO Users (Username, Email) VALUES (@username, @email)";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", InputSanitizer.SanitizeInput(username));
                cmd.Parameters.AddWithValue("@email", InputSanitizer.SanitizeInput(email));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
