using AutoMapper;
using SchoolManagementApi.Models;
using SchoolManagementApi.DTOs;

namespace SchoolManagementApi.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>().ReverseMap();
        }
    }
} 