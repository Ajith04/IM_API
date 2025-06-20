﻿// <auto-generated />
using System;
using ITEC_API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITEC_API.Migrations
{
    [DbContext(typeof(ITECDbContext))]
    [Migration("20250610113800_hiue")]
    partial class hiue
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITEC_API.Models.AdminAuthModels.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("MailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ITEC_API.Models.AdminAuthModels.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.Batch", b =>
                {
                    b.Property<int>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BatchId"));

                    b.Property<string>("BatchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BatchId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.CategoryEnrollment", b =>
                {
                    b.Property<int>("CategoryEnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryEnrollmentId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("MainCourseId")
                        .HasColumnType("int");

                    b.HasKey("CategoryEnrollmentId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MainCourseId");

                    b.ToTable("CategoryEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.CourseImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MainCourseId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Thumbnails")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainCourseId");

                    b.ToTable("CourseImages");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.CourseLevel", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CourseFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainCourseId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("MainCourseId");

                    b.ToTable("CourseLevels");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.CourseName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CourseNames");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorId"));

                    b.Property<byte[]>("Avatar")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("DateOfJoin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.InstructorEnrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentId"));

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("InstructorEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.InstructorKnowCourses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseNameId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseNameId");

                    b.HasIndex("InstructorId");

                    b.ToTable("InstructorKnowCourses");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.Level", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LevelId"));

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LevelId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.LevelEnrollment", b =>
                {
                    b.Property<int>("LevelEnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LevelEnrollmentId"));

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.HasKey("LevelEnrollmentId");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.HasIndex("LevelId");

                    b.ToTable("LevelEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.MainCourse", b =>
                {
                    b.Property<int>("MainCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MainCourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MainCourseId");

                    b.ToTable("MainCourses");
                });

            modelBuilder.Entity("ITEC_API.Models.PaymentModels.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpenseId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ITEC_API.Models.PaymentModels.ExpenseReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExpenseId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Receipt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.ToTable("expenseReceipts");
                });

            modelBuilder.Entity("ITEC_API.Models.PaymentModels.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("EnrollmentId")
                        .HasColumnType("int");

                    b.Property<decimal>("PaidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaidDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId");

                    b.HasIndex("EnrollmentId");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("ITEC_API.Models.PaymentModels.RegistrationFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("RegFee")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("registrationFee");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.FollowUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FollowUps");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.FollowUpEnrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseNameID")
                        .HasColumnType("int");

                    b.Property<int>("FollowUpId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseNameID");

                    b.HasIndex("FollowUpId");

                    b.ToTable("FollowUpEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfJoin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Intake")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.StudentBatchEnrollment", b =>
                {
                    b.Property<int>("BatchEnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BatchEnrollmentId"));

                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BatchEnrollmentId");

                    b.HasIndex("BatchId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentBatchEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.StudentCourseEnrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentId"));

                    b.Property<decimal>("CourseFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("StudentId");

                    b.ToTable("studentCourseEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.StudentRegFeeEnrollment", b =>
                {
                    b.Property<int>("RegFeeEnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegFeeEnrollmentId"));

                    b.Property<int>("RegFeeId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RegFeeEnrollmentId");

                    b.HasIndex("RegFeeId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentRegFeeEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.StudyMaterialsModels.StudyMaterial", b =>
                {
                    b.Property<int>("StudyMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudyMaterialId"));

                    b.Property<int>("BatchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudyMaterialId");

                    b.HasIndex("BatchId");

                    b.HasIndex("LevelId");

                    b.ToTable("StudyMaterials");
                });

            modelBuilder.Entity("ITEC_API.Models.StudyMaterialsModels.StudyMaterialFile", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"));

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("StudyMaterialId")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.HasIndex("StudyMaterialId");

                    b.ToTable("StudyMaterialFiles");
                });

            modelBuilder.Entity("ITEC_API.Models.AdminAuthModels.Account", b =>
                {
                    b.HasOne("ITEC_API.Models.AdminAuthModels.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.CategoryEnrollment", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.Category", "Category")
                        .WithMany("CategoryEnrollments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.CourseModels.MainCourse", "MainCourse")
                        .WithMany("CategoryEnrollments")
                        .HasForeignKey("MainCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("MainCourse");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.CourseImage", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.MainCourse", "MainCourse")
                        .WithMany("CourseImages")
                        .HasForeignKey("MainCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCourse");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.CourseLevel", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.MainCourse", "MainCourse")
                        .WithMany("CourseLevels")
                        .HasForeignKey("MainCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCourse");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.InstructorEnrollment", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.CourseLevel", "CourseLevel")
                        .WithMany("InstructorEnrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.CourseModels.Instructor", "Instructor")
                        .WithMany("InstructorEnrollments")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseLevel");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.InstructorKnowCourses", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.CourseName", "CourseName")
                        .WithMany("InstructorKnowCourses")
                        .HasForeignKey("CourseNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.CourseModels.Instructor", "Instructor")
                        .WithMany("InstructorKnowCourses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseName");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.LevelEnrollment", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.CourseLevel", "CourseLevel")
                        .WithOne("LevelEnrollment")
                        .HasForeignKey("ITEC_API.Models.CourseModels.LevelEnrollment", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.CourseModels.Level", "Level")
                        .WithMany("LevelEnrollments")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseLevel");

                    b.Navigation("Level");
                });

            modelBuilder.Entity("ITEC_API.Models.PaymentModels.ExpenseReceipt", b =>
                {
                    b.HasOne("ITEC_API.Models.PaymentModels.Expense", "Expense")
                        .WithMany("ExpenseReceipts")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expense");
                });

            modelBuilder.Entity("ITEC_API.Models.PaymentModels.Payment", b =>
                {
                    b.HasOne("ITEC_API.Models.StudentModels.StudentCourseEnrollment", "studentCourseEnrollment")
                        .WithMany("Payments")
                        .HasForeignKey("EnrollmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("studentCourseEnrollment");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.FollowUpEnrollment", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.CourseName", "CourseName")
                        .WithMany("FollowUpEnrollments")
                        .HasForeignKey("CourseNameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.StudentModels.FollowUp", "FollowUp")
                        .WithMany("FollowUpEnrollments")
                        .HasForeignKey("FollowUpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseName");

                    b.Navigation("FollowUp");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.StudentBatchEnrollment", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.Batch", "Batch")
                        .WithMany("StudentBatchEnrollments")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.StudentModels.Student", "Student")
                        .WithOne("StudentBatchEnrollment")
                        .HasForeignKey("ITEC_API.Models.StudentModels.StudentBatchEnrollment", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.StudentCourseEnrollment", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.CourseLevel", "CourseLevel")
                        .WithMany("StudentCourseEnrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.CourseModels.Instructor", "Instructor")
                        .WithMany("StudentCourseEnrollments")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.StudentModels.Student", "Student")
                        .WithMany("StudentCourseEnrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseLevel");

                    b.Navigation("Instructor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.StudentRegFeeEnrollment", b =>
                {
                    b.HasOne("ITEC_API.Models.PaymentModels.RegistrationFee", "RegistrationFee")
                        .WithMany("StudentRegFeeEnrollments")
                        .HasForeignKey("RegFeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.StudentModels.Student", "Student")
                        .WithOne("StudentRegFeeEnrollment")
                        .HasForeignKey("ITEC_API.Models.StudentModels.StudentRegFeeEnrollment", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegistrationFee");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ITEC_API.Models.StudyMaterialsModels.StudyMaterial", b =>
                {
                    b.HasOne("ITEC_API.Models.CourseModels.Batch", "Batch")
                        .WithMany("StudyMaterials")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITEC_API.Models.CourseModels.CourseLevel", "CourseLevel")
                        .WithMany("StudyMaterials")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("CourseLevel");
                });

            modelBuilder.Entity("ITEC_API.Models.StudyMaterialsModels.StudyMaterialFile", b =>
                {
                    b.HasOne("ITEC_API.Models.StudyMaterialsModels.StudyMaterial", "StudyMaterial")
                        .WithMany("Files")
                        .HasForeignKey("StudyMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudyMaterial");
                });

            modelBuilder.Entity("ITEC_API.Models.AdminAuthModels.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.Batch", b =>
                {
                    b.Navigation("StudentBatchEnrollments");

                    b.Navigation("StudyMaterials");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.Category", b =>
                {
                    b.Navigation("CategoryEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.CourseLevel", b =>
                {
                    b.Navigation("InstructorEnrollments");

                    b.Navigation("LevelEnrollment")
                        .IsRequired();

                    b.Navigation("StudentCourseEnrollments");

                    b.Navigation("StudyMaterials");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.CourseName", b =>
                {
                    b.Navigation("FollowUpEnrollments");

                    b.Navigation("InstructorKnowCourses");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.Instructor", b =>
                {
                    b.Navigation("InstructorEnrollments");

                    b.Navigation("InstructorKnowCourses");

                    b.Navigation("StudentCourseEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.Level", b =>
                {
                    b.Navigation("LevelEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.CourseModels.MainCourse", b =>
                {
                    b.Navigation("CategoryEnrollments");

                    b.Navigation("CourseImages");

                    b.Navigation("CourseLevels");
                });

            modelBuilder.Entity("ITEC_API.Models.PaymentModels.Expense", b =>
                {
                    b.Navigation("ExpenseReceipts");
                });

            modelBuilder.Entity("ITEC_API.Models.PaymentModels.RegistrationFee", b =>
                {
                    b.Navigation("StudentRegFeeEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.FollowUp", b =>
                {
                    b.Navigation("FollowUpEnrollments");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.Student", b =>
                {
                    b.Navigation("StudentBatchEnrollment")
                        .IsRequired();

                    b.Navigation("StudentCourseEnrollments");

                    b.Navigation("StudentRegFeeEnrollment");
                });

            modelBuilder.Entity("ITEC_API.Models.StudentModels.StudentCourseEnrollment", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("ITEC_API.Models.StudyMaterialsModels.StudyMaterial", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
