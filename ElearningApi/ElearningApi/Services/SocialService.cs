using AutoMapper;
using ElearningApi.Data;
using ElearningApi.DTOs.Informations;
using ElearningApi.DTOs.Socials;
using ElearningApi.Models;
using ElearningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElearningApi.Services
{
    public class SocialService : ISocialService
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public SocialService(AppDBContext context,
                             IWebHostEnvironment env,
                             IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }
        public async Task Create(SocialCreateDto request)
        {
            var mappedData = _mapper.Map<Social>(request);
            await _context.Socials.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existSocial = await _context.Socials.FirstOrDefaultAsync(m => m.Id == id);


            _context.Socials.Remove(existSocial);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, SocialEditDto request)
        {
            var existSocial = await _context.Socials.FirstOrDefaultAsync(m => m.Id == id);


            _mapper.Map(request, existSocial);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SocialDto>> GetAllAsync()
        {
            return _mapper.Map<List<SocialDto>>(await _context.Socials.AsNoTracking().ToListAsync());

        }

        public async Task<SocialDto> GetById(int id)
        {
            return _mapper.Map<SocialDto>(await _context.Socials.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
