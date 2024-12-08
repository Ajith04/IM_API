using ITEC_API.Models.CourseModels;
using ITEC_API.Models.StudyMaterialsModels;

namespace ITEC_API.IRepositories
{
    public interface ISMRepo
    {
        Task<MainCourse> getCourseLevels(string courseName);
        Task<Batch> getBatchId(string batchName);
        Task addStudyMaterial(StudyMaterial studymaterial);
        Task<List<StudyMaterial>> getStudyMaterials();
    }
}
