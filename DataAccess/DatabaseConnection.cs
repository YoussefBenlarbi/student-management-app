using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace student_management_app.DataAccess
{
    public class DatabaseConnection
    {
        private readonly string connectionString;

        public DatabaseConnection()
        {
            // Try to get connection string from config file, fallback to default
            connectionString = ConfigurationManager.ConnectionStrings["StudentManagementDB"]?.ConnectionString 
                ?? "Server=localhost;Database=student_management;Uid=root;Pwd=;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}