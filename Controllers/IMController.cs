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

        [HttpPost ("add-category")]
        public async Task<IActionResult> addNewCategory(CategoryNameRequest categoryNameRequest)
        {
            await _iimservice.addNewCategory(categoryNameRequest);
            return Ok();
        }

        [HttpGet ("get-all-categories")]
        public async Task<IActionResult> getAllCategories()
        {
            var allCategories = await _iimservice.getAllCategories();
            return Ok(allCategories);
        }

        [HttpPost("add-level")]
        public async Task<IActionResult> addNewLevel(LevelNameRequest levelNameRequest)
        {
            await _iimservice.addNewLevel(levelNameRequest);
            return Ok();
        }

        [HttpGet("get-all-levels")]
        public async Task<IActionResult> getAllLevels()
        {
            var allLevels = await _iimservice.getAllLevels();
            return Ok(allLevels);
        }

        [HttpPost("add-batch")]
        public async Task<IActionResult> addNewBatch(BatchNameRequest batchNameRequest)
        {
            await _iimservice.addNewBatch(batchNameRequest);
            return Ok();
        }

        [HttpGet("get-all-batches")]
        public async Task<IActionResult> getAllBatches()
        {
            var allBatches = await _iimservice.getAllBatches();
            return Ok(allBatches);
        }

        [HttpPost ("add-expense")]
        public async Task<IActionResult> addExpense(ExpenseRequest expenseRequest)
        {
            await _iimservice.addExpense(expenseRequest);
            return Ok();
        }

        [HttpGet ("get-all-expenses")]
        public async Task<IActionResult> getAllExpenses()
        {
            var allExpenses = await _iimservice.getAllExpenses();
            return Ok(allExpenses);
        }

        [HttpGet ("get-reg-fee")]
        public async Task<IActionResult> getRegFee()
        {
            var regFee = await _iimservice.getRegFee();
            return Ok(regFee);
        }

        [HttpPatch ("change-reg-fee")]
        public async Task<IActionResult> changeRegFee(ChangeRegFee changeRegFee)
        {
            await _iimservice.changeRegFee(changeRegFee);
            return Ok();
        }

        [HttpDelete ("remove-instructor-by-id/{instructorId}")]
        public async Task<IActionResult> removeInstructor(int instructorId)
        {
            await _iimservice.removeInstructor(instructorId);
            return Ok();
        }

        [HttpGet ("get-single-instructor/{instructorId}")]
        public async Task<IActionResult> getSingleInstructor(int instructorId)
        {
            var singleInstructor = await _iimservice.getSingleInstructor(instructorId);
            return Ok(singleInstructor);
        }

        [HttpPatch ("update-instructor/{instructorId}")]
        public async Task<IActionResult> updateInstructor(int instructorId, UpdateInstructorRequest updateInstructorRequest)
        {
            await _iimservice.updateInstructor(instructorId, updateInstructorRequest);
            return Ok();
        }
    }
}
