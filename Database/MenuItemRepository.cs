using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CafeHandler.Models;

namespace CafeHandler.Database
{
    public class MenuItemRepository : BaseRepository
    {
        // Get all menu items with optional search filter
        public List<CafeMenuItem> GetAll(string search = "")
        {
            List<CafeMenuItem> items = new List<CafeMenuItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT m.item_id, m.category_id,
                                 c.category_name, m.item_name,
                                 m.price, m.description, m.is_available
                                 FROM menu_items m
                                 JOIN categories c
                                 ON m.category_id = c.category_id
                                 WHERE m.item_name LIKE @search
                                 ORDER BY c.category_name, m.item_name";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(new CafeMenuItem
                    {
                        ItemId = reader.GetInt32("item_id"),
                        CategoryId = reader.GetInt32("category_id"),
                        CategoryName = reader.GetString("category_name"),
                        ItemName = reader.GetString("item_name"),
                        Price = reader.GetDecimal("price"),
                        Description = reader.IsDBNull(
                                       reader.GetOrdinal("description"))
                                       ? "" : reader.GetString("description"),
                        IsAvailable = reader.GetBoolean("is_available")
                    });
                }
            }
            return items;
        }

        // Get only available items for the POS screen
        public List<CafeMenuItem> GetAvailable(string categoryName = "All")
        {
            List<CafeMenuItem> items = new List<CafeMenuItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query;

                if (categoryName == "All")
                {
                    query = @"SELECT m.item_id, m.category_id,
                              c.category_name, m.item_name, m.price
                              FROM menu_items m
                              JOIN categories c ON m.category_id = c.category_id
                              WHERE m.is_available = 1
                              ORDER BY c.category_name, m.item_name";
                }
                else
                {
                    query = @"SELECT m.item_id, m.category_id,
                              c.category_name, m.item_name, m.price
                              FROM menu_items m
                              JOIN categories c ON m.category_id = c.category_id
                              WHERE m.is_available = 1
                              AND c.category_name = @cat
                              ORDER BY m.item_name";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (categoryName != "All")
                    cmd.Parameters.AddWithValue("@cat", categoryName);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(new CafeMenuItem
                    {
                        ItemId = reader.GetInt32("item_id"),
                        CategoryId = reader.GetInt32("category_id"),
                        CategoryName = reader.GetString("category_name"),
                        ItemName = reader.GetString("item_name"),
                        Price = reader.GetDecimal("price")
                    });
                }
            }
            return items;
        }

        // Add a new menu item
        public bool Add(CafeMenuItem item)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO menu_items
                                 (category_id, item_name, price,
                                  description, is_available)
                                 VALUES (@cat, @name, @price, @desc, @avail)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cat", item.CategoryId);
                cmd.Parameters.AddWithValue("@name", item.ItemName);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.Parameters.AddWithValue("@desc", item.Description);
                cmd.Parameters.AddWithValue("@avail", item.IsAvailable ? 1 : 0);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Update an existing menu item
        public bool Update(CafeMenuItem item)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE menu_items SET
                                 category_id  = @cat,
                                 item_name    = @name,
                                 price        = @price,
                                 description  = @desc,
                                 is_available = @avail
                                 WHERE item_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cat", item.CategoryId);
                cmd.Parameters.AddWithValue("@name", item.ItemName);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.Parameters.AddWithValue("@desc", item.Description);
                cmd.Parameters.AddWithValue("@avail", item.IsAvailable ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", item.ItemId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Delete a menu item by ID
        public bool Delete(int itemId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM menu_items WHERE item_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", itemId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}