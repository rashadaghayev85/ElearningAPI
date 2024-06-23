using AutoMapper;
using ElearningApi.Data;
using ElearningApi.DTOs.Sliders;
using ElearningApi.Models;
using ElearningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ElearningApi.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public SliderService(AppDBContext context,
                             IWebHostEnvironment env,
                             IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }
        public async Task Create(SliderCreateDto request)
        {
            string fileName=Guid.NewGuid().ToString()+"-"+request.UploadImages.FileName;
            string path = Path.Combine(_env.WebRootPath, "images", fileName);
            using (FileStream stream = new(path, FileMode.Create))
            {
                await request.UploadImages.CopyToAsync(stream);   
            }
            request.Image = fileName;
            var mappedData=_mapper.Map<Slider>(request);   
                await _context.Sliders.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existSlider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
            string path = Path.Combine(_env.WebRootPath, "images", existSlider.Image);
            if(File.Exists(path))
                File.Delete(path);

            _context.Sliders.Remove(existSlider);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id,SliderEditDto request)
        {
            var existSlider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
            if(request.UploadImages is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "images", existSlider.Image);
                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                string fileName=Guid.NewGuid().ToString()+"-"+request.UploadImages.FileName;

                string newPath = Path.Combine(_env.WebRootPath, "images", fileName);

                     using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await request.UploadImages.CopyToAsync(stream);
                }
                request.Image = fileName;
            }

            _mapper.Map(request,existSlider);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SliderDto>> GetAllAsync()
        {
         
         return _mapper.Map<List<SliderDto>>(await _context.Sliders.AsNoTracking().ToListAsync());
        }

        public async Task<SliderDto> GetById(int id)
        {
            return _mapper.Map<SliderDto>(await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m=>m.Id==id));
        }
    }
}
