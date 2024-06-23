using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Students;

namespace ElearningApi.Services.Interfaces
{
    public interface IStudentService
    {
        Task Create(StudentCreateDto request);
        Task<List<StudentDto>> GetAllAsync();
        Task EditAsync(int id, StudentEditDto request);
        Task<StudentDto> GetById(int id);
        Task DeleteAsync(int id);
    }
}
