using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;

namespace ITEC_API.IServices
{
    public interface IIMService
    {
        Task addInstructor(InstructorRequest instructorRequest);
        Task<List<AllInstructorResponse>> getAllInstructors();
        Task addCourseName(CourseNameRequest courseNameRequest);
        Task addNewCategory(CategoryNameRequest categoryNameRequest);
        Task<List<CategoryNameRequest>> getAllCategories();
        Task addNewLevel(LevelNameRequest levelNameRequest);
        Task<List<LevelNameRequest>> getAllLevels();
        Task addNewBatch(BatchNameRequest batchNameRequest);
        Task<List<BatchNameRequest>> getAllBatches();

        Task addExpense(ExpenseRequest expenseRequest);
        Task<List<ExpenseResponse>> getAllExpenses();
    }
}
