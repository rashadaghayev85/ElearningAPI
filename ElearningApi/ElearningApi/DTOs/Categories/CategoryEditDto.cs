using ElearningApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Categories
{
    public class CategoryEditDto
    {
        public string Name { get; set; }
        public string? CourseName { get; set; }
        public ICollection<Course>? Courses { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile? UploadImages { get; set; }
    }
}
