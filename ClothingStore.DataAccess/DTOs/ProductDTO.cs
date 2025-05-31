namespace ClothingStore.DataAccess.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Colors { get; set; }
        public int? CategoryId { get; set; }
        public string? Material { get; set; }
        public string? ImgURL { get; set; }
        public bool InStock { get; set; }
    }
}
