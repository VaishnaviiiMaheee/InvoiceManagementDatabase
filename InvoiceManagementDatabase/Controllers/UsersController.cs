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
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userService.Get();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);
            if(user == null)
            {
                return NotFound($"User with Id={id} not found");
            }
            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            _userService.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id },user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User user)
        {
            var existingUser=_userService.Get(id);
            if(existingUser == null)
            {
                return NotFound($"User with Id={id} not found");
            }
            _userService.Update(id, user);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var user=_userService.Get(id);
            if (user == null)
            {
                return NotFound($"User with Id={id} not found");
            }
            _userService.Remove(user.Id);
            return Ok($"User with Id={id} deleted");
        }
    }
}
