using ElearningApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Categories
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public List<string>? CoursesName { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public ICollection<Course>? Courses { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile UploadImages { get; set; }
    }
}
