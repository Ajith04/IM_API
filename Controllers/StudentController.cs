using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _iStudentService;
        public StudentController(IStudentService iStudentService)
        {
            _iStudentService = iStudentService;
        }

        [HttpPost ("add-new-student")]
        public async Task<IActionResult> addNewStudent(StudentRequest studentRequest)
        {
            await _iStudentService.addNewStudent(studentRequest);
            return Ok();
        }

        [HttpPost("add-followup")]
        public async Task<IActionResult> addFollowup(FollowUpRequest followUpRequest)
        {
            await _iStudentService.addFollowup(followUpRequest);
            return Ok();
        }

        [HttpGet ("get-all-followup")]
        public async Task<IActionResult> getAllFollowup()
        {
            var allFollowup = await _iStudentService.getAllFollowup();
            return Ok(allFollowup);
        }

        [HttpDelete("remove-followup/{id}")]
        public async Task<IActionResult> removeFollowup(int id)
        {
            await _iStudentService.removeFollowup(id);
            return Ok();
        }

        [HttpPatch ("update-description/{id}")]
        public async Task<IActionResult> updateDescription(int id, DescriptionRequest description)
        {
            await _iStudentService.updateDescription(id, description);
            return Ok();
        }

        [HttpGet ("get-all-students")]
        public async Task<IActionResult> getAllStudents()
        {
            var allStudents = await _iStudentService.getAllStudents();
            return Ok(allStudents);
        }

        [HttpGet ("get-single-student/{id}")]
        public async Task<IActionResult> getSingleStudent(string id)
        {
            var singleStudent = await _iStudentService.getSingleStudent(id);
            return Ok(singleStudent);
        }

        [HttpPatch ("update-single-student/{id}")]
        public async Task<IActionResult> updateSingleStudent(string id, StudentUpdateRequest studentUpdateRequest)
        {
            await _iStudentService.updateSingleStudent(id, studentUpdateRequest);
            return Ok();
        }

        [HttpDelete ("delete-student/{id}")]
        public async Task<IActionResult> deleteStudent(string id)
        {
            await _iStudentService.deleteStudent(id);
            return Ok();
        }

        [HttpGet ("get-batches-for-student/{id}")]
        public async Task<IActionResult> getBatchesForCourse(string id)
        {
            var batches = await _iStudentService.getBatchesForStudent(id);
            return Ok(batches);
        }

        [HttpPost ("add-student-batch-enrollment")]
        public async Task<IActionResult> addStudentBatchEnrollment(StudentBatchRequest studentBatchRequest)
        {
            await _iStudentService.addStudentBatchEnrollment (studentBatchRequest);
            return Ok();
        }

        [HttpGet ("get-courses-for-student/{id}")]
        public async Task<IActionResult> getCoursesForStudent(string id)
        {
            var allCourses = await _iStudentService.getCoursesForStudent(id);
            return Ok(allCourses);
        }

        [HttpGet ("check-reg-fee/{id}")]
        public async Task<IActionResult> checkRegFee(string id)
        {
            var status = await _iStudentService.checkRegFee(id);
            return Ok(status);
        }

        [HttpPost ("add-student-course-enrollment")]
        public async Task<IActionResult> addStudentCourseEnrollment(StudentEnrollmentRequest studentEnrollmentRequest)
        {
            await _iStudentService.addStudentCourseEnrollment (studentEnrollmentRequest);
            return Ok();
        }

        [HttpDelete ("delete-course-enrollment/{id}")]
        public async Task<IActionResult> deleteCourseEnrollment(int id)
        {
            await _iStudentService.deleteCourseEnrollment(id);
            return Ok();
        }

        [HttpDelete("delete-batch-enrollment/{id}")]
        public async Task<IActionResult> deleteBatchEnrollment(int id)
        {
            await _iStudentService.deleteBatchEnrollment(id);
            return Ok();
        }

    }
}
