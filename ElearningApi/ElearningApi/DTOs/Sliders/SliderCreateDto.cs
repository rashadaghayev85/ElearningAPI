using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Sliders
{
    public class SliderCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public string? Image { get; set; }
        public IFormFile UploadImages { get; set; }
    }

    public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
    {
        public SliderCreateDtoValidator()
        {
            RuleFor(x=>x.Title).NotNull().NotEmpty().WithMessage("Title is required");
            RuleFor(x=>x.Description).NotNull().NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.UploadImages).NotNull().WithMessage("Upload image is required");
        }
    }
}
