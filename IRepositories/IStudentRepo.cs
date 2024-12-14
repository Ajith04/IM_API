using ITEC_API.Models.CourseModels;
using ITEC_API.Models.StudentModels;
using ITEC_API.Repositories;

namespace ITEC_API.IRepositories
{
    public interface IStudentRepo
    {
        Task addNewStudent(Student student);
        Task<CourseName> getCourseNameRecord(string courseName);
        Task addFollowup(FollowUp followup);
        Task<List<FollowUp>> getAllFollowUp();
        Task removeFollowup(int id);
        Task<FollowUp> getFollowUpById(int id);
        Task updateDescription(FollowUp followup);
        Task<List<Student>> getAllStudents();
        Task<Student> getSingleStudent(string id);
        Task updateSingleStudent(Student student);
        Task deleteStudent(Student student);
        Task<List<Batch>> getBatchesForStudent(string id);
        Task addStudentBatchEnrollment(StudentBatchEnrollment studentBatchEnrollment);
        Task<List<MainCourse>> getCoursesForStudent(string id);
        Task<bool> checkRegFee(string id);
        Task addStudentCourseEnrollment(StudentCourseEnrollment studentCourseEnrollment);
        Task deleteCourseEnrollment(int id);
        Task deleteBatchEnrollment(int id);
        Task<List<StudentCourseEnrollment>> getEnrollments();
    }
}
