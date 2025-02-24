// Controllers/StudentsController.cs
using Microsoft.AspNetCore.Mvc;
using studentManagement.DTOs;
using studentManagement.Models;
using studentManagement.Repositories;

namespace studentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDTO>>> GetStudents()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            var studentDtos = students.Select(s => new StudentResponseDTO
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Course = s.Course
            });
            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDTO>> GetStudent(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDto = new StudentResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Course = student.Course
            };
            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponseDTO>> AddStudent(StudentDTO studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Email = studentDto.Email,
                Course = studentDto.Course
            };
            await _studentRepository.AddStudentAsync(student);

            var responseDto = new StudentResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Course = student.Course
            };
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, responseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDTO studentDto)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            student.Course = studentDto.Course;

            await _studentRepository.UpdateStudentAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}