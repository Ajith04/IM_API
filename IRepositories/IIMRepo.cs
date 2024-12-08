using ITEC_API.Models.CourseModels;
using ITEC_API.Models.PaymentModels;

namespace ITEC_API.IRepositories
{
    public interface IIMRepo
    {
        Task addInstructor(Instructor instructor);
        Task<List<Instructor>> getAllInstructors();
        Task addCourseName(CourseName courseName);
        Task<CourseName> getRecordByCourseName(string courseName);
        Task addNewCategory(Category category);
        Task<List<Category>> getAllCategories();
        Task addNewLevel(Level level);
        Task<List<Level>> getAllLevels();
        Task addNewBatch(Batch batch);
        Task<List<Batch>> getAllBatches();
        Task addExpense(Expense expense);
        Task<List<Expense>> getAllExpenses();
        Task<RegistrationFee> getRegFee();
        Task changeRegFee(RegistrationFee registrationFee);
        Task removeInstructor(int instructorId);
        Task<Instructor> getSingleInstructor(int instructorId);
        Task<Instructor> findSingleInstructor(int instructorId);
        Task updateInstructor(Instructor instructor);
        Task deleteInstructorKnowCourses(int instructorId);
    }
}
