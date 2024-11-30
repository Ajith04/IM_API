using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IServices;
using ITEC_API.Models.CourseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _icourseservice;
        public CourseController(ICourseService icourseservice)
        {
            _icourseservice = icourseservice;
        }

        [HttpGet ("get-all-categories")]
        public async Task<IActionResult> getAllCategories()
        {
            var allCategories = await _icourseservice.getAllCategories();
            return Ok(allCategories);
        }

        [HttpPost("add-main-course")]
        public async Task<IActionResult> addMainCourse(MainCourseRequest mainCourseRequest)
        {
            await _icourseservice.addMainCourse(mainCourseRequest);
            return Ok();
        }

        [HttpGet ("get-main-course-names")]
        public async Task<IActionResult> getMainCourseNames()
        {
            var allCourseNames = await _icourseservice.getMainCourseNames();
            return Ok(allCourseNames);
        }

        [HttpGet ("get-all-levels")]
        public async Task<IActionResult> getAllLevels()
        {
            var allLevels = await _icourseservice.getAllLevels();
            return Ok(allLevels);
        }

        [HttpPost ("add-course-level")]
        public async Task<IActionResult> addCourseLevel(AddCourseLevelRequest addCourseLevelRequest)
        {
            await _icourseservice.addCourseLevel(addCourseLevelRequest);
            return Ok();
        }

        [HttpGet("get-all-courses")]
        public async Task<IActionResult> getAllCourses()
        {
            var allCourses = await _icourseservice.getAllCourses();
            return Ok(allCourses);
        }

        [HttpGet ("get-instructor-for-course")]
        public async Task<IActionResult> getInstructorForCourse()
        {
            var allInstructors = await _icourseservice.getInstructorForCourse();
            return Ok(allInstructors);
        }

        [HttpGet ("get-all-course-names")]
        public async Task<IActionResult> getAllCourseNames()
        {
            var allCourseNames = await _icourseservice.getAllCourseNames();
            return Ok(allCourseNames);
        }

        [HttpGet ("get-single-course-level/{id}")]
        public async Task<IActionResult> getSingleCourseLevel(string id)
        {
            var singleLevel = await _icourseservice.getSingleCourseLevel(id);
            return Ok(singleLevel);
        }

        [HttpPatch ("update-single-course/{levelId}")]
        public async Task<IActionResult> updateSingleCourse(string levelId, UpdateSingleCourseRequest updateSingleCourseRequest)
        {
            await _icourseservice.updateSingleCourseLevel(levelId, updateSingleCourseRequest);
            return Ok();
        }

        [HttpPost ("assign-instructor")]
        public async Task<IActionResult> assignInstructor(AssignInstructorRequest assignInstructorRequest)
        {
            await _icourseservice.assignInstructor(assignInstructorRequest);
            return Ok();
        }

        [HttpGet ("get-assigned-instructors/{courseId}")]
        public async Task<IActionResult> getAssignedInstructor(string courseId)
        {
            var instructors = await _icourseservice.getAssignedInstructor(courseId);
            return Ok(instructors);
        }
    }
}
