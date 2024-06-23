using AutoMapper;
using ElearningApi.Data;
using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Informations;
using ElearningApi.Models;
using ElearningApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElearningApi.Services
{
    public class InformationService : IInformationService
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public InformationService(AppDBContext context,
                             IWebHostEnvironment env,
                             IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }
        public async Task Create(InformationCreatedDto request)
        {
            var mappedData = _mapper.Map<Information>(request);
            await _context.Informations.AddAsync(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existInformation = await _context.Informations.FirstOrDefaultAsync(m => m.Id == id);
            

            _context.Informations.Remove(existInformation);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, InformationEditDto request)
        {
            var existInformation = await _context.Informations.FirstOrDefaultAsync(m => m.Id == id);
           

            _mapper.Map(request, existInformation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<InformationDto>> GetAllAsync()
        {
            return _mapper.Map<List<InformationDto>>(await _context.Informations.Include(m=>m.InformationIcon).AsNoTracking().ToListAsync());
        }

        public async Task<InformationDto> GetById(int id)
        {
            return _mapper.Map<InformationDto>(await _context.Informations.Include(m => m.InformationIcon).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
