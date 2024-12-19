using Microsoft.AspNetCore.Mvc;
using Pool.Core.Models;
using Pool.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmersController : ControllerBase
    {
        private readonly SwimmersService _swimmersService;

        public SwimmersController(SwimmersService swimmersService)
        {
            _swimmersService = swimmersService;
        }
        // GET: api/<SwimmersController>
        [HttpGet]
        public IEnumerable<Swimmers> Get()
        {
            return _swimmersService.GetAll();
        }

        // GET api/<SwimmersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SwimmersController>
        [HttpPost]
        public ActionResult Post([FromBody] Swimmers newSwimmer)
        {
            if (newSwimmer == null)
                return BadRequest("שחיין לא יכול להיות null");
            newSwimmer.Id = _swimmersService.GetAll().Max(i => i.Id) + 1;
            _swimmersService.GetAll().Add(newSwimmer);
            return CreatedAtAction(nameof(Get), new { id = newSwimmer.Id }, newSwimmer);

        }

        // PUT api/<SwimmersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Swimmers updatedSwimmer)
        {
            if (updatedSwimmer == null || updatedSwimmer.Id != id)
            {
                return BadRequest("Invalid swimmer ");
            }


            Swimmers existingSwimmer = _swimmersService.GetAll().FirstOrDefault(s => s.Id == id);

            if (existingSwimmer == null)
            {
                return NotFound("Swimmer not found.");
            }


            existingSwimmer.Name = updatedSwimmer.Name;
            existingSwimmer.Age = updatedSwimmer.Age;
            existingSwimmer.Level = updatedSwimmer.Level;
            existingSwimmer.Email = updatedSwimmer.Email;
            existingSwimmer.Phone = updatedSwimmer.Phone;

            return NoContent();
        }

        // DELETE api/<SwimmersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Swimmers existingSwimmer = _swimmersService.GetAll().FirstOrDefault(s => s.Id == id);

            if (existingSwimmer == null)
            {
                return NotFound("Swimmer not found.");
            }


            _swimmersService.GetAll().Remove(existingSwimmer);

            return NoContent();
        }
    }
}
