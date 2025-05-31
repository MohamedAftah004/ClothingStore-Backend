using ClothingStore.DataAccess;
using ClothingStore.DataAccess.DTOs;
using System.Collections.Generic;

namespace ClothingStore.Business
{
    public class CategoryService
    {
        public List<CategoryDTO> GetAll()
        {
            return Category_Data.GetAll();
        }

        public CategoryDTO GetById(int id)
        {
            return Category_Data.GetById(id);
        }

        public bool Insert(CategoryDTO dto)
        {
            return Category_Data.Insert(dto);
        }

        public bool Update(CategoryDTO dto)
        {
            return Category_Data.Update(dto);
        }

        public bool Delete(int id)
        {
            return Category_Data.Delete(id);
        }
    }
}
