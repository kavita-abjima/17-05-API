using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsDetails.DbContexts;
using StudentsDetails.Dto;
using StudentsDetails.Models;

namespace StudentsDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsDetailsController : ControllerBase
    {
        private readonly studentContext _context;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentsDetailsController(studentContext context, IMapper mapper, IStudentRepository studentRepository)
        {
            _context = context;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        // GET: api/StudentsDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsDetails()
        {
          if (_context.StudentsDetails == null)
          {
              return NotFound();
          }
            var studentdto = await _studentRepository.GetStudentAsync();
            //var students= _context.StudentsDetails.ToListAsync();
            var studentdto1 = _mapper.Map<Student>(studentdto);

            return Ok(studentdto1);
        }

        // GET: api/StudentsDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsDetailDto>> GetStudentsDetail(int id)
        {
          if (_context.StudentsDetails == null)
          {
              return NotFound();
          }
            var studentsDetail = await _context.StudentsDetails.FindAsync(id);

            if (studentsDetail == null)
            {
                return NotFound();
            }

            return studentsDetail;
        }

        // PUT: api/StudentsDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsDetail(int id, StudentsDetailDto studentsDetail)
        {
            if (id != studentsDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentsDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentsDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsDetailDto>> PostStudentsDetail(Student students)
        {
          if (_context.StudentsDetails == null)
          {
              return Problem("Entity set 'studentContext.StudentsDetails'  is null.");
          }
          var studentdto = _mapper.Map<StudentsDetailDto>(students);
           _context.StudentsDetails.Add(studentdto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsDetail", new { id = students.Id }, students);
        }

        // DELETE: api/StudentsDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsDetail(int id)
        {
            if (_context.StudentsDetails == null)
            {
                return NotFound();
            }
            var studentsDetail = await _context.StudentsDetails.FindAsync(id);
            if (studentsDetail == null)
            {
                return NotFound();
            }

            _context.StudentsDetails.Remove(studentsDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsDetailExists(int id)
        {
            return (_context.StudentsDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
