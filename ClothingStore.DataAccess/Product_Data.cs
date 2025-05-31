using ClothingStore.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ClothingStore.DataAccess
{
    public class Product_Data
    {

        // Get Methods
        public static List<ProductDTO> GetAll()
        {
            List<ProductDTO> list = new List<ProductDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Product", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ProductDTO()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            Price = (decimal)reader["Price"],
                            Colors = (string)reader["Colors"],
                            CategoryId = (int)reader["CategoryId"],
                            Material = (string)reader["Material"],
                            ImgURL = (string)reader["ImgURL"],
                            InStock = (bool)reader["InStock"]
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

        public static ProductDTO GetById(int id)
        {
            ProductDTO result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        result = new ProductDTO()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            Price = (decimal)reader["Price"],
                            Colors = (string)reader["Colors"],
                            CategoryId = (int)reader["CategoryId"],
                            Material = (string)reader["Material"],
                            ImgURL = (string)reader["ImgURL"],
                            InStock = (bool)reader["InStock"]
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
        public static bool Insert(ProductDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Product (Name, Description, Price, Colors, CategoryId, Material, ImgURL, InStock) VALUES (@Name, @Description, @Price, @Colors, @CategoryId, @Material, @ImgURL, @InStock)", conn);
                    cmd.Parameters.AddWithValue("@Name", dto.Name);
                    cmd.Parameters.AddWithValue("@Description", dto.Description);
                    cmd.Parameters.AddWithValue("@Price", dto.Price);
                    cmd.Parameters.AddWithValue("@Colors", dto.Colors);
                    cmd.Parameters.AddWithValue("@CategoryId", dto.CategoryId);
                    cmd.Parameters.AddWithValue("@Material", dto.Material);
                    cmd.Parameters.AddWithValue("@ImgURL", dto.ImgURL);
                    cmd.Parameters.AddWithValue("@InStock", dto.InStock);
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
        public static bool Update(ProductDTO dto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Product SET Name = @Name, Description = @Description, Price = @Price, Colors = @Colors, CategoryId = @CategoryId, Material = @Material, ImgURL = @ImgURL, InStock = @InStock WHERE Id = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", dto.Id);
                    cmd.Parameters.AddWithValue("@Name", dto.Name);
                    cmd.Parameters.AddWithValue("@Description", dto.Description);
                    cmd.Parameters.AddWithValue("@Price", dto.Price);
                    cmd.Parameters.AddWithValue("@Colors", dto.Colors);
                    cmd.Parameters.AddWithValue("@CategoryId", dto.CategoryId);
                    cmd.Parameters.AddWithValue("@Material", dto.Material);
                    cmd.Parameters.AddWithValue("@ImgURL", dto.ImgURL);
                    cmd.Parameters.AddWithValue("@InStock", dto.InStock);
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE Id = @Id", conn);
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

        //get all instock
        public static List<ProductDTO> GetInStock()
        {
            List<ProductDTO> list = new List<ProductDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE InStock = 1", conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ProductDTO()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            Price = (decimal)reader["Price"],
                            Colors = (string)reader["Colors"],
                            CategoryId = (int)reader["CategoryId"],
                            Material = (string)reader["Material"],
                            ImgURL = (string)reader["ImgURL"],
                            InStock = (bool)reader["InStock"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetInStock: {ex.Message}");
            }
            return list;
        }


        public static List<ProductDTO> GetByCategoryId(int categoryId)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE CategoryId = @CategoryId", conn);
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ProductDTO()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            Price = (decimal)reader["Price"],
                            Colors = (string)reader["Colors"],
                            CategoryId = (int)reader["CategoryId"],
                            Material = (string)reader["Material"],
                            ImgURL = (string)reader["ImgURL"],
                            InStock = (bool)reader["InStock"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByCategoryId: {ex.Message}");
            }
            return list;
        }

        public static List<ProductDTO> SearchByName(string name)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE Name LIKE @Name", conn);
                    cmd.Parameters.AddWithValue("@Name", $"%{name}%");
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ProductDTO()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            Price = (decimal)reader["Price"],
                            Colors = (string)reader["Colors"],
                            CategoryId = (int)reader["CategoryId"],
                            Material = (string)reader["Material"],
                            ImgURL = (string)reader["ImgURL"],
                            InStock = (bool)reader["InStock"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchByName: {ex.Message}");
            }
            return list;
        }



        public static List<ProductDTO> GetByPriceRange(decimal min, decimal max)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE Price BETWEEN @Min AND @Max", conn);
                    cmd.Parameters.AddWithValue("@Min", min);
                    cmd.Parameters.AddWithValue("@Max", max);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ProductDTO()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            Price = (decimal)reader["Price"],
                            Colors = (string)reader["Colors"],
                            CategoryId = (int)reader["CategoryId"],
                            Material = (string)reader["Material"],
                            ImgURL = (string)reader["ImgURL"],
                            InStock = (bool)reader["InStock"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByPriceRange: {ex.Message}");
            }
            return list;
        }


        public static List<ProductDTO> GetLatest(int limit = 10)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessLayer_Settings.connectionString))
                {
                    SqlCommand cmd = new SqlCommand($"SELECT TOP (@Limit) * FROM Product ORDER BY Id DESC", conn);
                    cmd.Parameters.AddWithValue("@Limit", limit);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new ProductDTO()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                            Price = (decimal)reader["Price"],
                            Colors = (string)reader["Colors"],
                            CategoryId = (int)reader["CategoryId"],
                            Material = (string)reader["Material"],
                            ImgURL = (string)reader["ImgURL"],
                            InStock = (bool)reader["InStock"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetLatest: {ex.Message}");
            }
            return list;
        }



    }
}
