using ITEC_API.Database;
using ITEC_API.IRepositories;
using ITEC_API.Models.CourseModels;
using ITEC_API.Models.StudyMaterialsModels;
using Microsoft.EntityFrameworkCore;

namespace ITEC_API.Repositories
{
    public class SMRepo : ISMRepo
    {

        private readonly ITECDbContext _itecDbContext;

        public SMRepo(ITECDbContext itecDbContext)
        {
            _itecDbContext = itecDbContext;
        }

        public async Task<MainCourse> getCourseLevels(string courseName)
        {
            var courseLevels = await _itecDbContext.MainCourses
                .Include(mc => mc.CourseLevels).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level).SingleOrDefaultAsync(mc => mc.CourseName == courseName);

            return courseLevels;
        }

        public async Task<Batch> getBatchId(string batchName)
        {
            var singleBatch = await _itecDbContext.Batches.SingleOrDefaultAsync(r => r.BatchName == batchName);
            return singleBatch;
        }

        public async Task addStudyMaterial(StudyMaterial studymaterial)
        {
            await _itecDbContext.StudyMaterials.AddAsync(studymaterial);
            await _itecDbContext.SaveChangesAsync();
        }

        public async Task<List<StudyMaterial>> getStudyMaterials()
        {
            var allStudyMaterials = await _itecDbContext.StudyMaterials
                .Include(sm => sm.CourseLevel).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .Include(sm => sm.Batch)
                .Include(sm => sm.CourseLevel).ThenInclude(cl => cl.MainCourse)
                .Include(sm => sm.Files).ToListAsync();

            return allStudyMaterials;
        }

    }
}
