using ElearningApi.DTOs.Courses;
using ElearningApi.DTOs.Informations;
using ElearningApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElearningApi.Controllers
{
   
    public class InformationController : BaseController
    {
        private readonly IInformationService _informationService;
        public InformationController(IInformationService informationService)
        {
            _informationService = informationService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InformationCreatedDto request)
        {
            await _informationService.Create(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _informationService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _informationService.GetById(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] InformationEditDto request)
        {
            await _informationService.EditAsync(id, request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _informationService.DeleteAsync(id);
            return Ok();
        }
    }
}
