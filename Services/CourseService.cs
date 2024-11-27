using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Models.CourseModels;
using System.Data.SqlTypes;


namespace ITEC_API.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _icourserepo;
        public CourseService(ICourseRepo icourserepo)
        {
            _icourserepo = icourserepo;
        }

        public async Task<List<CourseCategoryResponse>> getAllCategories()
        {
            List<CourseCategoryResponse> categoryList = new List<CourseCategoryResponse>();

            var allCategories =  await _icourserepo.getAllCategories();

            allCategories.ForEach(category =>
            {
                var singleCategory = new CourseCategoryResponse()
                {
                    CategoryName = category.CategoryName,
                };

                categoryList.Add(singleCategory);
            });

            return categoryList; 
            
        }


        public async Task addMainCourse(MainCourseRequest mainCourseRequest)
        {
            var mainCourse = new MainCourse()
            {
                CourseName = mainCourseRequest.CourseName,
                CourseImages = new List<CourseImage>(),
                CategoryEnrollments = new List<CategoryEnrollment>()

            };

            if (mainCourseRequest.Thumbnails != null)
            {
                foreach (var item in mainCourseRequest.Thumbnails)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await item.CopyToAsync(memoryStream);
                        mainCourse.CourseImages.Add(new CourseImage
                        {
                            Thumbnails = memoryStream.ToArray()
                        });
                    }
                }

            }

            if(mainCourseRequest.Categories != null)
            {
                foreach (var category in mainCourseRequest.Categories)
                {
                    var singleCategory = await _icourserepo.getSingleCategory(category);

                    if(singleCategory != null)
                    {
                        mainCourse.CategoryEnrollments.Add(new CategoryEnrollment
                        {
                            CategoryId = singleCategory.CategoryId
                        });
                    }
                }
            }

            await _icourserepo.addMainCourse(mainCourse);

        }

        public async Task<List<MainCourseResponse>> getMainCourseNames()
        {
            var mainCourseList = new List<MainCourseResponse>();

            var singleMainCourse = await _icourserepo.getMainCourseNames();
            if (singleMainCourse != null)
            {
                foreach (var item in singleMainCourse)
                {
                    var mainCourse = new MainCourseResponse()
                    {
                        CourseName = item.CourseName,
                    };
                    mainCourseList.Add(mainCourse);
                }
                
            }
            return mainCourseList;
        }

        public async Task<List<LevelResponse>> getAllLevels()
        {
            var levelList = new List<LevelResponse>();

            var allLevels = await _icourserepo.getAllLevels();

            if (allLevels != null)
            {

                foreach (var item in allLevels)
                {
                    var singleLevel = new LevelResponse()
                    {
                        LevelName = item.LevelName,
                    };
                    levelList.Add(singleLevel);
                }
            }
            return levelList;
        }

        public async Task addCourseLevel(AddCourseLevelRequest addCourseLevelRequest)
        {
            var singleMainCourse = await _icourserepo.getSingleMainCourse(addCourseLevelRequest.CourseName);
            var singleLevel = await _icourserepo.getSingleLevel(addCourseLevelRequest.LevelName);

            var courseLevel = new CourseLevel()
            {
                CourseId = addCourseLevelRequest.CourseId,
                MainCourseId = singleMainCourse.MainCourseId,
                CreatedDate  = addCourseLevelRequest.CreatedDate,
                Duration = addCourseLevelRequest.Duration,
                CourseFee = addCourseLevelRequest.CourseFee,
                Description = addCourseLevelRequest.Description,
            };

            await _icourserepo.addCourseLevel(courseLevel);

            var levelEnrollment = new LevelEnrollment()
            {
                CourseId = addCourseLevelRequest.CourseId,
                LevelId = singleLevel.LevelId,
            };

            await _icourserepo.addLevelEnrollment(levelEnrollment);
        }




        public async Task<List<AllMainCoursesResponse>> getAllCourses()
        {

            var allCourses = await _icourserepo.getAllCourses();

            var courseList = new List<AllMainCoursesResponse>();

            foreach (var course in allCourses)
            {
                var mainCourseResponse = new AllMainCoursesResponse
                {
                    CourseName = course.CourseName,
                    Thumbnail = course.CourseImages?.FirstOrDefault()?.Thumbnails,
                    Categories = new List<CategoryResponse>(),
                    CourseLevel = new List<CourseLevelsResponse>(),
                    

            };

               foreach(var categoryEnrollment in course.CategoryEnrollments)
                {
                    var categoryResponse = new CategoryResponse()
                    {
                       CategoryName = categoryEnrollment.Category.CategoryName
                    };
                    mainCourseResponse.Categories.Add(categoryResponse);
                    
                }

                foreach (var level in course.CourseLevels)
                {
                    var courseLevelResponse = new CourseLevelsResponse
                    {
                        CourseId = level.CourseId,
                        LevelName = level.LevelEnrollment?.Level?.LevelName,
                        CreatedDate = level.CreatedDate,
                        Duration = level.Duration,
                        CourseFee = level.CourseFee,
                        Description = level.Description,
                        InstructorResponses = new List<InstructorResponse>()
                    };

                    foreach (var instructorEnrollment in level.InstructorEnrollments)
                    {
                        if (instructorEnrollment.Instructor != null)
                        {
                            var instructorResponse = new InstructorResponse()
                            {
                                InstructorName = instructorEnrollment.Instructor.InstructorName
                            };
                            courseLevelResponse.InstructorResponses.Add(instructorResponse);
                        }
                    }

                    mainCourseResponse.CourseLevel.Add(courseLevelResponse);
                }

                courseList.Add(mainCourseResponse);
            }

            return courseList;
        }

        public async Task<List<InstructorForCourseResponse>> getInstructorForCourse()
        {
            var instructorList = new List<InstructorForCourseResponse>();

            var allInstructors = await _icourserepo.getInstructorForCourse();
            if(allInstructors != null)
            {
                foreach (var instructor in allInstructors)
                {
                    var singleInstructor = new InstructorForCourseResponse()
                    {
                        InstructorId = instructor.InstructorId,
                        InstructorName = instructor.InstructorName,
                        Avatar = instructor.Avatar
                    };
                    instructorList.Add(singleInstructor);
                }
            }
            return instructorList;
        }
    }
}
