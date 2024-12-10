using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Models.StudentModels;

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
                    studentList.Add(new StudentResponse()
                    {
                        StudentId = singleStudent.StudentId,
                        FirstName = singleStudent.FirstName,
                        LastName = singleStudent.LastName,
                        DateOfJoin = singleStudent.DateOfJoin,
                        MobileNo = singleStudent.MobileNo,
                        Email = singleStudent.Email,
                        Address = singleStudent.Address,
                        Intake = singleStudent.Intake,
                    });
                }
            }
            return studentList;
        }

        public async Task<StudentResponse> getSingleStudent(string id)
        {
            var singleStudent = await _iStudentRepo.getSingleStudent(id);
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
            };
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
    }
}
