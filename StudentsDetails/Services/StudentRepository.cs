using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using StudentsDetails.DbContexts;
using StudentsDetails.Dto;
using StudentsDetails.Models;

namespace StudentsDetails;



public class StudentRepository : IStudentRepository
{
    private readonly studentContext _Context;

    public StudentRepository(studentContext Context)
    {
       _Context = Context;
    }


    public async Task<List<StudentsDetailDto>> GetStudentAsync()
    {
        return  await _Context.StudentsDetails.ToListAsync();
        
    }

    public async Task<StudentsDetailDto> GetStudentByIdAsync(int id)
    {
        var student = await _Context.StudentsDetails.FindAsync(id);
        return student;
    }
    public async Task<StudentsDetailDto> AddStudentAsync(Student student)
    {
        _Context.StudentsDetails.Add(student);
        await _Context.SaveChangesAsync();

        return student;
    }
    public async Task<StudentsDetailDto> UpdateStudentAsync(int id, Student student)
    {
        var studentQuery = await GetStudentByIdAsync(id);
        if (studentQuery == null)
        {
            return studentQuery;
        }

        _Context.Entry(studentQuery).CurrentValues.SetValues(student);
        await _Context.SaveChangesAsync();

        return studentQuery;
    }

    public async Task<StudentsDetailDto> DeleteStudentAsync(int id)
    {
        var student = await GetStudentByIdAsync(id);
        if (student == null)
        {
            return student;
        }
        _Context.Student.Remove(student);
        await _Context.SaveChangesAsync();

        return student;

    }

    Task<Student> IStudentRepository.GetStudentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<Student> IStudentRepository.AddStudentAsync(Student student)
    {
        throw new NotImplementedException();
    }

    Task<Student> IStudentRepository.DeleteStudentAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<Student> IStudentRepository.UpdateStudentAsync(int id, Student student)
    {
        throw new NotImplementedException();
    }
}