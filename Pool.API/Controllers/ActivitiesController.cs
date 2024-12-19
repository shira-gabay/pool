using Microsoft.AspNetCore.Mvc;
using Pool.Core.Models;
using Pool.Service;
using System.Diagnostics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ActivitiesService _activitiesService;

        public ActivitiesController(ActivitiesService activitiesService)
        {
           _activitiesService = activitiesService;
        }


        // GET: api/<ActivitiesController>
        [HttpGet]
        public IEnumerable<Activities> Get()
        {
            return _activitiesService.GetAll();
        }

        // GET api/<ActivitiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ActivitiesController>
        [HttpPost]
        public ActionResult<Activities> Post([FromBody] Activities newActivity)
        {
            if (newActivity == null)
            {
                return BadRequest("הפעילות לא יכולה להיות null");
            }
            newActivity.Id = _activitiesService.GetAll().Max(i => i.Id) + 1;
            _activitiesService.GetAll().Add(newActivity);
            return CreatedAtAction(nameof(Get), new { id = newActivity.Id }, newActivity);

        }

        // PUT api/<ActivitiesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Activities updatedActivity)
        {
            if (updatedActivity == null || updatedActivity.Id != id)
            {
                return BadRequest("Invalid activity ");
            }

            Activities existingActivity = _activitiesService.GetAll().FirstOrDefault(a => a.Id == id);
            if (existingActivity == null)
            {
                return NotFound("Activity not found.");
            }

            // עדכון השדות של הפעילות הקיימת
            existingActivity.Name = updatedActivity.Name;
            existingActivity.Date = updatedActivity.Date;
            existingActivity.Instructor = updatedActivity.Instructor;
            existingActivity.Level = updatedActivity.Level;
            existingActivity.MaxParticipants = updatedActivity.MaxParticipants;

            return NoContent();

        }

        // DELETE api/<ActivitiesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Activities existingActivity = _activitiesService.GetAll().FirstOrDefault(a => a.Id == id);
            if (existingActivity == null)
            {
                return NotFound("Activities not found");
            }
            _activitiesService.GetAll().Remove(existingActivity);
            return NoContent();

        }
    }
}
