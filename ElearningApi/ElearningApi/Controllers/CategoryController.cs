using ElearningApi.DTOs.Categories;
using ElearningApi.DTOs.Sliders;
using ElearningApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElearningApi.Controllers
{
    
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto request)
        {
            await _categoryService.Create(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _categoryService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _categoryService.GetById(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] CategoryEditDto request)
        {
            await _categoryService.EditAsync(id, request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
