using CoffeeApplication.Interfaces;
using CoffeeApplication.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsSettingsController : ControllerBase
    {

        private readonly IPointsSettingsService _pointsSettingsService;
        public PointsSettingsController(IPointsSettingsService pointsSettingsService)
        {
            _pointsSettingsService = pointsSettingsService;
        }
        // GET: api/<PointsSettingsController>
        [HttpGet]
        public async Task<PointsSettings> Get()
        {
            return await _pointsSettingsService.Get();
        }
        
        // POST api/<PointsSettingsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PointsSettings pointsSettings)
        {
            await _pointsSettingsService.Create(pointsSettings);
            return CreatedAtAction(nameof(Get), new { id = pointsSettings.Id }, pointsSettings);
        }

        // PUT api/<PointsSettingsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] PointsSettings pointsSettings)
        {
            if (id != pointsSettings.Id)
            {
                return BadRequest();
            }
            await _pointsSettingsService.Update(id, pointsSettings);
            return NoContent();
        }

        // DELETE api/<PointsSettingsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _pointsSettingsService.Delete(id);
            return NoContent();
        }
        
    }
}
