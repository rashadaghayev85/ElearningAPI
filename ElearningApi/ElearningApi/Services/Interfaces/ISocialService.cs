using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Socials;

namespace ElearningApi.Services.Interfaces
{
    public interface ISocialService
    {
        Task Create(SocialCreateDto request);
        Task<List<SocialDto>> GetAllAsync();
        Task EditAsync(int id, SocialEditDto request);
        Task<SocialDto> GetById(int id);
        Task DeleteAsync(int id);
    }
}
