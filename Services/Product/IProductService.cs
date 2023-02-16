using TUAApi.DTO.Product;

namespace TUAApi.Services.Product
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<List<ProductTypeDto>> GetProductTypes();
    }
}
