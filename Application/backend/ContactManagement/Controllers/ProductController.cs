using CoffeeApplication.Dto;
using CoffeeApplication.Interfaces;
using CoffeeApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>wwwweefffefefe
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await _productService.Get();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(string id)
        {
            return await _productService.Get(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            await _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _productService.Update(id, product);
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.Delete(id);
            return NoContent();
        }
        
        [HttpPost("Payment")]
        public async Task<User> Payment([FromBody] PaymentDto cart)
        {
           return await _productService.Payment(cart);
        }

    }
}
