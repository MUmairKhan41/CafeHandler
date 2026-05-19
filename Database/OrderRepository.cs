using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CafeHandler.Models;

namespace CafeHandler.Database
{
    public class OrderRepository : BaseRepository
    {
        // Get orders with filter
        public List<Order> GetAll(string filterType = "all", DateTime? date = null)
        {
            List<Order> orders = new List<Order>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query;

                if (filterType == "today" || filterType == "date")
                {
                    query = @"SELECT o.order_id, u.full_name AS cashier,
                              o.table_number, o.total_amount,
                              o.status, o.order_date
                              FROM orders o
                              JOIN users u ON o.user_id = u.user_id
                              WHERE DATE(o.order_date) = @date
                              ORDER BY o.order_date DESC";
                }
                else
                {
                    query = @"SELECT o.order_id, u.full_name AS cashier,
                              o.table_number, o.total_amount,
                              o.status, o.order_date
                              FROM orders o
                              JOIN users u ON o.user_id = u.user_id
                              ORDER BY o.order_date DESC";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (filterType != "all" && date.HasValue)
                    cmd.Parameters.AddWithValue("@date",
                        date.Value.ToString("yyyy-MM-dd"));

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderId = reader.GetInt32("order_id"),
                        CashierName = reader.GetString("cashier"),
                        TableNumber = reader.GetInt32("table_number"),
                        TotalAmount = reader.GetDecimal("total_amount"),
                        Status = reader.GetString("status"),
                        OrderDate = reader.GetDateTime("order_date")
                    });
                }
            }
            return orders;
        }

        // Save new order — returns the new order ID
        public long Save(Order order)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO orders
                                 (user_id, table_number, total_amount, status)
                                 VALUES (@uid, @table, @total, 'completed')";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uid", order.UserId);
                cmd.Parameters.AddWithValue("@table", order.TableNumber);
                cmd.Parameters.AddWithValue("@total", order.TotalAmount);
                cmd.ExecuteNonQuery();

                return cmd.LastInsertedId;
            }
        }

        // Get summary stats for reports
        public (decimal totalSales, int totalOrders, decimal avgOrder)
            GetSummaryStats(DateTime from, DateTime to)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"SELECT
                                 COUNT(*) AS total_orders,
                                 COALESCE(SUM(total_amount), 0) AS total_sales,
                                 COALESCE(AVG(total_amount), 0) AS avg_order
                                 FROM orders
                                 WHERE DATE(order_date) BETWEEN @from AND @to
                                 AND status = 'completed'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@from", from.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", to.ToString("yyyy-MM-dd"));

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return (
                        Convert.ToDecimal(reader["total_sales"]),
                        Convert.ToInt32(reader["total_orders"]),
                        Convert.ToDecimal(reader["avg_order"])
                    );
                }
            }
            return (0, 0, 0);
        }
        // Save order inside an existing transaction
        // (connection and transaction passed from the form)
        public long SaveWithTransaction(Order order,
            MySqlConnection conn, MySqlTransaction transaction)
        {
            string query = @"INSERT INTO orders
                     (user_id, table_number, total_amount, status)
                     VALUES (@uid, @table, @total, 'completed')";

            MySqlCommand cmd = new MySqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@uid", order.UserId);
            cmd.Parameters.AddWithValue("@table", order.TableNumber);
            cmd.Parameters.AddWithValue("@total", order.TotalAmount);
            cmd.ExecuteNonQuery();

            return cmd.LastInsertedId; // Return the new order_id
        }
    }
}