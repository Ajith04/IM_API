using ITEC_API.DTO.RequestDTO;
using ITEC_API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _iPaymentService;

        public PaymentController(IPaymentService iPaymentService)
        {
            _iPaymentService = iPaymentService;
        }

        [HttpGet ("get-not-regfee-students")]
        public async Task<IActionResult> getNotRegFeeStudents()
        {
            var students = await _iPaymentService.getNotRegFeeStudents();
            return Ok(students);
        }

        [HttpPost ("add-reg-fee")]
        public async Task<IActionResult> addRegFee(StudentIdRequest studentIdRequest)
        {
            await _iPaymentService.addRegFee(studentIdRequest);
            return Ok();
        }

        [HttpGet("get-enrollments-with-student/{id}")]
        public async Task<IActionResult> getEnrollmentsWithStudent(string id)
        {
            var student = await _iPaymentService.getEnrollmentsWithStudent(id);
            return Ok(student);
        }

        [HttpPost ("send-single-payment")]
        public async Task<IActionResult> sendSinglePayment(SendPaymentRequest sendPayment)
        {
            await _iPaymentService.sendPaymentRequest(sendPayment);
            return Ok();
        }

        [HttpGet ("get-payment-history/{id}")]
        public async Task<IActionResult> getPaymentHistory(string id)
        {
            var paymentHistory = await _iPaymentService.getPaymentHistory(id);
            return Ok(paymentHistory);
        }
    }
}
