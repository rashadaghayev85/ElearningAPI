using AutoMapper;
using ElearningApi.DTOs.Abouts;
using ElearningApi.DTOs.Categories;
using ElearningApi.DTOs.Courses;
using ElearningApi.DTOs.Informations;
using ElearningApi.DTOs.Instructors;
using ElearningApi.DTOs.Sliders;
using ElearningApi.DTOs.Socials;
using ElearningApi.DTOs.Students;
using ElearningApi.Models;
using System.Diagnostics.Metrics;
using InstructorCreateDto = ElearningApi.DTOs.Instructors.InstructorCreateDto;

namespace ElearningApi.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            /*CreateMap<Country, CountryDto>();*/ /*eger Dto da ki propertilerle entity modelimizdedki propertiler eynidise bunu bele yaziriq yox ferlidirse asagidaki kimi yaziri*/
            //CreateMap<Country, CountryDto>()
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<SliderCreateDto, Slider>();
            CreateMap<SliderEditDto, Slider>().ForMember(dest => dest.Image, opt => opt.Condition(src => src.Image is not null)); ;
            CreateMap<Slider, SliderDto>();

            CreateMap<InstructorCreateDto, About>();
            CreateMap<AboutEditDto, About>().ForMember(dest => dest.Image, opt => opt.Condition(src => src.Image is not null)); ;
            CreateMap<About, AboutDto>();

            CreateMap<CategoryCreateDto, Category>().ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.CoursesName)); ;
            CreateMap<CategoryEditDto, Category>().ForMember(dest => dest.Image, opt => opt.Condition(src => src.Image is not null)); ;
            CreateMap<Category, CategoryDto>();


            CreateMap<CourseCreateDto, Course>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CategoryName)); ;
            CreateMap<CourseEditDto, Course>().ForMember(dest => dest.CoursesImages, opt => opt.Condition(src => src.Images is not null)); ;
            CreateMap<Course, CourseDto>();

            CreateMap<InformationCreatedDto, Information>().ForMember(dest => dest.InformationIcon, opt => opt.MapFrom(src => src.IconClassName)); ;
            CreateMap<InformationEditDto, Information>();
            CreateMap<Information, InformationDto>();

            CreateMap<SocialCreateDto, Social>();
            CreateMap<SocialEditDto, Social>();
            CreateMap<Social, SocialDto>();

            CreateMap<InstructorCreateDto, Instructor>();
            CreateMap<InstructorEditDto, Instructor>().ForMember(dest => dest.Image, opt => opt.Condition(src => src.Image is not null)); ;
            CreateMap<Instructor, InstructorDto>();


            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentEditDto, Student>().ForMember(dest => dest.Image, opt => opt.Condition(src => src.Image is not null)); ;
            CreateMap<Student, StudentDto>();



        }
    }
}
