using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;

namespace ITEC_API.IServices
{
    public interface ISMService
    {
        Task<List<CourseLevelForSMResponse>> getCourseLevels(string courseName);
        Task addStudyMaterial(SMRequest smRequest);
        Task<List<StudyMaterialResponse>> getStudyMaterials();
    }
}
