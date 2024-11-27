using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    [Route("/")]
    [Route("/api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var data = "Hello! To access the student data, enter '/api/students' or '/api/students/1' after your localhost address in the browser.";

            return Ok(data);
        }
    }
}
