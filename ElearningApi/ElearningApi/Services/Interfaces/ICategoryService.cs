using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Categories;

namespace ElearningApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Create(CategoryCreateDto request);
        Task<List<CategoryDto>> GetAllAsync();
        Task EditAsync(int id, CategoryEditDto request);
        Task<CategoryDto> GetById(int id);
        Task DeleteAsync(int id);
    }
}
