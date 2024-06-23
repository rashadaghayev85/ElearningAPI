using ElearningApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Categories
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseName { get; set; }
        public ICollection<Course> Courses { get; set; }
        public string Image { get; set; }
        public IFormFile UploadImages { get; set; }
    }
}
