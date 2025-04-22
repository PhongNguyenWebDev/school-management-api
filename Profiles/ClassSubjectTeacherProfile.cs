using AutoMapper;
using SchoolManagementApi.Models;
using SchoolManagementApi.DTOs;

namespace SchoolManagementApi.Profiles
{
    public class ClassSubjectTeacherProfile : Profile
    {
        public ClassSubjectTeacherProfile()
        {
            CreateMap<ClassSubjectTeacher, ClassSubjectTeacherDto>().ReverseMap();
        }
    }
} 