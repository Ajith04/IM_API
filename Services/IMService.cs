using ITEC_API.DTO.RequestDTO;
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
    }
}
