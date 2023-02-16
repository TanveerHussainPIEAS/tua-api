using TUAApi.DBContext;

namespace TUAApi.DTO.Product
{
    public class ProductDto
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Details { get; set; } = null!;

        public virtual ICollection<ProductImage> ProductImages { get; } = new List<ProductImage>();

        public virtual ProductType Type { get; set; } = null!;
    }
}
