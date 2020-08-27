using RestApiCRUDOperations.Interface;
using RestApiCRUDOperations.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDOperations.DataAccess
{
    public class ProductDataAccess : IProductDataAccess
    {
        private List<ProductItem> _product = new List<ProductItem>
        {
            new ProductItem { ProductId = 1, ProductName = "Cricket Bat", ProductPrice = 1000.99, IsProductAvailable = true},
            new ProductItem { ProductId = 2, ProductName = "Vicky Hard Tennis", ProductPrice = 70.00, IsProductAvailable = false}
        };

        public Task<ProductItem> GetProductById(int productId)
        {
            //Perform data base operation here
            var isProductAvailable = _product.Any(p => p.ProductId == productId);
            var resultProduct = isProductAvailable
                ? _product.Single(p => p.ProductId == productId)
                : null;

            return Task.Run(() => resultProduct);
        }

        public Task<bool> AddProduct(ProductItem product)
        {
            _product.Add(product);

            return Task.Run(() => true);
        }

        public Task<bool> UpdateProduct(ProductItem product)
        {
            var isProductAvailable = _product.Any(p => p.ProductId == product.ProductId);
            if (!isProductAvailable)
                return Task.Run(() => false);

            _product.Remove(_product.Single(p => p.ProductId == product.ProductId));
            _product.Add(product);

            return Task.Run(() => true);
        }

        public Task<bool> DeleteProductById(int productId)
        {
            var isProductAvailable = _product.Any(p => p.ProductId == productId);
            if (!isProductAvailable)
                return Task.Run(() => false);

            _product.Remove(_product.Single(p => p.ProductId == productId));
            return Task.Run(() => true);
        }
    }
}
