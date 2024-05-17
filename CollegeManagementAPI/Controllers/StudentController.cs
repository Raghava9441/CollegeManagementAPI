using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services.Models;
using CollegeManagementAPI.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IValidator<Student> _studentValidator;
        public StudentController(IStudentService studentService
            ,IValidator<Student> studentValidator
            )
        {
            _studentService = studentService;
            _studentValidator = studentValidator;
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
            if (organizations == null)
                return BadRequest();
            return Ok(organizations);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            //var validationResults = _studentValidator.Validate(student);
            //if (!validationResults.IsValid)
            //{
            //    foreach (var error in validationResults.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

            //    }
            //    return BadRequest(ModelState);
            //}

            await _studentService.CreateAsync(student);
            return Ok("created successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Student student)
        {
            //var validationResult = _studentValidator.Validate(student);
            //if (!validationResult.IsValid)
            //{
            //    foreach (var error in validationResult.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //    return BadRequest(ModelState);
            //}
            var Organization = await _studentService.GetById(id);
            if (Organization == null)
                return NotFound();
            await _studentService.UpdateAsync(id, student);
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
