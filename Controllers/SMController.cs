using ITEC_API.DTO.RequestDTO;
using ITEC_API.IServices;
using ITEC_API.Models.CourseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMController : ControllerBase
    {
        private readonly ISMService _iSMService;
        public SMController(ISMService iSMService)
        {
            _iSMService = iSMService;
        }

        [HttpGet ("get-course-levels/{courseName}")]
        public async Task<IActionResult> getCourseLevels(string courseName)
        {
            var courseLevels = await _iSMService.getCourseLevels(courseName);
            return Ok(courseLevels);
        }

        [HttpPost ("add-study-material")]
        public async Task<IActionResult> addStudyMaterial(SMRequest smRequest)
        {
            await _iSMService.addStudyMaterial(smRequest);
            return Ok();
        }

        [HttpGet("get-all-study-materials")]
        public async Task<IActionResult> getStudyMaterials()
        {
           var allStudyMaterials = await _iSMService.getStudyMaterials();
            return Ok(allStudyMaterials);
        }

    }
}
