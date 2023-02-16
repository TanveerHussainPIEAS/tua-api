using AutoMapper;
using TUAApi.DTO.Product;
using TUAApi.Repository.Product;

namespace TUAApi.Services.Product
{
    public class ProductService : IProductService
    {
        private IProductRespository _productRespository;
        private readonly IMapper _mapper;
        public ProductService(IProductRespository productRespository, IMapper mapper) { 
            _productRespository= productRespository;
            _mapper = mapper;
        }
        public async Task<ProductDto> GetProductById(int productId)
        {
            var product= await _productRespository.GetProductById(productId);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products= await _productRespository.GetProducts();
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        public async Task<List<ProductTypeDto>> GetProductTypes()
        {
            var productTypes= await _productRespository.GetProductTypes();
            var productTypesDto= _mapper.Map<List<ProductTypeDto>>(productTypes);
            return productTypesDto;
        }
    }
}
