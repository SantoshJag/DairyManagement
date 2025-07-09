namespace DairyManagement.Application.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }


    }
}