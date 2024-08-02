using AttendanceServices.Services.WorkingProfileService;
using AttendanceServices.Services.WorkingProfileService.Models.Request;
using DA;
using DA.Models.DomainModels;
using Moq;

namespace AttendanceService.Test
{
    public class WorkingProfileTest
    {
        private Initializer initializer;
        private WorkingProfileService workingProfileService;
        private UnitOfWork unitOfWork;
        [SetUp]
        public void Setup()
        {
            initializer = new Initializer();
            unitOfWork = new UnitOfWork(initializer._dbContext);
            workingProfileService = new WorkingProfileService(unitOfWork, initializer.mapper);
        }

        [TestCase("WP-001", "Working Profile for employees in morning shift", 30, 0, 26, 8, "1", "anyForNow")]
        public void Should_Return_True_When_Working_Profile_Is_Created(string code, string description, int GraceTimeIn, int GraceTimeOut, int WorkingDays, int WorkingHours, string FiscalYearId, string userId)
        {
            //Arrange
            CreateWorkingProfileRequest workingProfileRequest = new CreateWorkingProfileRequest();

            initializer.mockMapper.Setup(mapper => mapper.Map<CreateWorkingProfileRequest, WorkingProfile>(It.IsAny<CreateWorkingProfileRequest>())).
            Returns(new WorkingProfile
            {
                Code = code,
                Description = description,
                GraceTimeIn = GraceTimeIn,
                GraceTimeOut = GraceTimeOut,
                WorkingHours = WorkingHours,
                WorkingDays = WorkingDays,
                FiscalYearId = FiscalYearId
            });

            //Act
            var result = workingProfileService.AddWorkingProfile(workingProfileRequest, userId, initializer.token).Result;

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }
    }
}