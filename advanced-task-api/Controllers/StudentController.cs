using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;


namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentModel _studentModel;
        public StudentsController(IStudentModel studentModel)
        {
            _studentModel = studentModel;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentModel.FetchStudents();
            return Ok(students);

        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _studentModel.FetchStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}


