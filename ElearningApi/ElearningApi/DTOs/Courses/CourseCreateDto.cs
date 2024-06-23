using ElearningApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Courses
{
    public class CourseCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string InstructorName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public Instructor ? Instructor { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public int ? InstructorId { get; set; }
        public int Duration { get; set; }
        public string CategoryName { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public int? CategoryId { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public Category? Category { get; set; }
        public List<CourseImage> CoursesImages { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public List<string>? Images {  get; set; }
        public List<IFormFile>UploadImages { get; set; }
        [SwaggerSchema(ReadOnly = true)]

        public List<CourseStudent>? CourseStudents { get; set; }
    }
}
