using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CafeHandler.Models;

namespace CafeHandler.Database
{
    public class UserRepository : BaseRepository
    {
        // Get all users
        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT user_id, full_name, username, " +
                               "role, is_active, created_at FROM users " +
                               "ORDER BY created_at DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = reader.GetInt32("user_id"),
                        FullName = reader.GetString("full_name"),
                        Username = reader.GetString("username"),
                        Role = reader.GetString("role"),
                        IsActive = reader.GetBoolean("is_active")
                    });
                }
            }
            return users;
        }

        // Get single user by username and password (for login)
        public User GetByCredentials(string username, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT user_id, full_name, role FROM users " +
                               "WHERE username=@u AND password=@p AND is_active=1";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = reader.GetInt32("user_id"),
                        FullName = reader.GetString("full_name"),
                        Role = reader.GetString("role")
                    };
                }
            }
            return null; // no matching user found
        }

        // Add new user
        public bool Add(User user)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO users " +
                               "(full_name, username, password, role, is_active) " +
                               "VALUES (@name, @user, @pass, @role, @active)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", user.FullName);
                cmd.Parameters.AddWithValue("@user", user.Username);
                cmd.Parameters.AddWithValue("@pass", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@active", user.IsActive ? 1 : 0);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Update user (with password change)
        public bool Update(User user)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE users SET " +
                               "full_name=@name, username=@user, " +
                               "password=@pass, role=@role, is_active=@active " +
                               "WHERE user_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", user.FullName);
                cmd.Parameters.AddWithValue("@user", user.Username);
                cmd.Parameters.AddWithValue("@pass", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@active", user.IsActive ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", user.UserId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Update user (without changing password)
        public bool UpdateWithoutPassword(User user)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE users SET " +
                               "full_name=@name, username=@user, " +
                               "role=@role, is_active=@active " +
                               "WHERE user_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", user.FullName);
                cmd.Parameters.AddWithValue("@user", user.Username);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@active", user.IsActive ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", user.UserId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Delete user
        public bool Delete(int userId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM users WHERE user_id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}