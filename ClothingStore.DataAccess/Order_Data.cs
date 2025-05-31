using ClothingStore.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClothingStore.DataAccess
{
    public class Order_Data
    {

        // Get Methods
        public static List<OrderDTO> GetAll()
        {
            List<OrderDTO> list = new List<OrderDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Order", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new OrderDTO()
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            PaymentStatus = (string)reader["PaymentStatus"],
                            PaymentMethod = (string)reader["PaymentMethod"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAll: {ex.Message}");
            }
            return list;
        }



        // GetById Method
        public static OrderDTO GetById(int id)
        {
            OrderDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [Order] WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new OrderDTO()
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            PaymentStatus = (string)reader["PaymentStatus"],
                            PaymentMethod = (string)reader["PaymentMethod"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetById: {ex.Message}");
            }
            return result;
        }



        // Insert Methods
        public static bool Insert(OrderDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Order (CustomerId, OrderDate, TotalAmount, PaymentStatus, PaymentMethod) VALUES (@CustomerId, @OrderDate, @TotalAmount, @PaymentStatus, @PaymentMethod)", conn);
                    cmd.Parameters.AddWithValue("@CustomerId", dto.CustomerId);
                    cmd.Parameters.AddWithValue("@OrderDate", dto.OrderDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", dto.TotalAmount);
                    cmd.Parameters.AddWithValue("@PaymentStatus", dto.PaymentStatus);
                    cmd.Parameters.AddWithValue("@PaymentMethod", dto.PaymentMethod);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Insert: {ex.Message}");
                return false;
            }
        }

        // Update Methods
        public static bool Update(OrderDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Order SET CustomerId = @CustomerId, OrderDate = @OrderDate, TotalAmount = @TotalAmount, PaymentStatus = @PaymentStatus, PaymentMethod = @PaymentMethod WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", dto.Id);
                    cmd.Parameters.AddWithValue("@CustomerId", dto.CustomerId);
                    cmd.Parameters.AddWithValue("@OrderDate", dto.OrderDate);
                    cmd.Parameters.AddWithValue("@TotalAmount", dto.TotalAmount);
                    cmd.Parameters.AddWithValue("@PaymentStatus", dto.PaymentStatus);
                    cmd.Parameters.AddWithValue("@PaymentMethod", dto.PaymentMethod);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                return false;
            }
        }

        // Delete Methods
        public static bool Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Order WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete: {ex.Message}");
                return false;
            }
        }

        //Get By customer di
        public static List<OrderDTO> GetByCustomerId(int customerId)
        {
            List<OrderDTO> list = new List<OrderDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [Order] WHERE CustomerId = @CustomerId", conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new OrderDTO()
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            OrderDate = (DateTime)reader["OrderDate"],
                            TotalAmount = (decimal)reader["TotalAmount"],
                            PaymentStatus = (string)reader["PaymentStatus"],
                            PaymentMethod = (string)reader["PaymentMethod"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByCustomerId: {ex.Message}");
            }
            return list;
        }


        public static bool UpdatePaymentStatus(int orderId, string newStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [Order] SET PaymentStatus = @Status WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", orderId);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdatePaymentStatus: {ex.Message}");
                return false;
            }
        }


        public static bool Cancel(int orderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [Order] SET PaymentStatus = 'Cancelled' WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", orderId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Cancel: {ex.Message}");
                return false;
            }
        }


    }
}
