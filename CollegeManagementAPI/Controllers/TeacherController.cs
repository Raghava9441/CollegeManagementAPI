﻿using CollegeManagementAPI.Models;
using CollegeManagementAPI.Services.Models;
using CollegeManagementAPI.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _TeacherService;
        private readonly IValidator<Teacher> _teacherValidator;
        public TeacherController(ITeacherService teacherService, IValidator<Teacher> teacherValidator)
        {
            _TeacherService = teacherService;
            _teacherValidator = teacherValidator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var organizations = await _TeacherService.GetAllAsyc();
            return Ok(organizations);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Teacher))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var organizations = await _TeacherService.GetById(id);
            return Ok(organizations);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Teacher teacher)
        {
            var validatitonResult = _teacherValidator.Validate(teacher);
            if (!validatitonResult.IsValid)
            {
                foreach (var error in validatitonResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }

            await _TeacherService.CreateAsync(teacher);
            return Ok("created successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Teacher teacher)
        {
            var validationResults = _teacherValidator.Validate(teacher);
            if (!validationResults.IsValid)
            {
                foreach (var error in validationResults.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            var Organization = await _TeacherService.GetById(id);
            if (Organization == null)
                return NotFound();
            await _TeacherService.UpdateAsync(id, teacher);
            return Ok("updated successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var organization = await _TeacherService.GetById(id);
            if (organization == null)
                return NotFound();
            await _TeacherService.DeleteAysnc(id);
            return Ok("deleted successfully");
        }
    }
}
