using ClothingStore.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClothingStore.DataAccess
{

    public class OrderDetails_Data
    {

        // Get Methods
        public static List<OrderDetailsDTO> GetAll()
        {
            List<OrderDetailsDTO> list = new List<OrderDetailsDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM OrderDetails", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new OrderDetailsDTO()
                        {
                            Id = (int)reader["Id"],
                            OrderId = (int)reader["OrderId"],
                            ProductId = (int)reader["ProductId"],
                            Quantity = (int)reader["Quantity"],
                            UnitPrice = (decimal)reader["UnitPrice"]
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

        public static OrderDetailsDTO GetById(int id)
        {
            OrderDetailsDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM OrderDetails WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new OrderDetailsDTO()
                        {
                            Id = (int)reader["Id"],
                            OrderId = (int)reader["OrderId"],
                            ProductId = (int)reader["ProductId"],
                            Quantity = (int)reader["Quantity"],
                            UnitPrice = (decimal)reader["UnitPrice"]
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
        public static bool Insert(OrderDetailsDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice) VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice)", conn);
                    cmd.Parameters.AddWithValue("@OrderId", dto.OrderId);
                    cmd.Parameters.AddWithValue("@ProductId", dto.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", dto.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", dto.UnitPrice);
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
        public static bool Update(OrderDetailsDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE OrderDetails SET OrderId = @OrderId, ProductId = @ProductId, Quantity = @Quantity, UnitPrice = @UnitPrice WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", dto.Id);
                    cmd.Parameters.AddWithValue("@OrderId", dto.OrderId);
                    cmd.Parameters.AddWithValue("@ProductId", dto.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", dto.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", dto.UnitPrice);
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM OrderDetails WHERE Id = @Id", conn);
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
    }
}
