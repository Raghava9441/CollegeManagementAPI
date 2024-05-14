using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService student)
        {
            _studentService = student;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var organizations = await _studentService.GetAllAsyc();
            return Ok(organizations);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var organizations = await _studentService.GetById(id);
            return Ok(organizations);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Student teacher)
        {
            await _studentService.CreateAsync(teacher);
            return Ok("created successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Student teacher)
        {
            var Organization = await _studentService.GetById(id);
            if (Organization == null)
                return NotFound();
            await _studentService.UpdateAsync(id, teacher);
            return Ok("updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var organization = await _studentService.GetById(id);
            if (organization == null)
                return NotFound();
            await _studentService.DeleteAysnc(id);
            return Ok("deleted successfully");
        }
    }
}
