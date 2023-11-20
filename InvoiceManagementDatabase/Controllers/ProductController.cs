using InvoiceManagementDatabase.Models;
using InvoiceManagementDatabase.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceManagementDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return _productService.Get();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(string id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound($"Product with Id={id} not found");
            }
            return product;
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Product product)
        {
            var existingProduct = _productService.Get(id);
            if (existingProduct == null)
            {
                return NotFound($"Product with Id={id} not found");
            }
            _productService.Update(id, product);
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound($"Product with Id={id} not found");
            }
            _productService.Remove(product.Id);
            return Ok($"Product with Id={id} deleted");
        }
    }
}
