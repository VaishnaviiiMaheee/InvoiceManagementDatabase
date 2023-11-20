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
    public class InvoiceProductController : ControllerBase
    {
        private readonly IInvoiceProductService invoiceproductService;

        public InvoiceProductController(IInvoiceProductService invoiceproductService)
        {
            this.invoiceproductService = invoiceproductService;
        }
        // GET: api/<InvoiceProductController>
        [HttpGet]
        public ActionResult<List<InvoiceProduct>> Get()
        {
            return invoiceproductService.Get();
        }

        // GET api/<InvoiceProductController>/5
        [HttpGet("{id}")]
        public ActionResult<InvoiceProduct> Get(string id)
        {
            var invoiceproduct = invoiceproductService.Get(id);
            if (invoiceproduct == null)
            {
                return NotFound($"Product with Invoice Id={id} not found");
            }
            return invoiceproduct;
        }

        // POST api/<InvoiceProductController>
        [HttpPost]
        public ActionResult<InvoiceProduct> Post([FromBody] InvoiceProduct invoiceproduct)
        {
            invoiceproductService.Create(invoiceproduct);
            return CreatedAtAction(nameof(Get), new { id = invoiceproduct.Id }, invoiceproduct);
        }

        // PUT api/<InvoiceProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] InvoiceProduct invoiceproduct)
        {
            var existinginvoiceProduct = invoiceproductService.Get(id);
            if (existinginvoiceProduct == null)
            {
                return NotFound($"Product with Invoice Id={id} not found");
            }
            invoiceproductService.Update(id, invoiceproduct);
            return NoContent();
        }

        // DELETE api/<InvoiceProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            invoiceproductService.Remove(id);

            return Ok($"Product with Id={id} deleted");
        }
    }
}
