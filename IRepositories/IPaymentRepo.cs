using ITEC_API.DTO.RequestDTO;
using ITEC_API.Models.PaymentModels;
using ITEC_API.Models.StudentModels;

namespace ITEC_API.IRepositories
{
    public interface IPaymentRepo
    {
        Task<List<Student>> getNotRegFeeStudents();
        Task<RegistrationFee> getRegFeeRecord();
        Task addRegFee(StudentRegFeeEnrollment studentRegFeeEnrollment);
        Task<Student> getEnrollmentsWithStudent(string id);
        Task<decimal> getStudentAllPayments(int enrollmentId);
        Task sendPaymentRequest(Payment payment);
        Task<List<Payment>> getPaymentHistory(string id);
    }
}
