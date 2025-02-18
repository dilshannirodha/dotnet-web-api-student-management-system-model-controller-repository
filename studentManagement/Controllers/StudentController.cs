
using Microsoft.AspNetCore.Mvc;
using studentManagement.DTO;
using studentManagement.Models;
using StudentManagementSystem.Repositories;
namespace StudentManagementSystem.Controllers
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

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await _studentRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Create(StudentDTO studentDTO)
        {
            var student = new Student
            {
                Name = studentDTO.Name,
                Age = studentDTO.Age,
                Address = studentDTO.Address,
                Sex = studentDTO.Sex,
                Email = studentDTO.Email,
                Telephone = studentDTO.Telephone
            };

            await _studentRepository.AddAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDTO studentDTO)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            student.Name = studentDTO.Name;
            student.Age = studentDTO.Age;
            student.Address = studentDTO.Address;
            student.Sex = studentDTO.Sex;
            student.Email = studentDTO.Email;
            student.Telephone = studentDTO.Telephone;

            await _studentRepository.UpdateAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}