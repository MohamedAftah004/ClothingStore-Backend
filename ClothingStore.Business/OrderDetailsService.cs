using ClothingStore.DataAccess;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStore.Business
{
    public class OrderDetailsService
    {
        public List<OrderDetailsDTO> GetAll()
        {
            return OrderDetails_Data.GetAll();
        }

        public OrderDetailsDTO GetById(int id)
        {
            return OrderDetails_Data.GetById(id);
        }

        public bool Insert(OrderDetailsDTO dto)
        {
            return OrderDetails_Data.Insert(dto);
        }

        public bool Update(OrderDetailsDTO dto)
        {
            return OrderDetails_Data.Update(dto);
        }

        public bool Delete(int id)
        {
            return OrderDetails_Data.Delete(id);
        }
    }
}
