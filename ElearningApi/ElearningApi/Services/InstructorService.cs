using AutoMapper;
using ElearningApi.Data;
using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Instructors;
using ElearningApi.Models;
using ElearningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElearningApi.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public InstructorService(AppDBContext context,
                             IWebHostEnvironment env,
                             IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }
        public async Task Create(DTOs.Instructors.InstructorCreateDto request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImages.FileName;
            string path = Path.Combine(_env.WebRootPath, "images", fileName);
            using (FileStream stream = new(path, FileMode.Create))
            {
                await request.UploadImages.CopyToAsync(stream);
            }
            request.Image = fileName;
            var mappedData = _mapper.Map<Instructor>(request);
            await _context.Instructors.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existInstructor = await _context.Instructors.FirstOrDefaultAsync(m => m.Id == id);
            string path = Path.Combine(_env.WebRootPath, "images", existInstructor.Image);
            if (File.Exists(path))
                File.Delete(path);

            _context.Instructors.Remove(existInstructor);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, InstructorEditDto request)
        {
            var existInstructor = await _context.Instructors.FirstOrDefaultAsync(m => m.Id == id);
            if (request.UploadImages is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images", existInstructor.Image);
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

            _mapper.Map(request, existInstructor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<InstructorDto>> GetAllAsync()
        {
            return _mapper.Map<List<InstructorDto>>(await _context.Instructors.AsNoTracking().ToListAsync());
        }

        public async Task<InstructorDto> GetById(int id)
        {
            return _mapper.Map<InstructorDto>(await _context.Instructors.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
