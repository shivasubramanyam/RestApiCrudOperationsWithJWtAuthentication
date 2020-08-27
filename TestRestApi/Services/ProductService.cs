using System.Threading.Tasks;
using RestApiCRUDOperations.Interface;
using RestApiCRUDOperations.Models;
using TestRestApi.Models;

namespace RestApiCRUDOperations.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataAccess _productDataAccess;

        public ProductService(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }

        public Task<ProductItem> GetProductById(int productId)
        {
            // Perform business logic here
            return _productDataAccess.GetProductById(productId);
        }

        public Task<bool> AddProduct(ProductItem product)
        {
            // Perform business logic here
            return _productDataAccess.AddProduct(product);
        }

        public Task<bool> UpdateProduct(ProductItem product)
        {
            // Perform business logic here
            return _productDataAccess.UpdateProduct(product);
        }

        public Task<bool> DeleteProductById(int productId)
        {
            // Perform business logic here
            return _productDataAccess.DeleteProductById(productId);
        }
    }
}
