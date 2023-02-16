namespace TUAApi.DTO.Product
{
    public class ProductImageDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string? Url { get; set; }

        public string? Details { get; set; }
    }
}
