﻿using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Models.CourseModels;
using ITEC_API.Models.PaymentModels;

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
                InstructorKnowCourses = new List<InstructorKnowCourses>(),
                DateOfJoin = instructorRequest.DateOfJoin,
                Mobile = instructorRequest.Mobile,
                Email = instructorRequest.Email

             
            };

            if(instructorRequest.CourseNames != null) 
            {
                foreach (var singleCourseName in instructorRequest.CourseNames)
                {
                    var singleRecord = await _iimrepo.getRecordByCourseName(singleCourseName);

                    if (singleRecord != null)
                    {
                        instructor.InstructorKnowCourses.Add(new InstructorKnowCourses
                        {
                            CourseNameId = singleRecord.Id
                        });
                    }
                }
            }

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
                        InstructorId = instructor.InstructorId,
                        InstructorName = instructor.InstructorName,
                        Description = instructor.Description,
                        Avatar = instructor.Avatar,
                        DateOfJoin = instructor.DateOfJoin,
                        Mobile = instructor.Mobile,
                        Email = instructor.Email,
                        instructorKnowCourseResponses = new List<InstructorKnowCourseResponse>(),
                        instructorAssignedCourseResponses = new List<InstructorAssignedCourseResponse>(),
                        
                    };

                    foreach(var instructorKnowCourse in instructor.InstructorKnowCourses)
                    {
                        singleInstructor.instructorKnowCourseResponses.Add(new InstructorKnowCourseResponse
                        {
                            name = instructorKnowCourse.CourseName.Name
                        });
                    }

                    foreach( var instructorAssignedCourse in instructor.InstructorEnrollments)
                    {
                        singleInstructor.instructorAssignedCourseResponses.Add(new InstructorAssignedCourseResponse
                        {
                            CourseName = $"{instructorAssignedCourse.CourseLevel.MainCourse.CourseName}" + " - " + $"{instructorAssignedCourse.CourseLevel.LevelEnrollment.Level.LevelName}"
                        });
                    }
                    instructorList.Add(singleInstructor);
                }
            }
            return instructorList;
        }

        public async Task addCourseName(CourseNameRequest courseNameRequest)
        {
            var courseName = new CourseName()
            {
                Name = courseNameRequest.Name,
            };

            await _iimrepo.addCourseName(courseName);
        }

        public async Task addNewCategory(CategoryNameRequest categoryNameRequest)
        {
            var category = new Category()
            {
                CategoryName = categoryNameRequest.CategoryName,
            };

            await _iimrepo.addNewCategory(category);
        }

        public async Task<List<CategoryNameRequest>> getAllCategories()
        {
            var categoryList = new List<CategoryNameRequest>();

            var allCategories = await _iimrepo.getAllCategories();
            
            foreach (var category in allCategories)
            {
                var singleCategory = new CategoryNameRequest()
                {
                    CategoryName = category.CategoryName
                };
                categoryList.Add(singleCategory);
            }
            return categoryList;
        }

        public async Task addNewLevel(LevelNameRequest levelNameRequest)
        {
            var level = new Level()
            {
                LevelName = levelNameRequest.LevelName,
            };

            await _iimrepo.addNewLevel(level);
        }

        public async Task<List<LevelNameRequest>> getAllLevels()
        {
            var levelList = new List<LevelNameRequest>();

            var allLevels = await _iimrepo.getAllLevels();

            foreach (var level in allLevels)
            {
                var singleLevel = new LevelNameRequest()
                {
                    LevelName = level.LevelName
                };
                levelList.Add(singleLevel);
            }
            return levelList;
        }

        public async Task addNewBatch(BatchNameRequest batchNameRequest)
        {
            var batch = new Batch()
            {
                BatchName = batchNameRequest.BatchName,
            };

            await _iimrepo.addNewBatch(batch);
        }

        public async Task<List<BatchNameRequest>> getAllBatches()
        {
            var batchList = new List<BatchNameRequest>();

            var allBatches = await _iimrepo.getAllBatches();

            foreach (var batch in allBatches)
            {
                var singleBatch = new BatchNameRequest()
                {
                    BatchName = batch.BatchName,
                };
                batchList.Add(singleBatch);
            }
            return batchList;
        }

        public async Task addExpense(ExpenseRequest expenseRequest)
        {
            var expense = new Expense()
            {
                Title = expenseRequest.Title,
                Date = expenseRequest.Date,
                Amount = expenseRequest.Amount,
                ExpenseReceipts =  new List<ExpenseReceipt>(),
                Description = expenseRequest.Description,
            };

            if(expenseRequest.Receipt != null)
            {
                foreach(var singleExpenseReceipt in expenseRequest.Receipt)
                {
                    using(var memoryStream = new MemoryStream())
                    {
                        await singleExpenseReceipt.CopyToAsync(memoryStream);
                        expense.ExpenseReceipts.Add(new ExpenseReceipt
                        {
                            Receipt = memoryStream.ToArray(),
                        });
                    }
                }
            }

            await _iimrepo.addExpense(expense);
        }

        public async Task<List<ExpenseResponse>> getAllExpenses()
        {
            var expenseList = new List<ExpenseResponse>();

            var allExpenses = await _iimrepo.getAllExpenses();

            foreach(var expense in allExpenses)
            {
                var singleExpense = new ExpenseResponse()
                {
                    Title= expense.Title,
                    Date = expense.Date,
                    Amount = expense.Amount,
                    Receipts = new List<ExpenseReceiptResponse>(),
                    Description = expense.Description,
                };

                if(expense.ExpenseReceipts != null)
                {
                    foreach (var singleExpenseReceipt in expense.ExpenseReceipts)
                    {
                        singleExpense.Receipts.Add(new ExpenseReceiptResponse
                        {
                            Receipt = singleExpenseReceipt.Receipt
                        });
                    }
                }
                expenseList.Add(singleExpense);
            }
            return expenseList;
        }

        public async Task<decimal> getRegFee()
        {
            var regFeeRecord = await _iimrepo.getRegFee();
            var regFee = regFeeRecord.RegFee;
            return regFee;
        }

        public async Task changeRegFee(ChangeRegFee changeRegFee)
        {
            var regFeeRecord = await _iimrepo.getRegFee();
            regFeeRecord.RegFee = changeRegFee.NewRegFee;

            await _iimrepo.changeRegFee(regFeeRecord);
        }

        public async Task removeInstructor(int instructorId)
        {
            await _iimrepo.removeInstructor(instructorId);
        }

        public async Task<AllInstructorResponse> getSingleInstructor(int instructorId)
        {
            var singleInstructor = await _iimrepo.getSingleInstructor(instructorId);

            
                var instructorResponse = new AllInstructorResponse()
                {
                    InstructorId = singleInstructor.InstructorId,
                    InstructorName = singleInstructor.InstructorName,
                    Description = singleInstructor.Description,
                    Avatar = singleInstructor.Avatar,
                    DateOfJoin = singleInstructor.DateOfJoin,
                    Mobile = singleInstructor.Mobile,
                    Email = singleInstructor.Email,
                    instructorKnowCourseResponses = new List<InstructorKnowCourseResponse>(),
                    instructorAssignedCourseResponses = new List<InstructorAssignedCourseResponse>()

                };

                if(singleInstructor.InstructorKnowCourses != null)
                {
                    foreach(var instructorKnowCourse in singleInstructor.InstructorKnowCourses)
                    {
                        instructorResponse.instructorKnowCourseResponses.Add(new InstructorKnowCourseResponse()
                        {
                            name = instructorKnowCourse.CourseName.Name
                        });
                    }
                }

                if (singleInstructor.InstructorEnrollments != null)
                {
                    foreach (var instructorAssignedCourse in singleInstructor.InstructorEnrollments)
                    {
                        instructorResponse.instructorAssignedCourseResponses.Add(new InstructorAssignedCourseResponse()
                        {
                            CourseName = $"{instructorAssignedCourse.CourseLevel.MainCourse.CourseName}" + " - " + $"{instructorAssignedCourse.CourseLevel.LevelEnrollment.Level.LevelName}"
                        });
                    }
                }

            return instructorResponse;

        }

        public async Task updateInstructor(int instructorId, UpdateInstructorRequest updateInstructorRequest)
        {
            var singleInstructor = await _iimrepo.findSingleInstructor(instructorId);

            if (updateInstructorRequest.Avatar != null)
            {
                singleInstructor.Description = updateInstructorRequest.Description;
                singleInstructor.Mobile = updateInstructorRequest.Mobile;
                singleInstructor.Email = updateInstructorRequest.Email;
                singleInstructor.InstructorKnowCourses = new List<InstructorKnowCourses>();


                foreach (var singleCourseName in updateInstructorRequest.KnownCourses)
                {
                    var singleCourse = await _iimrepo.getRecordByCourseName(singleCourseName);
                    if(singleCourse != null){
                        singleInstructor.InstructorKnowCourses.Add(new InstructorKnowCourses()
                        {
                            CourseNameId = singleCourse.Id,
                        });
                    }
                }

                using (var memoryStream = new MemoryStream())
                {
                    await updateInstructorRequest.Avatar.CopyToAsync(memoryStream);
                    singleInstructor.Avatar = memoryStream.ToArray();
                }

                await _iimrepo.deleteInstructorKnowCourses(instructorId);
                await _iimrepo.updateInstructor(singleInstructor);
            }
            else
            {
                singleInstructor.Description = updateInstructorRequest.Description;
                singleInstructor.Mobile = updateInstructorRequest.Mobile;
                singleInstructor.Email = updateInstructorRequest.Email;
                singleInstructor.InstructorKnowCourses = new List<InstructorKnowCourses>();


                foreach (var singleCourseName in updateInstructorRequest.KnownCourses)
                {
                    var singleCourse = await _iimrepo.getRecordByCourseName(singleCourseName);
                    if (singleCourse != null)
                    {
                        singleInstructor.InstructorKnowCourses.Add(new InstructorKnowCourses()
                        {
                            CourseNameId = singleCourse.Id,
                        });
                    }
                }


                await _iimrepo.deleteInstructorKnowCourses(instructorId);
                await _iimrepo.updateInstructor(singleInstructor);
            }

            
            
        }
    }
}
