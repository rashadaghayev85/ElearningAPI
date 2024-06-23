namespace ElearningApi.DTOs.Students
{
    public class StudentDto
    {
        public string FullName { get; set; }
        public string? Biography { get; set; }
        public string Profession { get; set; }
        public string Image { get; set; }

        public IFormFile UploadImages { get; set; }
    }
}
