using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;

namespace ITEC_API.IServices
{
    public interface IPaymentService
    {
        Task<List<NotRegFeeStudentsResponse>> getNotRegFeeStudents();
        Task addRegFee(StudentIdRequest studentIdRequest);
        Task<PaymentStudentResponse> getEnrollmentsWithStudent(string id);
        Task sendPaymentRequest(SendPaymentRequest sendPayment);
        Task<List<PaymentHistoryResponse>> getPaymentHistory(string id);
        Task<List<PaymentStudentResponse>> getEnrollmentsWithNonPaidStudent();
    }
}
