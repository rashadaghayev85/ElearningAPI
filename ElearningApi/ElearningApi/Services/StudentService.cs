using AutoMapper;
using ElearningApi.Data;
using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Students;
using ElearningApi.Models;
using ElearningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElearningApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public StudentService(AppDBContext context,
                             IWebHostEnvironment env,
                             IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }
        public async Task Create(StudentCreateDto request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImages.FileName;
            string path = Path.Combine(_env.WebRootPath, "images", fileName);
            using (FileStream stream = new(path, FileMode.Create))
            {
                await request.UploadImages.CopyToAsync(stream);
            }
            request.Image = fileName;
            var mappedData = _mapper.Map<Student>(request);
            await _context.Students.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existStudent = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            string path = Path.Combine(_env.WebRootPath, "images", existStudent.Image);
            if (File.Exists(path))
                File.Delete(path);

            _context.Students.Remove(existStudent);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, StudentEditDto request)
        {
            var existStudent = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (request.UploadImages is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images", existStudent.Image);
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

            _mapper.Map(request, existStudent);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            return _mapper.Map<List<StudentDto>>(await _context.Students.AsNoTracking().ToListAsync());
        }

        public async Task<StudentDto> GetById(int id)
        {
            return _mapper.Map<StudentDto>(await _context.Students.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
