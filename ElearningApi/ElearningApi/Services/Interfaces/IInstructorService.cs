using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Instructors;

namespace ElearningApi.Services.Interfaces
{
    public interface IInstructorService 
    { 
    Task Create(DTOs.Instructors.InstructorCreateDto request);
    Task<List<InstructorDto>> GetAllAsync();
    Task EditAsync(int id, InstructorEditDto request);
    Task<InstructorDto> GetById(int id);
    Task DeleteAsync(int id);
}
}
