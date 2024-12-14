using ITEC_API.Database;
using ITEC_API.DTO.RequestDTO;
using ITEC_API.IRepositories;
using ITEC_API.Models.PaymentModels;
using ITEC_API.Models.StudentModels;
using Microsoft.EntityFrameworkCore;

namespace ITEC_API.Repositories
{
    public class PaymentRepo : IPaymentRepo
    {
        private readonly ITECDbContext _itecDbContext;

        public PaymentRepo(ITECDbContext itecDbContext)
        {
            _itecDbContext = itecDbContext;
        }

        public async Task<List<Student>> getNotRegFeeStudents()
        {
            var students = await _itecDbContext.Students.Where(s => s.StudentRegFeeEnrollment == null).ToListAsync();
            return students;
        }

        public async Task<RegistrationFee> getRegFeeRecord()
        {
            var record = await _itecDbContext.registrationFee.FirstOrDefaultAsync();
            return record;
        }

        public async Task addRegFee(StudentRegFeeEnrollment studentRegFeeEnrollment)
        {
            await _itecDbContext.StudentRegFeeEnrollments.AddAsync(studentRegFeeEnrollment);
            await _itecDbContext.SaveChangesAsync();
        }

        public async Task<Student> getEnrollmentsWithStudent(string id)
        {
            var student = await _itecDbContext.Students.Include(s => s.StudentCourseEnrollments)
                .ThenInclude(sce => sce.CourseLevel).ThenInclude(cl => cl.MainCourse)
                .Include(s => s.StudentCourseEnrollments).ThenInclude(sce => sce.CourseLevel).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .SingleOrDefaultAsync(s => s.StudentId == id);

            return student;
        }

        public async Task<decimal> getStudentAllPayments(int enrollmentId)
        {
            var totalPaidAmount = await _itecDbContext.payments.Where(r => r.EnrollmentId == enrollmentId).SumAsync(r => r.PaidAmount);
            return totalPaidAmount;
        }

        public async Task sendPaymentRequest(Payment payment)
        {
            await _itecDbContext.payments.AddAsync(payment);
            await _itecDbContext.SaveChangesAsync();
        }

        public async Task<List<Payment>> getPaymentHistory(string id)
        {
            var paymentHistory = await _itecDbContext.payments.Include(p => p.studentCourseEnrollment)
                .ThenInclude(sce => sce.CourseLevel).ThenInclude(cl => cl.MainCourse)
                .Include(p => p.studentCourseEnrollment).ThenInclude(sce => sce.CourseLevel).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .Where(p => p.studentCourseEnrollment.StudentId == id)
                .ToListAsync();

            return paymentHistory;
         
        }
    }
}
