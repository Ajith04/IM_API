using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITEC_API.Migrations
{
    /// <inheritdoc />
    public partial class Sample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    BatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CourseNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "FollowUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateOfJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "MainCourses",
                columns: table => new
                {
                    MainCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCourses", x => x.MainCourseId);
                });

            migrationBuilder.CreateTable(
                name: "registrationFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrationFee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intake = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "expenseReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    Receipt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenseReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_expenseReceipts_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseNameID = table.Column<int>(type: "int", nullable: false),
                    FollowUpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowUpEnrollments_CourseNames_CourseNameID",
                        column: x => x.CourseNameID,
                        principalTable: "CourseNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowUpEnrollments_FollowUps_FollowUpId",
                        column: x => x.FollowUpId,
                        principalTable: "FollowUps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorKnowCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CourseNameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorKnowCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorKnowCourses_CourseNames_CourseNameId",
                        column: x => x.CourseNameId,
                        principalTable: "CourseNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorKnowCourses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryEnrollments",
                columns: table => new
                {
                    CategoryEnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCourseId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEnrollments", x => x.CategoryEnrollmentId);
                    table.ForeignKey(
                        name: "FK_CategoryEnrollments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryEnrollments_MainCourses_MainCourseId",
                        column: x => x.MainCourseId,
                        principalTable: "MainCourses",
                        principalColumn: "MainCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCourseId = table.Column<int>(type: "int", nullable: false),
                    Thumbnails = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseImages_MainCourses_MainCourseId",
                        column: x => x.MainCourseId,
                        principalTable: "MainCourses",
                        principalColumn: "MainCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseLevels",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MainCourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLevels", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_CourseLevels_MainCourses_MainCourseId",
                        column: x => x.MainCourseId,
                        principalTable: "MainCourses",
                        principalColumn: "MainCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentBatchEnrollments",
                columns: table => new
                {
                    BatchEnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentBatchEnrollments", x => x.BatchEnrollmentId);
                    table.ForeignKey(
                        name: "FK_StudentBatchEnrollments_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentBatchEnrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentRegFeeEnrollments",
                columns: table => new
                {
                    RegFeeEnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegFeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegFeeEnrollments", x => x.RegFeeEnrollmentId);
                    table.ForeignKey(
                        name: "FK_StudentRegFeeEnrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRegFeeEnrollments_registrationFee_RegFeeId",
                        column: x => x.RegFeeId,
                        principalTable: "registrationFee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorEnrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorEnrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_InstructorEnrollments_CourseLevels_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseLevels",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorEnrollments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelEnrollments",
                columns: table => new
                {
                    LevelEnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelEnrollments", x => x.LevelEnrollmentId);
                    table.ForeignKey(
                        name: "FK_LevelEnrollments_CourseLevels_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseLevels",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelEnrollments_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentCourseEnrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    CourseFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentCourseEnrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_studentCourseEnrollments_CourseLevels_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseLevels",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentCourseEnrollments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentCourseEnrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyMaterials",
                columns: table => new
                {
                    StudyMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyMaterials", x => x.StudyMaterialId);
                    table.ForeignKey(
                        name: "FK_StudyMaterials_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyMaterials_CourseLevels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "CourseLevels",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyMaterialFiles",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyMaterialId = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyMaterialFiles", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_StudyMaterialFiles_StudyMaterials_StudyMaterialId",
                        column: x => x.StudyMaterialId,
                        principalTable: "StudyMaterials",
                        principalColumn: "StudyMaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEnrollments_CategoryId",
                table: "CategoryEnrollments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEnrollments_MainCourseId",
                table: "CategoryEnrollments",
                column: "MainCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseImages_MainCourseId",
                table: "CourseImages",
                column: "MainCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLevels_MainCourseId",
                table: "CourseLevels",
                column: "MainCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_expenseReceipts_ExpenseId",
                table: "expenseReceipts",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpEnrollments_CourseNameID",
                table: "FollowUpEnrollments",
                column: "CourseNameID");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpEnrollments_FollowUpId",
                table: "FollowUpEnrollments",
                column: "FollowUpId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorEnrollments_CourseId",
                table: "InstructorEnrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorEnrollments_InstructorId",
                table: "InstructorEnrollments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorKnowCourses_CourseNameId",
                table: "InstructorKnowCourses",
                column: "CourseNameId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorKnowCourses_InstructorId",
                table: "InstructorKnowCourses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelEnrollments_CourseId",
                table: "LevelEnrollments",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LevelEnrollments_LevelId",
                table: "LevelEnrollments",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBatchEnrollments_BatchId",
                table: "StudentBatchEnrollments",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBatchEnrollments_StudentId",
                table: "StudentBatchEnrollments",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentCourseEnrollments_CourseId",
                table: "studentCourseEnrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_studentCourseEnrollments_InstructorId",
                table: "studentCourseEnrollments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_studentCourseEnrollments_StudentId",
                table: "studentCourseEnrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegFeeEnrollments_RegFeeId",
                table: "StudentRegFeeEnrollments",
                column: "RegFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegFeeEnrollments_StudentId",
                table: "StudentRegFeeEnrollments",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudyMaterialFiles_StudyMaterialId",
                table: "StudyMaterialFiles",
                column: "StudyMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMaterials_BatchId",
                table: "StudyMaterials",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMaterials_LevelId",
                table: "StudyMaterials",
                column: "LevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryEnrollments");

            migrationBuilder.DropTable(
                name: "CourseImages");

            migrationBuilder.DropTable(
                name: "expenseReceipts");

            migrationBuilder.DropTable(
                name: "FollowUpEnrollments");

            migrationBuilder.DropTable(
                name: "InstructorEnrollments");

            migrationBuilder.DropTable(
                name: "InstructorKnowCourses");

            migrationBuilder.DropTable(
                name: "LevelEnrollments");

            migrationBuilder.DropTable(
                name: "StudentBatchEnrollments");

            migrationBuilder.DropTable(
                name: "studentCourseEnrollments");

            migrationBuilder.DropTable(
                name: "StudentRegFeeEnrollments");

            migrationBuilder.DropTable(
                name: "StudyMaterialFiles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "FollowUps");

            migrationBuilder.DropTable(
                name: "CourseNames");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "registrationFee");

            migrationBuilder.DropTable(
                name: "StudyMaterials");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "CourseLevels");

            migrationBuilder.DropTable(
                name: "MainCourses");
        }
    }
}
