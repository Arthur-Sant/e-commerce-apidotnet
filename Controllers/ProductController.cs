using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apidotnetwiwthdapper.Http;
using apidotnetwiwthdapper.Entities;
using apidotnetwiwthdapper.Repositories.Interfaces;
using apidotnetwiwthdapper.Repositories;

namespace apidotnetwiwthdapper.Controllers {

    [Controller]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase {

        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository) {
            this.productRepository = productRepository;

        }

        
        [HttpGet]
        public async Task<ActionResult<Response<List<Product>>>> findAll() {
            var response = new Response<List<Product>>();

            response.Data = await productRepository.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Product>>> findProdcutById(int id) {

            var response = new Response<Product>();

            var product = await productRepository.GetById(id);

            response.Data = product;

            if(product == null) {
                response.Message = "Product not Found";

                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<Product>>> createProduct([FromBody] Product product) {
            var response = new Response<Product>();

            response.Data = await productRepository.SaveAsync(product);
            response.Message = "Product created succefull";

            return Created($"/api/[controller]/{product.Id}", response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<bool>>> Product(int id) {
            var response = new Response<Product>();

            var result = await productRepository.DeleteAsync(id);

            if(!result) {
                response.Message = "Product not found";
                return NotFound(response);
            }

            response.Message = "Product deleted succefull";

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Product>>> updateProduct(int id, [FromBody] Product product) {
            var response = new Response<Product>();
            
            var productExist = await productRepository.UpdateAsync(id, product);
            response.Data = productExist;

            if(productExist == null) {
                response.Message = "Product not found";
                return NotFound(response);
            }
                
            response.Message = "Product updated succefull";

            return Ok(response);
        }
    }
}
