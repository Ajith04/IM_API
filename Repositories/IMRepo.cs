using ITEC_API.Database;
using ITEC_API.IRepositories;
using ITEC_API.Models.CourseModels;
using ITEC_API.Models.PaymentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ITEC_API.Repositories
{
    public class IMRepo : IIMRepo
    {
        private readonly ITECDbContext _itecdbcontext;

        public IMRepo(ITECDbContext itecdbcontext)
        {
            _itecdbcontext = itecdbcontext;
        }

        public async Task addInstructor(Instructor instructor)
        {
            await _itecdbcontext.Instructors.AddAsync(instructor);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<Instructor>> getAllInstructors()
        {
            var allInstructors = await _itecdbcontext.Instructors.ToListAsync();
            return allInstructors;
        }

        public async Task addCourseName(CourseName courseName)
        {
            await _itecdbcontext.CourseNames.AddAsync(courseName);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<CourseName> getRecordByCourseName(string courseName)
        {
            var singleRecord = await _itecdbcontext.CourseNames.SingleOrDefaultAsync(r => r.Name == courseName);
            return singleRecord;
        }

        public async Task addNewCategory(Category category)
        {
            await _itecdbcontext.AddAsync(category);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<Category>> getAllCategories()
        {
            var categories = await _itecdbcontext.Categories.ToListAsync();
            return categories;
        }

        public async Task addNewLevel(Level level)
        {
            await _itecdbcontext.AddAsync(level);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<Level>> getAllLevels()
        {
            var levels = await _itecdbcontext.Levels.ToListAsync();
            return levels;
        }

        public async Task addNewBatch(Batch batch)
        {
            await _itecdbcontext.AddAsync(batch);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<Batch>> getAllBatches()
        {
            var batches = await _itecdbcontext.Batches.ToListAsync();
            return batches;
        }

        public async Task addExpense(Expense expense)
        {
            await _itecdbcontext.Expenses.AddAsync(expense);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<Expense>> getAllExpenses()
        {
            var allExpenses = await _itecdbcontext.Expenses
                .Include(e => e.ExpenseReceipts).ToListAsync();
            return allExpenses;
        }

    }
}
