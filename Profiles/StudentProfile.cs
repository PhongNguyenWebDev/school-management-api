using AutoMapper;
using SchoolManagementApi.Models;
using SchoolManagementApi.DTOs;

namespace SchoolManagementApi.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
} 