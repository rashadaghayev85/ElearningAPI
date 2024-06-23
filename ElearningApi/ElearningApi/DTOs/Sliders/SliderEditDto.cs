﻿using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Sliders
{
    public class SliderEditDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public string? Image { get; set; }
        public IFormFile? UploadImages { get; set; }
    }
}
