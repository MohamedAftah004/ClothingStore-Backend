namespace ClothingStore.DataAccess.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }
    }
}
