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
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;

        public InvoicesController(IInvoiceService invoiceService) {
            this.invoiceService = invoiceService;
        }
        // GET: api/<InvoicesController>
        [HttpGet]
        public ActionResult<List<Invoice>> Get()
        {
            return invoiceService.Get();
        }

        // GET api/<InvoicesController>/5
        [HttpGet("{id}")]
        public ActionResult<Invoice> Get(string id)
        {
            var invoice = invoiceService.Get(id);
            if (invoice == null)
            {
                return NotFound($"Invoice with Id={id} not found");
            }
            return invoice;
        }

        // POST api/<InvoicesController>
        [HttpPost]
        public ActionResult<Invoice> Post([FromBody] Invoice invoice)
        {
            invoiceService.Create(invoice);
            return CreatedAtAction(nameof(Get), new { id = invoice.Id },invoice);
        }

        // PUT api/<InvoicesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Invoice invoice)
        {
            var existingInvoice = invoiceService.Get(id);
            if (existingInvoice == null)
            {
                return NotFound($"Invoice with Id={id} not found");
            }
            invoiceService.Update(id, invoice);
            return NoContent();
        }

        // DELETE api/<InvoicesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
  
            invoiceService.Remove(id);
            return Ok($"Invoice with Id={id} deleted");
        }
    }
}
