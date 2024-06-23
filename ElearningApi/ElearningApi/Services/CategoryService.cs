using AutoMapper;
using ElearningApi.Data;
using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Categories;
using ElearningApi.Models;
using ElearningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElearningApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public CategoryService(AppDBContext context,
                             IWebHostEnvironment env,
                             IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }
        public async Task Create(CategoryCreateDto request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImages.FileName;
            string path = Path.Combine(_env.WebRootPath, "images", fileName);
            using (FileStream stream = new(path, FileMode.Create))
            {
                await request.UploadImages.CopyToAsync(stream);
            }
            request.Image = fileName;
            var mappedData = _mapper.Map<Category>(request);
            await _context.Categories.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existCategory = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            string path = Path.Combine(_env.WebRootPath, "images", existCategory.Image);
            if (File.Exists(path))
                File.Delete(path);

            _context.Categories.Remove(existCategory);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, CategoryEditDto request)
        {
            var existCategory = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (request.UploadImages is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images", existCategory.Image);
                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImages.FileName;

                string newPath = Path.Combine(_env.WebRootPath, "images", fileName);

                using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await request.UploadImages.CopyToAsync(stream);
                }
                request.Image = fileName;
            }

            _mapper.Map(request, existCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryDto>>(await _context.Categories.AsNoTracking().ToListAsync());
        }

        public async Task<CategoryDto> GetById(int id)
        {
            return _mapper.Map<CategoryDto>(await _context.Categories.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
