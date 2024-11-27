

using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;

namespace ITEC_API.IServices
{
    public interface ICourseService
    {
        Task<List<CourseCategoryResponse>> getAllCategories();
        Task addMainCourse(MainCourseRequest mainCourseRequest);
        Task<List<MainCourseResponse>> getMainCourseNames();
        Task<List<LevelResponse>> getAllLevels();
        Task addCourseLevel(AddCourseLevelRequest addCourseLevelRequest);

        Task<List<AllMainCoursesResponse>> getAllCourses();
        Task<List<InstructorForCourseResponse>> getInstructorForCourse();
    }
}
