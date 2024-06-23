using ElearningApi.DTOs.Categories;
using ElearningApi.DTOs.Informations;

namespace ElearningApi.Services.Interfaces
{
    public interface IInformationService
    {
        Task Create(InformationCreatedDto request);
        Task<List<InformationDto>> GetAllAsync();
        Task EditAsync(int id, InformationEditDto request);
        Task<InformationDto> GetById(int id);
        Task DeleteAsync(int id);
    }
}
