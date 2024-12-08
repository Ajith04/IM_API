using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Models.CourseModels;
using ITEC_API.Models.StudyMaterialsModels;

namespace ITEC_API.Services
{
    public class SMService : ISMService
    {
        private readonly ISMRepo _iSMRepo;

        public SMService(ISMRepo iSMRepo)
        {
            _iSMRepo = iSMRepo;
        }

        public async Task<List<CourseLevelForSMResponse>> getCourseLevels(string courseName)
        {
            var singleMainCourse = await _iSMRepo.getCourseLevels(courseName);

            var courseLevelList = new List<CourseLevelForSMResponse>();
            foreach(var courseLevel in singleMainCourse.CourseLevels) 
            {
                var singleCourseLevel = new CourseLevelForSMResponse()
                {
                    LevelId = courseLevel.CourseId,
                    LevelName = courseLevel.LevelEnrollment.Level.LevelName
                };

                courseLevelList.Add(singleCourseLevel);
            }
            return courseLevelList;
        }

        public async Task addStudyMaterial(SMRequest smRequest)
        {
            var singleBatch = await _iSMRepo.getBatchId(smRequest.BatchName);

            var studyMaterial = new StudyMaterial()
            {
                Title = smRequest.Title,
                LevelId = smRequest.LevelId,
                BatchId = singleBatch.BatchId,
                Date = smRequest.Date,
                Description = smRequest.Description,
                Files = new List<StudyMaterialFile>()
            };

            if(smRequest.Files != null)
            {
                foreach (var file in smRequest.Files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        studyMaterial.Files.Add(new StudyMaterialFile
                        {
                            File = memoryStream.ToArray()
                        });
                    }
                }
            }

            await _iSMRepo.addStudyMaterial(studyMaterial);
        }


        public async Task<List<StudyMaterialResponse>> getStudyMaterials()
        {
            var studyMaterialList = new List<StudyMaterialResponse>();

            var allStudyMaterials = await _iSMRepo.getStudyMaterials();

            if(allStudyMaterials != null)
            {
                foreach (var studyMaterial in allStudyMaterials)
                {
                    var singleStudyMaterial = new StudyMaterialResponse()
                    {
                        Date = studyMaterial.Date,
                        Title = studyMaterial.Title,
                        Course = $"{studyMaterial.CourseLevel.MainCourse.CourseName}" + " - " + $"{studyMaterial.CourseLevel.LevelEnrollment.Level.LevelName}",
                        BatchName = studyMaterial.Batch.BatchName,
                        Files = new List<SMFileResponse>(),
                    };

                    if (studyMaterial.Files != null)
                    {

                        foreach (var file in studyMaterial.Files)
                        {
                            singleStudyMaterial.Files.Add(new SMFileResponse()
                            {
                                File = file.File
                            });
                        }
                    }

                    studyMaterialList.Add(singleStudyMaterial);
                }
            }

            return studyMaterialList;
        }
    }
}
