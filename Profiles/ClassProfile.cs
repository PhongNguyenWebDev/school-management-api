using AutoMapper;
using SchoolManagementApi.Models;
using SchoolManagementApi.DTOs;

namespace SchoolManagementApi.Profiles
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassDto>().ReverseMap();
        }
    }
} 