using Microsoft.AspNetCore.Mvc;
using Pool.Core.Models;
using Pool.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly InstructorsService _instructorsService;

        public InstructorsController(InstructorsService instructorsService)
        {
            _instructorsService = instructorsService;
        }
        // GET: api/<InstructorsController>
        [HttpGet]
        public IEnumerable<Instructors> Get()
        {
            return _instructorsService.GetAll();
        }

        // GET api/<InstructorsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InstructorsController>
        [HttpPost]
        public ActionResult<Instructors> Post([FromBody] Instructors newinstructor)
        {
            if (newinstructor == null)
                return BadRequest("עובד לא יכול להיות null");
            newinstructor.Id = _instructorsService.GetAll().Max(i => i.Id) + 1;
            _instructorsService.GetAll().Add(newinstructor);
            return CreatedAtAction(nameof(Get), new { id = newinstructor.Id }, newinstructor);
        }

        // PUT api/<InstructorsController>/5
        [HttpPut("{id}")]
        public IActionResult  Put(int id, [FromBody] Instructors updatedInstructor)
        {

            if (updatedInstructor == null || updatedInstructor.Id != id)
            {
                return BadRequest("Invalid instructor ");
            }
            Instructors existingInstructor = _instructorsService.GetAll().FirstOrDefault(i => i.Id == id);
            if (existingInstructor == null)
                return BadRequest("Instructor not found");
            existingInstructor.Name = updatedInstructor.Name;
            existingInstructor.Age = updatedInstructor.Age;
            existingInstructor.Experience = updatedInstructor.Experience;
            existingInstructor.Specialty = updatedInstructor.Specialty;
            existingInstructor.Phone = updatedInstructor.Phone;


            return NoContent();
        }

        // DELETE api/<InstructorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Instructors existingInstructor = _instructorsService.GetAll().FirstOrDefault(i => i.Id == id);

            if (existingInstructor == null)
            {
                return NotFound("Swimmer not found");
            }


            _instructorsService.GetAll().Remove(existingInstructor);

            return NoContent();
        }
    }
}
