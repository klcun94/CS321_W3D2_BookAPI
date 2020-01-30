using CS321_W3D2_BookAPI.Models;
using CS321_W3D2_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D2_BookAPI.Controllers
{
    [Route("api/[controller]")]
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: api/publishers
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_publisherService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = _publisherService.Get(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Publisher newPublisher)
        {
            try
            {
                _publisherService.Add(newPublisher);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddPublisher", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Publisher updatedPublisher)
        {
            var publisher = _publisherService.Update(updatedPublisher);
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _publisherService.Get(id);
            if (publisher == null) return NotFound();
            _publisherService.Remove(publisher);
            return NoContent();
        }
    }
}
