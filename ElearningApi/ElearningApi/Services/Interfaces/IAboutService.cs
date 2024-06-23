using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Sliders;

namespace ElearningApi.Services.Interfaces
{
    public interface IAboutService
    {
        Task Create(InstructorCreateDto request);
        Task<List<AboutDto>> GetAllAsync();
        Task EditAsync(int id, AboutEditDto request);
        Task<AboutDto> GetById(int id);
        Task DeleteAsync(int id);
    }
}
