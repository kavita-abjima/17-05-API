using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using StudentsDetails.DbContexts;
using StudentsDetails.Dto;

namespace StudentsDetails;
public class StudentRepository : IStudentRepository
{
    private readonly studentContext _Context;

    public StudentRepository(studentContext Context)
    {
        _Context = Context;
    }


    public async Task<List<Student>> GetStudent()
    {
        return await _Context.StudentsDetails.ToListAsync();
    }
    public Task<Student> AddStudentAsync(Student student)
    {
        throw new NotImplementedException();
    }

    public Task<Student> DeleteStudentAsync(int id)
    {
        throw new NotImplementedException();
    }

    

    public Task<Student> GetStudentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Student> UpdateStudentAsync(int id, Student student)
    {
        throw new NotImplementedException();
    }
}