﻿using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;

namespace ITEC_API.IServices
{
    public interface IStudentService
    {
        Task addNewStudent(StudentRequest studentRequest);
        Task addFollowup(FollowUpRequest followUpRequest);
        Task<List<FollowUpResponse>> getAllFollowup();
        Task removeFollowup(int id);
        Task updateDescription(int id, DescriptionRequest description);
        Task<List<StudentResponse>> getAllStudents();
        Task<SingleStudentResponse> getSingleStudent(string id);
        Task updateSingleStudent(string id, StudentUpdateRequest studentUpdateRequest);
        Task deleteStudent(string id);
        Task<List<BatchForStudentResponse>> getBatchesForStudent(string id);
        Task addStudentBatchEnrollment(StudentBatchRequest studentBatchRequest);
        Task<List<CourseForStudentResponse>> getCoursesForStudent(string id);
        Task<bool> checkRegFee(string id);
        Task addStudentCourseEnrollment(StudentEnrollmentRequest studentEnrollmentRequest);
        Task deleteCourseEnrollment(int id);
        Task deleteBatchEnrollment(int id);
        Task<List<EnrollmentResponse>> getEnrollments();
    }
}
