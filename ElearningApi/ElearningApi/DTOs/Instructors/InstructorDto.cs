using ElearningApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ElearningApi.DTOs.Instructors
{
    public class InstructorDto
    {
        public string FullName { get; set; }
        public string Image { get; set; }
        public IFormFile UploadImages { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public List<InstructorSocial> InstructorSocials { get; set; }
    }
}
