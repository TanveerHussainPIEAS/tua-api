using TUAApi.DBContext;

namespace TUAApi.DTO.Product
{
    public class ProductDto
    {
        public int? Id { get; set; }

        public int TypeId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Details { get; set; } = null!;

        public virtual List<ProductImageDto> ProductImages { get; set; } 

        //public virtual ProductTypeDto Type { get; set; } = null!;
    }
}
