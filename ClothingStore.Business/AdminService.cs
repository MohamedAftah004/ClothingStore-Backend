using ClothingStore.DataAccess;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStore.Business
{
    public class AdminService
    {
        public List<AdminDTO> GetAll()
        {
            return Admin_Data.GetAll();
        }

        public AdminDTO GetById(int id)
        {
            return Admin_Data.GetById(id);
        }

        public bool Insert(AdminDTO dto)
        {
            return Admin_Data.Insert(dto);
        }

        public bool Update(AdminDTO dto)
        {
            return Admin_Data.Update(dto);
        }

        public bool Delete(int id)
        {
            return Admin_Data.Delete(id);
        }
    }
}
