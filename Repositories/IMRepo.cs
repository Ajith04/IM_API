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
            var allInstructors = await _itecdbcontext.Instructors
                .Include(i => i.InstructorKnowCourses).ThenInclude(ik => ik.CourseName)
                .Include(i => i.InstructorEnrollments).ThenInclude(ie => ie.CourseLevel).ThenInclude(cl => cl.MainCourse)
                .Include(i => i.InstructorEnrollments).ThenInclude(ie => ie.CourseLevel).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .ToListAsync();
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

        public async Task<RegistrationFee> getRegFee()
        {
            var regFeeRecord = await _itecdbcontext.registrationFee.SingleOrDefaultAsync(r => r.Id == 1);
            return regFeeRecord;
           
        }

        public async Task changeRegFee(RegistrationFee registrationFee)
        {
            _itecdbcontext.registrationFee.Update(registrationFee);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task removeInstructor(int instructorId)
        {
            var singleInstructor = await _itecdbcontext.Instructors.SingleOrDefaultAsync(r => r.InstructorId == instructorId);
            if (singleInstructor != null)
            {
                _itecdbcontext.Instructors.Remove(singleInstructor);
                await _itecdbcontext.SaveChangesAsync();
            }
        }

        public async Task<Instructor> getSingleInstructor(int instructorId)
        {
            var singleInstructor = await _itecdbcontext.Instructors
                .Include(i => i.InstructorKnowCourses).ThenInclude(ik => ik.CourseName)
                .Include(i => i.InstructorEnrollments).ThenInclude(ie => ie.CourseLevel).ThenInclude(cl => cl.MainCourse)
                .Include(i => i.InstructorEnrollments).ThenInclude(ie => ie.CourseLevel).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .SingleOrDefaultAsync(i => i.InstructorId == instructorId);
            return singleInstructor;
        }

        public async Task<Instructor> findSingleInstructor(int instructorId)
        {
            var singleInstructor = await _itecdbcontext.Instructors.SingleOrDefaultAsync(r => r.InstructorId==instructorId);
            return singleInstructor;
        }

        public async Task updateInstructor(Instructor instructor)
        {
            _itecdbcontext.Instructors.Update(instructor);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task deleteInstructorKnowCourses(int instructorId)
        {
           var selectedEnrollments =  await _itecdbcontext.InstructorKnowCourses.Where(r => r.InstructorId == instructorId).ToListAsync();
            _itecdbcontext.InstructorKnowCourses.RemoveRange(selectedEnrollments);
            await _itecdbcontext.SaveChangesAsync();
        }
    }
}
