using Newtonsoft.Json;

namespace RestApiCRUDOperations.Models
{
    /// <summary>
    /// Defines attributes of product
    /// </summary>
    public class ProductItem
    {
        /// <summary>
        /// Gets or sets the product id
        /// </summary>
        [JsonProperty(PropertyName = "productId")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        [JsonProperty(PropertyName = "productName")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product price
        /// </summary>
        [JsonProperty(PropertyName = "productPrice")] 
        public double ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the product availability status
        /// </summary>
        [JsonProperty(PropertyName = "isProductAvailable")] 
        public bool IsProductAvailable { get; set; }
    }
}
