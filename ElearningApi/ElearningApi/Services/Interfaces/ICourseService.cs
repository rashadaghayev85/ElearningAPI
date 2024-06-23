using ElearningApi.DTOs.Categories;
using ElearningApi.DTOs.Courses;

namespace ElearningApi.Services.Interfaces
{
    public interface ICourseService
    {
        Task Create(CourseCreateDto request);
        Task<List<CourseDto>> GetAllAsync();
        Task EditAsync(int id, CourseEditDto request);
        Task<CourseDto> GetById(int id);
        Task DeleteAsync(int id);
    }
}
