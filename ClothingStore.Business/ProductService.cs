using ClothingStore.DataAccess;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStore.Business
{
    public class ProductService
    {
        public List<ProductDTO> GetAll()
        {
            return Product_Data.GetAll();
        }

        public ProductDTO GetById(int id)
        {
            return Product_Data.GetById(id);
        }

        public bool Insert(ProductDTO dto)
        {
            return Product_Data.Insert(dto);
        }

        public bool Update(ProductDTO dto)
        {
            return Product_Data.Update(dto);
        }

        public bool Delete(int id)
        {
            return Product_Data.Delete(id);
        }

        public List<ProductDTO> GetByCategoryId(int categoryId)
        {
            return Product_Data.GetByCategoryId(categoryId);
        }

        public List<ProductDTO> SearchByName(string name)
        {
            return Product_Data.SearchByName(name);
        }

        public List<ProductDTO> GetInStock()
        {
            return Product_Data.GetInStock();
        }

        // Get products within a price range
        public List<ProductDTO> GetByPriceRange(decimal min, decimal max)
        {
            return Product_Data.GetByPriceRange(min, max);
        }

        //  Get latest N products
        public List<ProductDTO> GetLatest(int limit = 10)
        {
            return Product_Data.GetLatest(limit);
        }
    }
}
