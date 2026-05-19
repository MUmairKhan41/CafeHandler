using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CafeHandler.Models;

namespace CafeHandler.Database
{
    public class OrderItemRepository : BaseRepository
    {
        // Save all items for an order (called inside transaction)
        public void SaveItems(long orderId, List<OrderItem> items,
                              MySqlConnection conn, MySqlTransaction transaction)
        {
            foreach (OrderItem item in items)
            {
                string query = @"INSERT INTO order_items
                                 (order_id, item_id, quantity,
                                  unit_price, subtotal)
                                 VALUES (@oid, @iid, @qty, @uprice, @sub)";

                MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
                cmd.Parameters.AddWithValue("@oid", orderId);
                cmd.Parameters.AddWithValue("@iid", item.ItemId);
                cmd.Parameters.AddWithValue("@qty", item.Quantity);
                cmd.Parameters.AddWithValue("@uprice", item.UnitPrice);
                cmd.Parameters.AddWithValue("@sub", item.Subtotal);
                cmd.ExecuteNonQuery();
            }
        }

        // Get items for a specific order (for View Orders detail panel)
        public List<OrderItem> GetByOrderId(int orderId)
        {
            List<OrderItem> items = new List<OrderItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT m.item_name, oi.quantity,
                                 oi.unit_price, oi.subtotal
                                 FROM order_items oi
                                 JOIN menu_items m ON oi.item_id = m.item_id
                                 WHERE oi.order_id = @oid";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@oid", orderId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(new OrderItem
                    {
                        ItemName = reader.GetString("item_name"),
                        Quantity = reader.GetInt32("quantity"),
                        UnitPrice = reader.GetDecimal("unit_price"),
                        Subtotal = reader.GetDecimal("subtotal")
                    });
                }
            }
            return items;
        }

        // Get best selling items for reports
        public List<(string itemName, int totalQty, decimal totalRevenue)>
            GetBestSelling(DateTime from, DateTime to)
        {
            var result = new List<(string, int, decimal)>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT m.item_name,
                                 SUM(oi.quantity) AS total_qty,
                                 SUM(oi.subtotal) AS total_revenue
                                 FROM order_items oi
                                 JOIN menu_items m ON oi.item_id = m.item_id
                                 JOIN orders o ON oi.order_id = o.order_id
                                 WHERE DATE(o.order_date) BETWEEN @from AND @to
                                 AND o.status = 'completed'
                                 GROUP BY m.item_id, m.item_name
                                 ORDER BY total_qty DESC
                                 LIMIT 10";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@from", from.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", to.ToString("yyyy-MM-dd"));

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((
                        reader.GetString("item_name"),
                        Convert.ToInt32(reader["total_qty"]),
                        Convert.ToDecimal(reader["total_revenue"])
                    ));
                }
            }
            return result;
        }

        // Get sales by category for reports
        public List<(string category, int totalOrders, int totalItems, decimal revenue)>
            GetByCategory(DateTime from, DateTime to)
        {
            var result = new List<(string, int, int, decimal)>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT c.category_name,
                                 COUNT(DISTINCT o.order_id) AS total_orders,
                                 SUM(oi.quantity) AS total_items,
                                 SUM(oi.subtotal) AS total_revenue
                                 FROM order_items oi
                                 JOIN menu_items m ON oi.item_id = m.item_id
                                 JOIN categories c ON m.category_id = c.category_id
                                 JOIN orders o ON oi.order_id = o.order_id
                                 WHERE DATE(o.order_date) BETWEEN @from AND @to
                                 AND o.status = 'completed'
                                 GROUP BY c.category_id, c.category_name
                                 ORDER BY total_revenue DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@from", from.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", to.ToString("yyyy-MM-dd"));

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((
                        reader.GetString("category_name"),
                        Convert.ToInt32(reader["total_orders"]),
                        Convert.ToInt32(reader["total_items"]),
                        Convert.ToDecimal(reader["total_revenue"])
                    ));
                }
            }
            return result;
        }
    }
}