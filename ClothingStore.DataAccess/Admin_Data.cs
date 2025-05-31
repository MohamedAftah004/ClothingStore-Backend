using ClothingStore.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClothingStore.DataAccess
{
   
    public class Admin_Data
    {

        // Get Methods
        public static List<AdminDTO> GetAll()
        {
            List<AdminDTO> list = new List<AdminDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Admin", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new AdminDTO()
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            UserName = (string)reader["UserName"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Phone = (string)reader["Phone"],
                            Address = (string)reader["Address"],
                            NationalId = (string)reader["NationalId"]
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
        public static AdminDTO GetById(int id)
        {
            AdminDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Admin WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new AdminDTO()
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            UserName = (string)reader["UserName"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Phone = (string)reader["Phone"],
                            Address = (string)reader["Address"],
                            NationalId = (string)reader["NationalId"]
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
        public static bool Insert(AdminDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Admin (FirstName, LastName, UserName, Email, Password, Phone, Address, NationalId) VALUES (@FirstName, @LastName, @UserName, @Email, @Password, @Phone, @Address, @NationalId)", conn);
                    cmd.Parameters.AddWithValue("@FirstName", dto.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", dto.LastName);
                    cmd.Parameters.AddWithValue("@UserName", dto.UserName);
                    cmd.Parameters.AddWithValue("@Email", dto.Email);
                    cmd.Parameters.AddWithValue("@Password", dto.Password);
                    cmd.Parameters.AddWithValue("@Phone", dto.Phone);
                    cmd.Parameters.AddWithValue("@Address", dto.Address);
                    cmd.Parameters.AddWithValue("@NationalId", dto.NationalId);
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
        public static bool Update(AdminDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Admin SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, Email = @Email, Password = @Password, Phone = @Phone, Address = @Address, NationalId = @NationalId WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", dto.Id);
                    cmd.Parameters.AddWithValue("@FirstName", dto.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", dto.LastName);
                    cmd.Parameters.AddWithValue("@UserName", dto.UserName);
                    cmd.Parameters.AddWithValue("@Email", dto.Email);
                    cmd.Parameters.AddWithValue("@Password", dto.Password);
                    cmd.Parameters.AddWithValue("@Phone", dto.Phone);
                    cmd.Parameters.AddWithValue("@Address", dto.Address);
                    cmd.Parameters.AddWithValue("@NationalId", dto.NationalId);
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM Admin WHERE Id = @Id", conn);
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
