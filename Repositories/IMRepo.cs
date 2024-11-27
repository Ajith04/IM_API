using ITEC_API.Database;
using ITEC_API.IRepositories;
using ITEC_API.Models.CourseModels;
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

    }
}
