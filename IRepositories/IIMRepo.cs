using ITEC_API.Models.CourseModels;

namespace ITEC_API.IRepositories
{
    public interface IIMRepo
    {
        Task addInstructor(Instructor instructor);
        Task<List<Instructor>> getAllInstructors();
    }
}
