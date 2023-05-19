using Microsoft.AspNetCore.JsonPatch;
using StudentsDetails.Dto;
using StudentsDetails.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsDetails;
public interface IStudentRepository
{
    Task<List<StudentsDetailDto>> GetStudentAsync();

    Task<Student> GetStudentByIdAsync(int id);

    Task<Student> AddStudentAsync(Student student);

    Task<Student> DeleteStudentAsync(int id);

    Task<Student> UpdateStudentAsync(int id, Student student);

    //Task<Student> UpdateStudentPatchAsync(int id, JsonPatchDocument student);
}