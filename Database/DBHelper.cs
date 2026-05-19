using System;
using MySql.Data.MySqlClient;

namespace CafeHandler.Database
{
    public class DBHelper
    {
        private static string connectionString =
    "Server=127.0.0.1;Port=3306;Database=cafe_db;Uid=root;Pwd=1234;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}