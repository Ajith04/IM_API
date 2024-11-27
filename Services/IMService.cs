using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Models.CourseModels;

namespace ITEC_API.Services
{
    public class IMService : IIMService
    {
        private readonly IIMRepo _iimrepo;

        public IMService(IIMRepo iimrepo)
        {
            _iimrepo = iimrepo;
        }

        public async Task addInstructor(InstructorRequest instructorRequest)
        {
            var instructor = new Instructor()
            {
                InstructorName = instructorRequest.InstructorName,
                Description = instructorRequest.Description,
                DateOfJoin = instructorRequest.DateOfJoin,
                Mobile = instructorRequest.Mobile,
                Email = instructorRequest.Email

             
            };

            if (instructorRequest.Avatar != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await instructorRequest.Avatar.CopyToAsync(memoryStream);
                    instructor.Avatar = memoryStream.ToArray();
                }
            }

            await _iimrepo.addInstructor(instructor);
        }

        public async Task<List<AllInstructorResponse>> getAllInstructors()
        {
            var instructorList = new List<AllInstructorResponse>();

            var allInstructors = await _iimrepo.getAllInstructors();

            if(allInstructors != null)
            {
                foreach(var instructor in allInstructors)
                {
                    var singleInstructor = new AllInstructorResponse()
                    {
                        InstructorName = instructor.InstructorName,
                        Description = instructor.Description,
                        Avatar = instructor.Avatar,
                        DateOfJoin = instructor.DateOfJoin,
                        Mobile = instructor.Mobile,
                        Email = instructor.Email
                    };
                    instructorList.Add(singleInstructor);
                }
            }
            return instructorList;
        }
    }
}
