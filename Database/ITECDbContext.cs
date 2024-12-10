using ITEC_API.Models;
using ITEC_API.Models.CourseModels;
using ITEC_API.Models.PaymentModels;
using ITEC_API.Models.StudentModels;
using ITEC_API.Models.StudyMaterialsModels;
using Microsoft.EntityFrameworkCore;

namespace ITEC_API.Database
{
    public class ITECDbContext : DbContext
    {
        public ITECDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MainCourse> MainCourses { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorEnrollment> InstructorEnrollments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<CategoryEnrollment> CategoryEnrollments { get; set; }
        public DbSet<LevelEnrollment> LevelEnrollments { get; set; }
        public DbSet<CourseName> CourseNames { get; set; }
        public DbSet<InstructorKnowCourses> InstructorKnowCourses { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseReceipt> expenseReceipts { get; set; }

        public DbSet<RegistrationFee> registrationFee { get; set; }

        public DbSet<StudyMaterial> StudyMaterials { get; set; }
        public DbSet<StudyMaterialFile> StudyMaterialFiles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }

        public DbSet<FollowUpEnrollment> FollowUpEnrollments { get; set; }
        public DbSet<StudentBatchEnrollment> StudentBatchEnrollments { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainCourse>()
                 .HasMany(mc => mc.CourseLevels)
                 .WithOne(cl => cl.MainCourse)
                 .HasForeignKey(cl => cl.MainCourseId);

            modelBuilder.Entity<InstructorEnrollment>()
                .HasOne(ie => ie.CourseLevel)
                .WithMany(cl => cl.InstructorEnrollments)
                .HasForeignKey(ie => ie.CourseId);

            modelBuilder.Entity<InstructorEnrollment>()
                .HasOne(ie => ie.Instructor)
                .WithMany(i => i.InstructorEnrollments)
                .HasForeignKey(ie => ie.InstructorId);

            modelBuilder.Entity<MainCourse>()
                .HasMany(mc => mc.CategoryEnrollments)
                .WithOne(ce => ce.MainCourse)
                .HasForeignKey(ce => ce.MainCourseId);

            modelBuilder.Entity<Category>()
               .HasMany(c => c.CategoryEnrollments)
               .WithOne(ce => ce.Category)
               .HasForeignKey(ce => ce.CategoryId);

            modelBuilder.Entity<CourseLevel>()
               .HasOne(cl => cl.LevelEnrollment)
               .WithOne(le => le.CourseLevel)
               .HasForeignKey<LevelEnrollment>(le => le.CourseId);

            modelBuilder.Entity<Level>()
               .HasMany(l => l.LevelEnrollments)
               .WithOne(le => le.Level)
               .HasForeignKey(le => le.LevelId);

            modelBuilder.Entity<MainCourse>()
               .HasMany(mc => mc.CourseImages)
               .WithOne(ci => ci.MainCourse)
               .HasForeignKey(ci => ci.MainCourseId);

            modelBuilder.Entity<Instructor>()
               .HasMany(i => i.InstructorKnowCourses)
               .WithOne(ik => ik.Instructor)
               .HasForeignKey(ik => ik.InstructorId);

            modelBuilder.Entity<CourseName>()
               .HasMany(cn => cn.InstructorKnowCourses)
               .WithOne(ik => ik.CourseName)
               .HasForeignKey(ik => ik.CourseNameId);

            modelBuilder.Entity<Expense>()
                 .HasMany(e => e.ExpenseReceipts)
                 .WithOne(er => er.Expense)
                 .HasForeignKey(er => er.ExpenseId);

            modelBuilder.Entity<StudyMaterial>()
                .HasOne(sm => sm.CourseLevel)
                .WithMany(cl => cl.StudyMaterials)
                .HasForeignKey(sm => sm.LevelId);

            modelBuilder.Entity<StudyMaterial>()
                .HasOne(sm => sm.Batch)
                .WithMany(b => b.StudyMaterials)
                .HasForeignKey(sm => sm.BatchId);

            modelBuilder.Entity<StudyMaterial>()
                .HasMany(sm => sm.Files)
                .WithOne(smf => smf.StudyMaterial)
                .HasForeignKey(smf => smf.StudyMaterialId);

            modelBuilder.Entity<FollowUp>()
                .HasMany(fu => fu.FollowUpEnrollments)
                .WithOne(fue => fue.FollowUp)
                .HasForeignKey(fue => fue.FollowUpId);

            modelBuilder.Entity<CourseName>()
                .HasMany(cn => cn.FollowUpEnrollments)
                .WithOne(fue => fue.CourseName)
                .HasForeignKey(fue => fue.CourseNameID);

            modelBuilder.Entity<Student>()
               .HasOne(s => s.StudentBatchEnrollment)
               .WithOne(sbe => sbe.Student)
               .HasForeignKey<StudentBatchEnrollment>(sbe => sbe.StudentId);

            modelBuilder.Entity<Batch>()
               .HasMany(b => b.StudentBatchEnrollments)
               .WithOne(sbe => sbe.Batch)
               .HasForeignKey(sbe => sbe.BatchId);
        }
    }
}
