using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Students
{
    public class StudentEditDto
    {
        public string FullName { get; set; }
        public string? Biography { get; set; }
        public string Profession { get; set; }
        [SwaggerSchema(ReadOnly = true)]

        public string? Image { get; set; }
        public IFormFile UploadImages { get; set; }
    }
}
