using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;
        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var organizations = await _parentService.GetAllAsyc();
            return Ok(organizations);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Parent))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var organizations = await _parentService.GetById(id);
            return Ok(organizations);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Parent parent)
        {
            await _parentService.CreateAsync(parent);
            return Ok("created successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Parent parent)
        {
            var Organization = await _parentService.GetById(id);
            if (Organization == null)
                return NotFound();
            await _parentService.UpdateAsync(id, parent);
            return Ok("updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var organization = await _parentService.GetById(id);
            if (organization == null)
                return NotFound();
            await _parentService.DeleteAysnc(id);
            return Ok("deleted successfully");
        }
    }
}
