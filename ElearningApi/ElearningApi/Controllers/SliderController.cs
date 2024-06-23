using ElearningApi.DTOs.Sliders;
using ElearningApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElearningApi.Controllers
{
   
    public class SliderController : BaseController
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
                _sliderService = sliderService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderCreateDto request)
        {
            await _sliderService.Create(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data=await _sliderService.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var data = await _sliderService.GetById(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id ,[FromForm]SliderEditDto request)
        {
            await _sliderService.EditAsync(id, request);    
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _sliderService.DeleteAsync(id);    
            return Ok();    
        }
    }
}
