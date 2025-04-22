using AutoMapper;
using SchoolManagementApi.Models;
using SchoolManagementApi.DTOs;

namespace SchoolManagementApi.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
} 