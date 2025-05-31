using ClothingStore.DataAccess;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStore.Business
{
    public class CartItemsService
    {
        public List<CartItemDTO> GetAll()
        {
            return CartItems_Data.GetAll();
        }

        public CartItemDTO GetById(int id)
        {
            return CartItems_Data.GetById(id);
        }

        public List<CartItemDTO> GetByCartId(int cartId)
        {
            return CartItems_Data.GetByCartId(cartId);
        }

        public bool Insert(CartItemDTO dto)
        {
            return CartItems_Data.Insert(dto);
        }

        public bool Update(CartItemDTO dto)
        {
            return CartItems_Data.Update(dto);
        }

        public bool ClearCart(int cartId)
        {
            return CartItems_Data.ClearCart(cartId);
        }
    }
}
