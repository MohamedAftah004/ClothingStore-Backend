namespace ClothingStore.DataAccess.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<CartItemDTO> Items { get; set; } = new();

    }
}
