using AutoMapper;
using ElearningApi.Data;
using ElearningApi.DTOs.Categories;
using ElearningApi.DTOs.Courses;
using ElearningApi.Models;
using ElearningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElearningApi.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public CourseService(AppDBContext context,
                             IWebHostEnvironment env,
                             IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }
        public async Task Create(CourseCreateDto request)
        {
            foreach (var item in request.UploadImages)
            {
            string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;
            string path = Path.Combine(_env.WebRootPath, "images", fileName);
                using (FileStream stream = new(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
               
            }
            List<CourseImage> images = new();
            foreach (var img in request.CoursesImages)
            {
                images.Add(img);
            }
            request.CoursesImages = images;



            var mappedData = _mapper.Map<Course>(request);
            await _context.Courses.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existCourse = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
            foreach (var item in existCourse.CoursesImages)
            {
            string path = Path.Combine(_env.WebRootPath, "images", item.Name);
            if (File.Exists(path))
                File.Delete(path);

            }

            _context.Courses.Remove(existCourse);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, CourseEditDto request)
        {
            var existCourse = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
            foreach (var item in request.UploadImages)
            {
            if (request.UploadImages is not null)
            {
                    foreach (var image in existCourse.CoursesImages)
                    {
                string oldPath = Path.Combine(_env.WebRootPath, "images", image.Name);

                if (File.Exists(oldPath))
                    File.Delete(oldPath);
                    }


                string fileName = Guid.NewGuid().ToString() + "-" + item;

                string newPath = Path.Combine(_env.WebRootPath, "images", fileName);

                using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                    List<CourseImage> images = new();
                    foreach (var img in request.CoursesImages)
                    {
                        images.Add(img); 
                    }
                request.CoursesImages = images;
            }

            }

            _mapper.Map(request, existCourse);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            return _mapper.Map<List<CourseDto>>(await _context.Courses.Include(m=>m.CourseStudents)
                                                                      .Include(m=>m.CoursesImages)
                                                                      .AsNoTracking().ToListAsync());
        }

        public async Task<CourseDto> GetById(int id)
        {
            return _mapper.Map<CourseDto>(await _context.Courses.Include(m => m.CourseStudents)
                                                                .Include(m => m.CoursesImages)
                                                                .AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
