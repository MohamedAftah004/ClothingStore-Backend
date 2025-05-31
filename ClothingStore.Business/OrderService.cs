using ClothingStore.DataAccess;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStore.Business
{
    public class OrderService
    {
        public List<OrderDTO> GetAll()
        {
            return Order_Data.GetAll();
        }

        public OrderDTO GetById(int id)
        {
            return Order_Data.GetById(id);
        }

        public bool Insert(OrderDTO dto)
        {
            return Order_Data.Insert(dto);
        }

        public bool Update(OrderDTO dto)
        {
            return Order_Data.Update(dto);
        }

        public bool Delete(int id)
        {
            return Order_Data.Delete(id);
        }

        // Get all orders by customer
        public List<OrderDTO> GetByCustomerId(int customerId)
        {
            return Order_Data.GetByCustomerId(customerId);
        }

        // Update payment status (e.g. Paid, Pending, Failed)
        public bool UpdatePaymentStatus(int orderId, string newStatus)
        {
            return Order_Data.UpdatePaymentStatus(orderId, newStatus);
        }

        // Cancel the order
        public bool Cancel(int orderId)
        {
            return Order_Data.Cancel(orderId);
        }
    }
}
