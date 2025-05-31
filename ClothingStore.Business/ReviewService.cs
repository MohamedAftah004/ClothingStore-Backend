using ClothingStore.DataAccess;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStore.Business
{
    public class ReviewService
    {
        public List<ReviewDTO> GetAll()
        {
            return Review_Data.GetAll();
        }

        public ReviewDTO GetById(int id)
        {
            return Review_Data.GetById(id);
        }

        public bool Insert(ReviewDTO dto)
        {
            return Review_Data.Insert(dto);
        }

        public bool Delete(int id)
        {
            return Review_Data.Delete(id);
        }

        // Get all reviews for a specific product
        public List<ReviewDTO> GetByProductId(int productId)
        {
            return Review_Data.GetByProductId(productId);
        }

        // Get all reviews made by a specific customer
        public List<ReviewDTO> GetByCustomerId(int customerId)
        {
            return Review_Data.GetByCustomerId(customerId);
        }

        // Check if customer already reviewed a product
        public bool Exists(int customerId, int productId)
        {
            return Review_Data.Exists(customerId, productId);
        }
    }
}
