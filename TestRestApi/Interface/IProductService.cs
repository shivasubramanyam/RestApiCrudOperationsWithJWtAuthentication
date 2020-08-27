using RestApiCRUDOperations.Models;
using System.Threading.Tasks;

namespace RestApiCRUDOperations.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// Gets product by id
        /// </summary>
        /// <param name="productId">The unique identifier for the product</param>
        /// <returns>product</returns>
        Task<ProductItem> GetProductById(int productId);

        /// <summary>
        /// Adds a given product to the product list
        /// </summary>
        /// <param name="product">The product that contains attributes to be added</param>
        /// <returns>True if succeeded else False</returns>
        Task<bool> AddProduct(ProductItem product);

        /// <summary>
        /// Updates a existing product from the product list
        /// </summary>
        /// <param name="product">The product that contains attributes to be updated</param>
        /// <returns>True if succeeded else False</returns>
        Task<bool> UpdateProduct(ProductItem product);

        /// <summary>
        /// Deletes existing product by id
        /// </summary>
        /// <param name="productId">The unique identifier for the product</param>
        /// <returns>True if succeeded else False</returns>
        Task<bool> DeleteProductById(int productId);
    }
}
