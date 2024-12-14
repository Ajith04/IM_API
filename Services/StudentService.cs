using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Models.CourseModels;
using ITEC_API.Models.StudentModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITEC_API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _iStudentRepo;
        public StudentService(IStudentRepo iStudentRepo)
        {
           _iStudentRepo = iStudentRepo;
        }

        public async Task addNewStudent(StudentRequest studentRequest)
        {
            var singleStudent = new Student()
            {
                StudentId = studentRequest.RegNo,
                FirstName = studentRequest.FirstName,
                LastName = studentRequest.LastName,
                DateOfJoin = studentRequest.DateOfJoin,
                MobileNo = studentRequest.MobileNo,
                Email = studentRequest.Email,
                Address = studentRequest.Address,
                Intake = studentRequest.Intake,
            };

            await _iStudentRepo.addNewStudent(singleStudent);
        }

        public async Task addFollowup(FollowUpRequest followUpRequest)
        {
            var followup = new FollowUp()
            {
                Name = followUpRequest.Name,
                Mobile = followUpRequest.Mobile,
                Date = followUpRequest.Date,
                Email = followUpRequest.Email,
                Address = followUpRequest.Address,
                Description = followUpRequest.Description,
                FollowUpEnrollments = new List<FollowUpEnrollment>()
            };

            if(followUpRequest.Courses.Count > 0 )
            {
                foreach(var courseName in followUpRequest.Courses)
                {
                    var singleRecord = await _iStudentRepo.getCourseNameRecord(courseName);

                    if (singleRecord != null)
                    {
                        followup.FollowUpEnrollments.Add(new FollowUpEnrollment
                        {
                            CourseNameID = singleRecord.Id
                        });
                    }
                   
                }
            }

            await _iStudentRepo.addFollowup(followup);
        }

        public async Task<List<FollowUpResponse>> getAllFollowup()
        {
            var followUpList = new List<FollowUpResponse>();

            var allFollowUp = await _iStudentRepo.getAllFollowUp();

            if(allFollowUp != null)
            {
                foreach(var followUp in allFollowUp)
                {
                    var singleFollowup = new FollowUpResponse()
                    {
                        Id = followUp.Id,
                        Name = followUp.Name,
                        Courses = new List<string>(),
                        Mobile = followUp.Mobile,
                        Date = followUp.Date,
                        Email = followUp.Email,
                        Address = followUp.Address,
                        Description = followUp.Description,

                    };

                    if(followUp.FollowUpEnrollments != null)
                    {
                        foreach(var singleEnrollment  in followUp.FollowUpEnrollments)
                        {
                            singleFollowup.Courses.Add(singleEnrollment.CourseName.Name);
                        }
                        
                    }

                    followUpList.Add(singleFollowup);
                }
                                
            }
            return followUpList;
        }

        public async Task removeFollowup(int id)
        {
            await _iStudentRepo.removeFollowup(id);
        }

        public async Task updateDescription(int id, DescriptionRequest description)
        {
            var singleRecord = await _iStudentRepo.getFollowUpById(id);
            if(singleRecord != null)
            {
                singleRecord.Description = description.Description;
            }

            await _iStudentRepo.updateDescription(singleRecord);
        }

        public async Task<List<StudentResponse>> getAllStudents()
        {
            var studentList = new List<StudentResponse>();

            var allStudents = await _iStudentRepo.getAllStudents();

            if(allStudents != null)
            {
                foreach (var singleStudent in allStudents)
                {
                    var studentResponse = new StudentResponse()
                    {
                        StudentId = singleStudent.StudentId,
                        FirstName = singleStudent.FirstName,
                        LastName = singleStudent.LastName,
                        DateOfJoin = singleStudent.DateOfJoin,
                        MobileNo = singleStudent.MobileNo,
                        Email = singleStudent.Email,
                        Address = singleStudent.Address,
                        Intake = singleStudent.Intake,
                        studentCourseLevelResponses = new List<StudentCourseLevelResponse>()
                    };
                    
                    if(singleStudent.StudentBatchEnrollment != null)
                    {
                        studentResponse.Batch = singleStudent.StudentBatchEnrollment.Batch.BatchName;
                    }

                    if (singleStudent.StudentCourseEnrollments != null)
                    {
                        foreach (var studentCourseEnrollment in singleStudent.StudentCourseEnrollments)
                        {
                            studentResponse.studentCourseLevelResponses.Add(new StudentCourseLevelResponse()
                            {
                                CourseId = studentCourseEnrollment.CourseId,
                                CourseName = studentCourseEnrollment.CourseLevel.MainCourse.CourseName,
                                LevelName = studentCourseEnrollment.CourseLevel.LevelEnrollment.Level.LevelName,
                                Duration = studentCourseEnrollment.Duration,
                                CourseFee = studentCourseEnrollment.CourseFee,
                                Instructor = studentCourseEnrollment.Instructor.InstructorName,
                                EnrolledDate = studentCourseEnrollment.EnrollmentDate
                                
                            });
                        }
                    }

                    studentList.Add(studentResponse);
                    
                }
            }
            return studentList;
        }

        public async Task<SingleStudentResponse> getSingleStudent(string id)
        {
            var singleStudent = await _iStudentRepo.getSingleStudent(id);
            var studentResponse = new SingleStudentResponse()
            {
                StudentId = singleStudent.StudentId,
                FirstName = singleStudent.FirstName,
                LastName = singleStudent.LastName,
                DateOfJoin = singleStudent.DateOfJoin,
                MobileNo = singleStudent.MobileNo,
                Email = singleStudent.Email,
                Address = singleStudent.Address,
                Intake = singleStudent.Intake,
                singleStudentCourseLevelResponses = new List<SingleStudentCourseLevelResponse>()
            };

            if(singleStudent.StudentBatchEnrollment != null)
            {
                studentResponse.BatchEnrollmentId = singleStudent.StudentBatchEnrollment.BatchEnrollmentId;
                studentResponse.Batch = singleStudent.StudentBatchEnrollment.Batch.BatchName;
            }

            if(singleStudent.StudentCourseEnrollments != null) 
            { 
                foreach(var courseEnrollment in singleStudent.StudentCourseEnrollments)
                {
                    studentResponse.singleStudentCourseLevelResponses.Add(new SingleStudentCourseLevelResponse()
                    {
                        CourseEnrollmentId = courseEnrollment.EnrollmentId,
                        CourseImage = courseEnrollment.CourseLevel.MainCourse.CourseImages.FirstOrDefault()?.Thumbnails,
                        CourseName = courseEnrollment.CourseLevel.MainCourse.CourseName,
                        LevelName = courseEnrollment.CourseLevel.LevelEnrollment.Level.LevelName,
                        InstructorName = courseEnrollment.Instructor.InstructorName

                    });
                }
            }

            return studentResponse;
        }

        public async Task updateSingleStudent(string id, StudentUpdateRequest studentUpdateRequest)
        {
            var singleStudent = await _iStudentRepo.getSingleStudent(id);

            if (singleStudent != null)
            {
                singleStudent.MobileNo = studentUpdateRequest.Mobile;
                singleStudent.Email = studentUpdateRequest.Email;
                singleStudent.Address = studentUpdateRequest.Address;
            }

            await _iStudentRepo.updateSingleStudent(singleStudent);
        }

        public async Task deleteStudent(string id)
        {
            var singleStudent = await _iStudentRepo.getSingleStudent(id);

            await _iStudentRepo.deleteStudent(singleStudent);
        }

        public async Task<List<BatchForStudentResponse>> getBatchesForStudent(string id)
        {

            var batchList = new List<BatchForStudentResponse>();
            var batches = await _iStudentRepo.getBatchesForStudent(id);

            if(batches != null)
            {
                foreach (var batch in batches)
                {
                    batchList.Add(new BatchForStudentResponse
                    {
                        BatchId = batch.BatchId,
                        BatchName = batch.BatchName,
                    });
                }
            }
            return batchList;
        }

        public async Task addStudentBatchEnrollment(StudentBatchRequest studentBatchRequest)
        {
            var singleEnrollment = new StudentBatchEnrollment()
            {
                StudentId = studentBatchRequest.StudentId,
                BatchId = studentBatchRequest.BatchId,
            };

            await _iStudentRepo.addStudentBatchEnrollment(singleEnrollment);
        }

        public async Task<List<CourseForStudentResponse>> getCoursesForStudent(string id)
        {
            var courseList = new List<CourseForStudentResponse>();

            var allCourses = await _iStudentRepo.getCoursesForStudent(id);

            if(allCourses != null)
            {
                foreach(var course in allCourses)
                {
                    var courseResponse = new CourseForStudentResponse();
                    courseResponse.MainCourseName = course.CourseName;
                    courseResponse.CourseLevels = new List<CourseLevelForStudentResponse>();

                    
                    if(course.CourseLevels != null)
                    {
                        foreach(var courseLevel in course.CourseLevels)
                        {
                            var courseLevelResponse = new CourseLevelForStudentResponse();
                            courseLevelResponse.LevelId = courseLevel.CourseId;
                            courseLevelResponse.LevelName = courseLevel.LevelEnrollment.Level.LevelName;
                            courseLevelResponse.CourseFee = courseLevel.CourseFee;
                            courseLevelResponse.Duration = courseLevel.Duration;
                            courseLevelResponse.CourseImages = new List<byte[]>();
                            courseLevelResponse.Instructors = new List<InstructorForStudentCourseResponse>();

                            if (course.CourseImages != null)
                            {
                                foreach (var image in course.CourseImages)
                                {
                                    courseLevelResponse.CourseImages.Add(image.Thumbnails);
                                }
                            }


                            if (courseLevel.InstructorEnrollments != null)
                            {
                                foreach (var instructor in courseLevel.InstructorEnrollments)
                                {
                                    courseLevelResponse.Instructors.Add(new InstructorForStudentCourseResponse()
                                    {
                                        InstructorId = instructor.Instructor.InstructorId,
                                        Name = instructor.Instructor.InstructorName,
                                        Avatar = instructor.Instructor.Avatar,
                                    });
                                }
                            }

                            courseResponse.CourseLevels.Add(courseLevelResponse);
                        }
                    }

                    courseList.Add(courseResponse);
                }
            }

            return courseList;

        }

        public async Task<bool> checkRegFee(string id)
        {
            var status = await _iStudentRepo.checkRegFee(id);
            return status;
        }

        public async Task addStudentCourseEnrollment(StudentEnrollmentRequest studentEnrollmentRequest)
        {
            var singleEnrollment = new StudentCourseEnrollment()
            {
                StudentId = studentEnrollmentRequest.StudentId,
                CourseId = studentEnrollmentRequest.CourseId,
                InstructorId = studentEnrollmentRequest.InstructorId,
                CourseFee = studentEnrollmentRequest.CourseFee,
                Duration = studentEnrollmentRequest.Duration,
                EnrollmentDate = studentEnrollmentRequest.EnrollmentDate,
            };

            await _iStudentRepo.addStudentCourseEnrollment(singleEnrollment);
        }

        public async Task deleteCourseEnrollment(int id)
        {
            await _iStudentRepo.deleteCourseEnrollment(id);
        }

        public async Task deleteBatchEnrollment(int id)
        {
            await _iStudentRepo.deleteBatchEnrollment(id);
        }

        public async Task<List<EnrollmentResponse>> getEnrollments()
        {
            var enrollmentList = new List<EnrollmentResponse>();

            var allEnrollments = await _iStudentRepo.getEnrollments();
            if(allEnrollments != null)
            {
                foreach(var enrollment in allEnrollments)
                {
                    enrollmentList.Add(new EnrollmentResponse()
                    {
                        StudentId = enrollment.StudentId,
                        StudentName = enrollment.Student.FirstName,
                        Course = $"{enrollment.CourseLevel.MainCourse.CourseName} - {enrollment.CourseLevel.LevelEnrollment.Level.LevelName}",
                        EnrollDate = enrollment.EnrollmentDate
                    });
                }
            }
            return enrollmentList;
        }
    }
}
