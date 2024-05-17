using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IValidator<Organization> _organizationValidator;

        public OrganizationController(IOrganizationService organizationService, IValidator<Organization> organizationValidator)
        {
            _organizationService = organizationService;
            _organizationValidator = organizationValidator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var organizations = await _organizationService.GetAllAsyc();
            return Ok(organizations);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Organization))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Organization>> GetById(string id)
        {
            var organizations = await _organizationService.GetById(id);
            return Ok(organizations);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Organization org)
        {
            var validationResult = _organizationValidator.Validate(org);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            await _organizationService.CreateAsync(org);
            return Ok("created successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put( string id,  Organization org)
        {
            var validationResult = _organizationValidator.Validate(org);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            var existingOrganization = await _organizationService.GetById(id);
            if (existingOrganization == null)
                return NotFound();

            await _organizationService.UpdateAsync(id, org);
            return Ok("updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var organization = await _organizationService.GetById(id);
            if (organization == null)
                return NotFound();
            await _organizationService.DeleteAysnc(id);
            return Ok("deleted successfully");
        }
    }
}
