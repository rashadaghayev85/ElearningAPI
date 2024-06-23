using ElearningApi.Models;

namespace ElearningApi.DTOs.Courses
{
    public class CourseEditDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public int Duration { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CourseImage> CoursesImages { get; set; }
        public List<string>? Images { get; set; }
        public List<IFormFile>? UploadImages { get; set; }

        public List<CourseStudent> CourseStudents { get; set; }
    }
}
