using ClothingStore.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClothingStore.DataAccess
{


    public class Review_Data
    {

        // Get Methods => Just For ADmin _
        public static List<ReviewDTO> GetAll()
        {
            List<ReviewDTO> list = new List<ReviewDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Review", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ReviewDTO()
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            ProductId = (int)reader["ProductId"],
                            Comment = (string)reader["Comment"]
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

        public static ReviewDTO GetById(int id)
        {
            ReviewDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Review WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new ReviewDTO()
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            ProductId = (int)reader["ProductId"],
                            Comment = (string)reader["Comment"]
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
        public static bool Insert(ReviewDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Review (CustomerId, ProductId, Comment) VALUES (@CustomerId, @ProductId, @Comment)", conn);
                    cmd.Parameters.AddWithValue("@CustomerId", dto.CustomerId);
                    cmd.Parameters.AddWithValue("@ProductId", dto.ProductId);
                    cmd.Parameters.AddWithValue("@Comment", dto.Comment);
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


        // Delete Methods
        public static bool Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Review WHERE Id = @Id", conn);
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


        public static List<ReviewDTO> GetByProductId(int productId)
        {
            List<ReviewDTO> list = new List<ReviewDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Review WHERE ProductId = @ProductId", conn);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ReviewDTO()
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            ProductId = (int)reader["ProductId"],
                            Comment = (string)reader["Comment"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByProductId: {ex.Message}");
            }
            return list;
        }



        public static List<ReviewDTO> GetByCustomerId(int customerId)
        {
            List<ReviewDTO> list = new List<ReviewDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Review WHERE CustomerId = @CustomerId", conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ReviewDTO()
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            ProductId = (int)reader["ProductId"],
                            Comment = (string)reader["Comment"]
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


        public static bool Exists(int customerId, int productId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Review WHERE CustomerId = @CustomerId AND ProductId = @ProductId", conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Exists: {ex.Message}");
                return false;
            }
        }



    }
}
