using ClothingStore.DataAccess;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStore.Business
{
    public class CustomerService
    {
        public List<CustomerDTO> GetAll()
        {
            return Customer_Data.GetAll();
        }

        public CustomerDTO GetById(int id)
        {
            return Customer_Data.GetById(id);
        }

        public bool Register(CustomerDTO dto)
        {
            return Customer_Data.Register(dto);
        }

        public CustomerDTO Login(string email, string password)
        {
            return Customer_Data.Login(email, password);
        }


        public bool Update(CustomerDTO dto)
        {
            return Customer_Data.Update(dto);
        }

        public bool Delete(int id)
        {
            return Customer_Data.Delete(id);
        }

    }
}
