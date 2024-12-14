using ITEC_API.Database;
using ITEC_API.DTO.RequestDTO;
using ITEC_API.IRepositories;
using ITEC_API.Models.CourseModels;
using ITEC_API.Models.StudentModels;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace ITEC_API.Repositories
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ITECDbContext _itecdbcontext;
        public StudentRepo(ITECDbContext itecdbcontext)
        {
            _itecdbcontext = itecdbcontext;
        }

        public async Task addNewStudent(Student student)
        {
            await _itecdbcontext.Students.AddAsync(student);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<CourseName> getCourseNameRecord(string courseName)
        {
            var singleRecord = await _itecdbcontext.CourseNames.SingleOrDefaultAsync(r => r.Name == courseName);
            return singleRecord;
        }

        public async Task addFollowup(FollowUp followup)
        {
            await _itecdbcontext.FollowUps.AddAsync(followup);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<FollowUp>> getAllFollowUp()
        {
            var allFollowUp = await _itecdbcontext.FollowUps.Include(f => f.FollowUpEnrollments).ThenInclude(fe => fe.CourseName).ToListAsync();
            return allFollowUp;
        }

        public async Task removeFollowup(int id)
        {
            var singleRecord = await _itecdbcontext.FollowUps.SingleOrDefaultAsync(r => r.Id == id);
            _itecdbcontext.FollowUps.Remove(singleRecord);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<FollowUp> getFollowUpById(int id)
        {
            var singleRecord = await _itecdbcontext.FollowUps.SingleOrDefaultAsync(r => r.Id==id);
            return singleRecord;
        }

        public async Task updateDescription(FollowUp followup)
        {
            _itecdbcontext.FollowUps.Update(followup);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<Student>> getAllStudents()
        {
            var allStudents = await _itecdbcontext.Students
                .Include(s => s.StudentCourseEnrollments).ThenInclude(sce => sce.CourseLevel).ThenInclude(cl => cl.MainCourse)
                .Include(s => s.StudentCourseEnrollments).ThenInclude(sce => sce.CourseLevel).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .Include(s => s.StudentCourseEnrollments).ThenInclude(sce => sce.Instructor)
                .Include(s => s.StudentBatchEnrollment).ThenInclude(sbe => sbe.Batch)
                .ToListAsync();
            return allStudents;
        }

        public async Task<Student> getSingleStudent(string id)
        {
            var singleStudent = await _itecdbcontext.Students
                .Include(s => s.StudentCourseEnrollments).ThenInclude(sce => sce.CourseLevel).ThenInclude(cl => cl.MainCourse).ThenInclude(mc => mc.CourseImages)
                .Include(s => s.StudentCourseEnrollments).ThenInclude(sce => sce.CourseLevel).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .Include(s => s.StudentCourseEnrollments).ThenInclude(sce => sce.Instructor)
                .Include(s => s.StudentBatchEnrollment).ThenInclude(sbe => sbe.Batch)
                .SingleOrDefaultAsync(r => r.StudentId == id);
            return singleStudent;
        }

        
        public async Task updateSingleStudent(Student student)
        {
            _itecdbcontext.Students.Update(student);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task deleteStudent(Student student)
        {
            _itecdbcontext.Students.Remove(student);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<Batch>> getBatchesForStudent(string id)
        {
            var batches = await _itecdbcontext.Batches.Where(b => !b.StudentBatchEnrollments.Any(sbe => sbe.StudentId == id))
                .ToListAsync();

            return batches;
        }

        public async Task addStudentBatchEnrollment(StudentBatchEnrollment studentBatchEnrollment)
        {
            await _itecdbcontext.StudentBatchEnrollments.AddAsync(studentBatchEnrollment);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<MainCourse>> getCoursesForStudent(string id)
        {
            var allCourses = await _itecdbcontext.MainCourses.Include(mc => mc.CourseLevels.Where(cl => !cl.StudentCourseEnrollments.Any(sce => sce.StudentId  == id)))
                .ThenInclude(cl => cl.InstructorEnrollments).ThenInclude(ie => ie.Instructor)
                .Include(mc => mc.CourseLevels).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .Include(mc => mc.CourseImages)
                .ToListAsync();

            return allCourses;
        }

        public async Task<bool> checkRegFee(string id)
        {
            var status = await _itecdbcontext.StudentRegFeeEnrollments.AnyAsync(r => r.StudentId == id);
            return status;
        }

        public async Task addStudentCourseEnrollment(StudentCourseEnrollment studentCourseEnrollment)
        {
            await _itecdbcontext.studentCourseEnrollments.AddAsync(studentCourseEnrollment);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task deleteCourseEnrollment(int id)
        {
            var singleEnrollment = await _itecdbcontext.studentCourseEnrollments.SingleOrDefaultAsync(r => r.EnrollmentId == id);

            _itecdbcontext.studentCourseEnrollments.Remove(singleEnrollment);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task deleteBatchEnrollment(int id)
        {
            var singleEnrollment = await _itecdbcontext.StudentBatchEnrollments.SingleOrDefaultAsync(r => r.BatchEnrollmentId == id);

            _itecdbcontext.StudentBatchEnrollments.Remove(singleEnrollment);
            await _itecdbcontext.SaveChangesAsync();
        }

        public async Task<List<StudentCourseEnrollment>> getEnrollments()
        {
            var enrollments = await _itecdbcontext.studentCourseEnrollments.Include(sce => sce.Student)
                .Include(sce => sce.CourseLevel).ThenInclude(cl => cl.LevelEnrollment).ThenInclude(le => le.Level)
                .Include(sce => sce.CourseLevel).ThenInclude(cl => cl.MainCourse).ToListAsync();
            return enrollments;
        }

    }
}
