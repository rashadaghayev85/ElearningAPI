using AutoMapper;
using ElearningApi.Data;
using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Sliders;
using ElearningApi.Models;
using ElearningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElearningApi.Services
{
    public class AboutService:IAboutService
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public AboutService(AppDBContext context,
                             IWebHostEnvironment env,
                             IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }
        public async Task Create(InstructorCreateDto request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImages.FileName;
            string path = Path.Combine(_env.WebRootPath, "images", fileName);
            using (FileStream stream = new(path, FileMode.Create))
            {
                await request.UploadImages.CopyToAsync(stream);
            }
            request.Image = fileName;
            var mappedData = _mapper.Map<About>(request);
            await _context.Abouts.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existAbout = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);
            string path = Path.Combine(_env.WebRootPath, "images", existAbout.Image);
            if (File.Exists(path))
                File.Delete(path);

            _context.Abouts.Remove(existAbout);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, AboutEditDto request)
        {
            var existAbout = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);
            if (request.UploadImages is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images", existAbout.Image);
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

            _mapper.Map(request, existAbout);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AboutDto>> GetAllAsync()
        {

            return _mapper.Map<List<AboutDto>>(await _context.Abouts.AsNoTracking().ToListAsync());
        }

        public async Task<AboutDto> GetById(int id)
        {
            return _mapper.Map<AboutDto>(await _context.Abouts.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
