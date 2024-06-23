using ElearningApi.DTOs.Sliders;
using ElearningApi.Models;

namespace ElearningApi.Services.Interfaces
{
    public interface ISliderService
    {
        Task Create(SliderCreateDto request);
        Task<List<SliderDto>>GetAllAsync();
        Task EditAsync (int id,SliderEditDto request);
        Task<SliderDto> GetById(int id);
        Task DeleteAsync(int id);
    }
}
