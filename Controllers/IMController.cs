using ITEC_API.DTO.RequestDTO;
using ITEC_API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IMController : ControllerBase
    {
        private readonly IIMService _iimservice;

        public IMController(IIMService iimservice)
        {
            _iimservice = iimservice;
        }

        [HttpPost ("add-instructor")]
        public async Task<IActionResult> addInstructor(InstructorRequest instructorRequest)
        {
            await _iimservice.addInstructor(instructorRequest);
            return Ok();
        }

        [HttpGet ("get-all-instructors")]
        public async Task<IActionResult> getAllinstructors()
        {
            var allInstructors = await _iimservice.getAllInstructors();
            return Ok(allInstructors);
        }

        [HttpPost ("add-course-name")]
        public async Task<IActionResult> addCourseName(CourseNameRequest courseNameRequest)
        {
            await _iimservice.addCourseName(courseNameRequest);
            return Ok();
        }
    }
}
