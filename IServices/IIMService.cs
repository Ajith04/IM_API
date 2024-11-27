using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;

namespace ITEC_API.IServices
{
    public interface IIMService
    {
        Task addInstructor(InstructorRequest instructorRequest);
        Task<List<AllInstructorResponse>> getAllInstructors();
    }
}
