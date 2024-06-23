using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Instructors
{
    public class InstructorEditDto
    {
        public string FullName { get; set; }
        [SwaggerSchema(ReadOnly = true)]

        public string? Image { get; set; }
        public IFormFile? UploadImages { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
    }
}
