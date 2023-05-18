using AutoMapper;
using StudentsDetails.Dto;
using StudentsDetails.Models;

namespace StudentsDetails.StudentMappingProfile
{
    public class APIMapping:Profile
    {
        public APIMapping()
        {
            CreateMap<Student, StudentsDetailDto>();
            CreateMap<StudentsDetailDto, Student>();
        }
    }
}
