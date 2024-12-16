using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Models.PaymentModels;
using ITEC_API.Models.StudentModels;

namespace ITEC_API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo _iPaymentRepo;

        public PaymentService(IPaymentRepo iPaymentRepo)
        {
            _iPaymentRepo = iPaymentRepo;
        }

        public async Task<List<NotRegFeeStudentsResponse>> getNotRegFeeStudents()
        {
            var studentList = new List<NotRegFeeStudentsResponse>();

            var students = await _iPaymentRepo.getNotRegFeeStudents();

            if(students != null)
            {
                foreach(var student in students)
                {
                    studentList.Add(new NotRegFeeStudentsResponse()
                    {
                        StudentId = student.StudentId,
                    });
                }
            }

            return studentList;
        }

        public async Task addRegFee(StudentIdRequest studentIdRequest)
        {
            var record = await _iPaymentRepo.getRegFeeRecord();

            if(record != null)
            {
                var studentRegFeeEnrollment = new StudentRegFeeEnrollment()
                {
                    StudentId = studentIdRequest.StudentId,
                    RegFeeId = record.Id,
                };

                await _iPaymentRepo.addRegFee(studentRegFeeEnrollment);
            }
        }

        public async Task<PaymentStudentResponse> getEnrollmentsWithStudent(string id)
        {
            var student = await _iPaymentRepo.getEnrollmentsWithStudent(id);

            if (student != null)
            {
                var studentResponse = new PaymentStudentResponse()
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    EnrolledCourses = new List<PaymentEnrollmentResponse>()
                };

                if (student.StudentCourseEnrollments != null)
                {
                    foreach (var enrollment in student.StudentCourseEnrollments)
                    {
                        var totalPaidAmount = await _iPaymentRepo.getStudentAllPayments(enrollment.EnrollmentId);

                        studentResponse.EnrolledCourses.Add(new PaymentEnrollmentResponse()
                        {
                            EnrollmentId = enrollment.EnrollmentId,
                            CourseId = enrollment.CourseId,
                            CourseName = $"{enrollment.CourseLevel.MainCourse.CourseName} - {enrollment.CourseLevel.LevelEnrollment.Level.LevelName}",
                            CourseFee = enrollment.CourseFee,
                            PayableAmount = enrollment.CourseFee - totalPaidAmount,
                        });
                    }
                }

                return studentResponse;
            }
            else
            {
                return null;
            }

        }

        public async Task sendPaymentRequest(SendPaymentRequest sendPayment)
        {
            var payment = new Payment()
            {
                EnrollmentId = sendPayment.EnrollmentId,
                PaidAmount = sendPayment.Amount,
                PaidDate = sendPayment.date
            };

            await _iPaymentRepo.sendPaymentRequest(payment);

        }

        public async Task<List<PaymentHistoryResponse>> getPaymentHistory(string id)
        {
            var paymentList = new List<PaymentHistoryResponse>();

            var paymentHistory = await _iPaymentRepo.getPaymentHistory(id);

            if(paymentHistory != null)
            {
                foreach(var singlePayment in paymentHistory) 
                {
                    paymentList.Add(new PaymentHistoryResponse()
                    {
                        CourseName = $"{singlePayment.studentCourseEnrollment.CourseLevel.MainCourse.CourseName} - {singlePayment.studentCourseEnrollment.CourseLevel.LevelEnrollment.Level.LevelName}",
                        Amount = singlePayment.PaidAmount,
                        Date = singlePayment.PaidDate
                    });

                }
                return paymentList;
            }
            else
            {
                return null;
            }

        }

        public async Task<List<PaymentStudentResponse>> getEnrollmentsWithNonPaidStudent()
        {
            var studentList = new List<PaymentStudentResponse>();

            var allStudents = await _iPaymentRepo.getEnrollmentsWithNonPaidStudent();
            if(allStudents != null)
            {
                foreach (var student in allStudents)
                {
                    if(student.StudentCourseEnrollments != null)
                    {
                        foreach(var enrollment in student.StudentCourseEnrollments)
                        {
                            var totalPaidAmount = await _iPaymentRepo.getStudentAllPayments(enrollment.EnrollmentId);

                            if (enrollment.Payments != null)
                            {
                                var lastRecord = enrollment.Payments.LastOrDefault();
                                var lastPaymentDate = lastRecord?.PaidDate;
                                var overDueDate = DateTime.Now.AddDays(-30);

                                if(lastPaymentDate < overDueDate)
                                {
                                    var singleStudent = new PaymentStudentResponse()
                                    {
                                        StudentId = student.StudentId,
                                        FirstName = student.FirstName,
                                        EnrolledCourses = new List<PaymentEnrollmentResponse>()
                                    };

                                    singleStudent.EnrolledCourses.Add(new PaymentEnrollmentResponse()
                                    {
                                        EnrollmentId = enrollment.EnrollmentId,
                                        CourseId = enrollment.CourseId,
                                        CourseName = $"{enrollment.CourseLevel.MainCourse.CourseName} - {enrollment.CourseLevel.LevelEnrollment.Level.LevelName}",
                                        CourseFee = enrollment.CourseFee,
                                        PayableAmount = enrollment.CourseFee - totalPaidAmount,
                                    });

                                    studentList.Add(singleStudent);
                                }
                            }
                        }
                    }
                }
            }

            return studentList;

        }
    }
}
