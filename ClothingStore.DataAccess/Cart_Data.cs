using ClothingStore.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClothingStore.DataAccess
{
    public class Cart_Data
    {

        // Get Methods
        public static List<CartDTO> GetAll()
        {
            List<CartDTO> list = new List<CartDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Cart", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new CartDTO()
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            CreateAt = (DateTime)reader["CreateAt"],
                            UpdatedAt = (DateTime)reader["UpdatedAt"],
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

        //get bu Id
        public static CartDTO GetById(int id)
        {
            CartDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Cart WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new CartDTO()
                        {
                            Id = (int)reader["Id"],
                            CustomerId = (int)reader["CustomerId"],
                            CreateAt = (DateTime)reader["CreateAt"],
                            UpdatedAt = (DateTime)reader["UpdatedAt"],
                            Items = CartItems_Data.GetByCartId((int)reader["Id"]) // ✅ الربط هنا
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
        public static bool Insert(CartDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Cart (CustomerId, CreateAt, UpdatedAt) VALUES (@CustomerId, @CreateAt, @UpdatedAt)", conn);
                    cmd.Parameters.AddWithValue("@CustomerId", dto.CustomerId);
                    cmd.Parameters.AddWithValue("@CreateAt", dto.CreateAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", dto.UpdatedAt);
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
        public static bool Update(CartDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Cart SET CustomerId = @CustomerId, CreateAt = @CreateAt, UpdatedAt = @UpdatedAt WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", dto.Id);
                    cmd.Parameters.AddWithValue("@CustomerId", dto.CustomerId);
                    cmd.Parameters.AddWithValue("@CreateAt", dto.CreateAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", dto.UpdatedAt);
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM Cart WHERE Id = @Id", conn);
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


        // cart=> specsfic customer
        public static CartDTO GetByCustomerId(int customerId)
        {
            CartDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Cart WHERE CustomerId = @CustomerId", conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int cartId = (int)reader["Id"];
                        result = new CartDTO()
                        {
                            Id = cartId,
                            CustomerId = (int)reader["CustomerId"],
                            CreateAt = (DateTime)reader["CreateAt"],
                            UpdatedAt = (DateTime)reader["UpdatedAt"],
                            Items = CartItems_Data.GetByCartId(cartId) 
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByCustomerId: {ex.Message}");
            }
            return result;
        }


        //exsist for customer? -> not used directly
        public static bool ExistsForCustomer(int customerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Cart WHERE CustomerId = @CustomerId", conn);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ExistsForCustomer: {ex.Message}");
                return false;
            }
        }

        //create if not => used
        public static CartDTO CreateIfNotExists(int customerId)
        {
            var existingCart = GetByCustomerId(customerId);
            if (existingCart != null)
                return existingCart;

            var newCart = new CartDTO
            {
                CustomerId = customerId,
                CreateAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (Insert(newCart))
                return GetByCustomerId(customerId);

            return null;
        }




    }
}
