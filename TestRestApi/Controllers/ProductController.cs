using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUDOperations.Interface;
using RestApiCRUDOperations.Models;
using System;
using System.Threading.Tasks;

namespace RestApiCRUDOperations.Controllers
{
    [Route("api/Product")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetRouteById")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            try
            {
                var product = await _productService.GetProductById(productId);
                if (product != null)
                    return Ok(product);
            }
            catch (Exception e)
            {
                //Handle and log exception for tracing
                //return 
            }

            return NotFound($"Product with id {productId} was not found");
        }

        [HttpPost]
        [Route("AddNewProduct")]
        public async Task<IActionResult> AddProduct([FromBody]ProductItem product)
        {
            try
            {
                var added = await _productService.AddProduct(product);
                if (added)
                    return CreatedAtAction(nameof(AddProduct), new { id = product.ProductId }, product);
            }
            catch (Exception e)
            {
                //Handle and log exception for tracing
                //return 
            }

            return BadRequest($"Failed to add the product - {product.ProductName}");
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]ProductItem product)
        {
            try
            {
                var updated = await _productService.UpdateProduct(product);
                if (updated)
                    return Ok($"Updated Product with id {product.ProductId}");
            }
            catch (Exception e)
            {
                //Handle and log exception for tracing
                //return 
            }

            return BadRequest($"Failed to update Product with id {product.ProductId}");
        }

        [HttpDelete]
        [Route("DeleteProductById")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var isDeleted = await _productService.DeleteProductById(productId);
                if (isDeleted)
                    return Ok($"Deleted Product with id {productId}");
            }
            catch (Exception e)
            {
                //Handle and log exception for tracing
                //return 
            }

            return NotFound($"Failed to delete Product with id {productId}");
        }
    }
}