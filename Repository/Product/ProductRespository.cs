using Microsoft.EntityFrameworkCore;
using TUAApi.DBContext;

namespace TUAApi.Repository.Product
{
    public class ProductRespository : IProductRespository
    {
        private TuaDbContext _dBContext;
        public ProductRespository(TuaDbContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<DBContext.Product> GetProductById(int productId)
        {
            var product = await _dBContext.Products.Where(p => p.Deleted == false && p.Id == productId).FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<DBContext.Product>> GetProducts()
        {
            var products = await _dBContext.Products.Include(p=>p.ProductImages.Where(i=>i.Deleted==false)).Where(p => p.Deleted == false ).ToListAsync();
            return products;
        }

        public async Task<List<ProductType>> GetProductTypes()
        {
            var productTypes = await _dBContext.ProductTypes.Where(p => p.Deleted == false).ToListAsync();
            return productTypes;
        }
    }
}
