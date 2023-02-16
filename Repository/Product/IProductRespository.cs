using TUAApi.DBContext;

namespace TUAApi.Repository.Product
{
    public interface IProductRespository
    {
        Task<List<DBContext.Product>> GetProducts();
        Task<DBContext.Product> GetProductById(int productId);
        Task<List<ProductType>> GetProductTypes();
    }
}
