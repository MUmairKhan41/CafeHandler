using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CafeHandler.Models;

namespace CafeHandler.Database
{
    public class CategoryRepository : BaseRepository
    {
        // Get all categories
        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT category_id, category_name " +
                               "FROM categories ORDER BY category_name";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        CategoryId = reader.GetInt32("category_id"),
                        CategoryName = reader.GetString("category_name")
                    });
                }
            }
            return categories;
        }
    }
}