using ClothingStore.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClothingStore.DataAccess
{

    public class CartItems_Data
    {

        // Get Methods
        public static List<CartItemDTO> GetAll()
        {
            List<CartItemDTO> list = new List<CartItemDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CartItems", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new CartItemDTO()
                        {
                            Id = (int)reader["Id"],
                            ProductId = (int)reader["ProductId"],
                            CartId = (int)reader["CartId"],
                            Quantity = (int)reader["Quantity"],
                            Size = (string)reader["Size"],
                            Color = (string)reader["Color"]
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

        //Get B Id

        public static CartItemDTO GetById(int id)
        {
            CartItemDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CartItems WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new CartItemDTO()
                        {
                            Id = (int)reader["Id"],
                            ProductId = (int)reader["ProductId"],
                            CartId = (int)reader["CartId"],
                            Quantity = (int)reader["Quantity"],
                            Size = (string)reader["Size"],
                            Color = (string)reader["Color"]
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

        //get by cartId
        public static List<CartItemDTO> GetByCartId(int cartId)
        {
            List<CartItemDTO> list = new List<CartItemDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CartItems WHERE CartId = @CartId", conn);
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new CartItemDTO()
                        {
                            Id = (int)reader["Id"],
                            ProductId = (int)reader["ProductId"],
                            CartId = (int)reader["CartId"],
                            Quantity = (int)reader["Quantity"],
                            Size = (string)reader["Size"],
                            Color = (string)reader["Color"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByCartId: {ex.Message}");
            }
            return list;
        }


        // Insert Methods
        public static bool Insert(CartItemDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO CartItems (ProductId, CartId, Quantity, Size, Color) VALUES (@ProductId, @CartId, @Quantity, @Size, @Color)", conn);
                    cmd.Parameters.AddWithValue("@ProductId", dto.ProductId);
                    cmd.Parameters.AddWithValue("@CartId", dto.CartId);
                    cmd.Parameters.AddWithValue("@Quantity", dto.Quantity);
                    cmd.Parameters.AddWithValue("@Size", dto.Size);
                    cmd.Parameters.AddWithValue("@Color", dto.Color);
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
        public static bool Update(CartItemDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE CartItems SET ProductId = @ProductId, CartId = @CartId, Quantity = @Quantity, Size = @Size, Color = @Color WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", dto.Id);
                    cmd.Parameters.AddWithValue("@ProductId", dto.ProductId);
                    cmd.Parameters.AddWithValue("@CartId", dto.CartId);
                    cmd.Parameters.AddWithValue("@Quantity", dto.Quantity);
                    cmd.Parameters.AddWithValue("@Size", dto.Size);
                    cmd.Parameters.AddWithValue("@Color", dto.Color);
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

     

        //Clear 
        public static bool ClearCart(int cartId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM CartItems WHERE CartId = @CartId", conn);
                    cmd.Parameters.AddWithValue("@CartId", cartId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ClearCart: {ex.Message}");
                return false;
            }
        }
    }
}
