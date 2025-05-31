using ClothingStore.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ClothingStore.DataAccess
{
 

    public class Customer_Data
    {

        // Get Methods
        public static List<CustomerDTO> GetAll()
        {
            List<CustomerDTO> list = new List<CustomerDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new CustomerDTO()
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Phone = (string)reader["Phone"],
                            Address = (string)reader["Address"]
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
        public static CustomerDTO GetById(int id)
        {
            CustomerDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new CustomerDTO()
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Phone = (string)reader["Phone"],
                            Address = (string)reader["Address"]
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



        // Register Methods
        public static bool Register(CustomerDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Customer (FirstName, LastName, Email, Password, Phone, Address) VALUES (@FirstName, @LastName, @Email, @Password, @Phone, @Address)", conn);
                    cmd.Parameters.AddWithValue("@FirstName", dto.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", dto.LastName);
                    cmd.Parameters.AddWithValue("@Email", dto.Email);
                    cmd.Parameters.AddWithValue("@Password", dto.Password);
                    cmd.Parameters.AddWithValue("@Phone", dto.Phone);
                    cmd.Parameters.AddWithValue("@Address", dto.Address);
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

        //Login
        public static CustomerDTO Login(string email, string password)
        {
            CustomerDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE Email = @Email AND Password = @Password", conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new CustomerDTO()
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Phone = (string)reader["Phone"],
                            Address = (string)reader["Address"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Login: {ex.Message}");
            }
            return result;
        }



        // Update Methods
        public static bool Update(CustomerDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Password = @Password, Phone = @Phone, Address = @Address WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", dto.Id);
                    cmd.Parameters.AddWithValue("@FirstName", dto.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", dto.LastName);
                    cmd.Parameters.AddWithValue("@Email", dto.Email);
                    cmd.Parameters.AddWithValue("@Password", dto.Password);
                    cmd.Parameters.AddWithValue("@Phone", dto.Phone);
                    cmd.Parameters.AddWithValue("@Address", dto.Address);
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE Id = @Id", conn);
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
