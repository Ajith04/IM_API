﻿using ITEC_API.Database;
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
            var allStudents = await _itecdbcontext.Students.ToListAsync();
            return allStudents;
        }

        public async Task<Student> getSingleStudent(string id)
        {
            var singleStudent = await _itecdbcontext.Students.SingleOrDefaultAsync(r => r.StudentId == id);
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
        
    }
}
