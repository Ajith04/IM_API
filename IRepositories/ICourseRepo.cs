
using ITEC_API.Models.CourseModels;

namespace ITEC_API.IRepositories
{
    public interface ICourseRepo
    {
        Task<List<Category>> getAllCategories();
        Task<Category> getSingleCategory(string categoryName);
        Task addMainCourse(MainCourse mainCourse);
        Task<List<MainCourse>> getMainCourseNames();
        Task<List<Level>> getAllLevels();

        Task<MainCourse> getSingleMainCourse(string courseName);
        Task<Level> getSingleLevel(string levelName);
        Task addCourseLevel(CourseLevel courseLevel);
        Task addLevelEnrollment(LevelEnrollment levelEnrollment);

        Task<List<MainCourse>> getAllCourses();
        Task<List<Instructor>> getInstructorForCourse(string levelId);
        Task<List<CourseName>> getAllCourseNames();
        Task<CourseLevel> getSingleCourseLevel(string id);
        Task<CourseLevel> findCourseLevelById(string levelId);
        Task updateSingleCourseLevel(CourseLevel courseLevel);
        Task assignInstructor(InstructorEnrollment instructorEnrollment);
        Task<List<InstructorEnrollment>> getAssignedInstructor(string courseId);
        Task deleteInstructorEnrollment(int enrollmentId);
        Task deleteCourseLevel(string levelId);
        Task<List<InstructorEnrollment>> getEnrollmentsByLevelId(string levelId);

    }
}
