using ITEC_API.Database;
using ITEC_API.IRepositories;
using ITEC_API.Models.CourseModels;
using Microsoft.EntityFrameworkCore;

namespace ITEC_API.Repositories
{
    public class CourseRepo : ICourseRepo
    {
        private readonly ITECDbContext _itecdbcontext;

        public CourseRepo(ITECDbContext itecdbcontext)
        {
            _itecdbcontext = itecdbcontext;
        }

        public async Task<List<Category>> getAllCategories()
        {
           return await _itecdbcontext.Categories.ToListAsync();
        }

        public async Task<Category> getSingleCategory(string categoryName)
        {
            return await _itecdbcontext.Categories.SingleOrDefaultAsync(c => c.CategoryName == categoryName);
            
        }

        public async Task addMainCourse(MainCourse mainCourse)
        {
            await _itecdbcontext.MainCourses.AddAsync(mainCourse);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<MainCourse>> getMainCourseNames()
        {
            var mainCourseNames = await _itecdbcontext.MainCourses.ToListAsync();
            return mainCourseNames;
        }

        public async Task<List<Level>> getAllLevels()
        {
            var allLevels = await _itecdbcontext.Levels.ToListAsync();
            return allLevels;
        }

        public async Task<MainCourse> getSingleMainCourse(string courseName)
        {
            return await _itecdbcontext.MainCourses.SingleOrDefaultAsync(r => r.CourseName ==  courseName);
        }

        public async Task<Level> getSingleLevel(string levelName)
        {
            return await _itecdbcontext.Levels.SingleOrDefaultAsync(r => r.LevelName == levelName);
        }

        public async Task addCourseLevel(CourseLevel courseLevel)
        {
            await _itecdbcontext.CourseLevels.AddAsync(courseLevel);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task addLevelEnrollment(LevelEnrollment levelEnrollment)
        {
            await _itecdbcontext.LevelEnrollments.AddAsync(levelEnrollment);
            await _itecdbcontext.SaveChangesAsync();
        }



        public async Task<List<MainCourse>> getAllCourses()
        {
            var allCourses = await _itecdbcontext.MainCourses
                .Include(mc => mc.CourseImages)
                .Include(mc => mc.CategoryEnrollments).ThenInclude(ce => ce.Category)
                .Include(mc => mc.CourseLevels).ThenInclude(cl => cl.InstructorEnrollments).ThenInclude(ie => ie.Instructor)
                .Include(mc => mc.CourseLevels).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level).ToListAsync();

            return allCourses;
        }

        public async Task<List<Instructor>> getInstructorForCourse()
        {
            var allInstructors = await _itecdbcontext.Instructors
                .Include(i => i.InstructorKnowCourses).ThenInclude(ik => ik.CourseName).ToListAsync();
            return allInstructors;
        }

        public async Task<List<CourseName>> getAllCourseNames()
        {
            var allCourseNames = await _itecdbcontext.CourseNames.ToListAsync();
            return allCourseNames;
        }

        public async Task<CourseLevel> getSingleCourseLevel(string id)
        {
            var singleLevel = await _itecdbcontext.CourseLevels.Include(cl => cl.MainCourse).ThenInclude(mc => mc.CourseImages)
                .Include(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .SingleOrDefaultAsync(cl => cl.CourseId == id);
            return singleLevel;
        }

        public async Task<CourseLevel> findCourseLevelById(string levelId)
        {
            var singleLevel = await _itecdbcontext.CourseLevels.SingleOrDefaultAsync(r => r.CourseId == levelId);
            return singleLevel;
        }

        public async Task updateSingleCourseLevel(CourseLevel courseLevel)
        {
            _itecdbcontext.CourseLevels.Update(courseLevel);
            _itecdbcontext.SaveChanges();
        }

        public async Task assignInstructor(InstructorEnrollment instructorEnrollment)
        {
            await _itecdbcontext.InstructorEnrollments.AddAsync(instructorEnrollment);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<InstructorEnrollment>> getAssignedInstructor(string courseId)
        {
            var instructors = await _itecdbcontext.InstructorEnrollments
                .Include(ie => ie.Instructor)
                .ThenInclude(i => i.InstructorKnowCourses)
                .ThenInclude(ik => ik.CourseName).Where(ie => ie.CourseId == courseId).ToListAsync();

            return instructors;
        }
    }
}
