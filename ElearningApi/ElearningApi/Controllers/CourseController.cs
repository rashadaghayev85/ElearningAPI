using ElearningApi.DTOs.Courses;
using ElearningApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElearningApi.Controllers
{
    
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CourseCreateDto request)
        {
            await _courseService.Create(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _courseService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _courseService.GetById(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] CourseEditDto request)
        {
            await _courseService.EditAsync(id, request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _courseService.DeleteAsync(id);
            return Ok();
        }
    }
}
