using ClothingStore.DataAccess;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStore.Business
{
    public class CartService
    {
        public List<CartDTO> GetAll()
        {
            return Cart_Data.GetAll();
        }

        public CartDTO GetById(int id)
        {
            return Cart_Data.GetById(id);
        }

        public bool Update(CartDTO dto)
        {
            return Cart_Data.Update(dto);
        }

        public bool Delete(int id)
        {
            return Cart_Data.Delete(id);
        }

        public CartDTO GetByCustomerId(int customerId)
        {
            return Cart_Data.GetByCustomerId(customerId);
        }

        public bool ExistsForCustomer(int customerId)
        {
            return Cart_Data.ExistsForCustomer(customerId);
        }

        public CartDTO CreateIfNotExists(int customerId)
        {
            return Cart_Data.CreateIfNotExists(customerId);
        }
    }
}
