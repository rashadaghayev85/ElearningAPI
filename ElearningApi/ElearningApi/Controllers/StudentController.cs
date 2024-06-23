using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Students;
using ElearningApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElearningApi.Controllers
{
   
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StudentCreateDto request)
        {
            await _studentService.Create(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _studentService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _studentService.GetById(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] StudentEditDto request)
        {
            await _studentService.EditAsync(id, request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _studentService.DeleteAsync(id);
            return Ok();
        }
    }
}
