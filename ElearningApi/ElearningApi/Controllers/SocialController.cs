using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Socials;
using ElearningApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElearningApi.Controllers
{
    
    public class SocialController : BaseController
    {
        private readonly ISocialService _socialService;
        public SocialController(ISocialService socialService)
        {
            _socialService = socialService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SocialCreateDto request)
        {
            await _socialService.Create(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _socialService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _socialService.GetById(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] SocialEditDto request)
        {
            await _socialService.EditAsync(id, request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _socialService.DeleteAsync(id);
            return Ok();
        }
    }
}
