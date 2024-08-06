using AttendanceServices.Services.WorkingProfileService.Models.Request;
using AttendanceServices.Services.WorkingProfileService;
using DA.Models.DomainModels;
using DA;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceServices.Services.ShiftManagementService.Models;
using AttendanceServices.Services.ShiftManagementService.Models.Request;
using DA.Models.RepoResultModels;
using DA.Repositories.CommonRepositories;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AttendanceService.Test
{
    public class ShiftTest
    {
        private Initializer initializer;
        private ShiftService shiftService;
        private UnitOfWork unitOfWork;
        [SetUp]
        public void Setup()
        {
            initializer = new Initializer();
            unitOfWork = new UnitOfWork(initializer._dbContext);
            shiftService = new ShiftService(unitOfWork);
        }

        [TestCase("WP-001", "Dummy Description", "Dummy Status" , 3, "2024-08-02T08:00:00", "2024-08-02T17:00:00", "anyForNow")]
        public void Should_Return_True_When_Shift_Is_Created(string code, string description, string status, int numDays, string timeIn, string timeOut, string userId)
        {
            //Arrange
            RequestAddShift requestAddShift = new RequestAddShift();

            initializer.mockMapper.Setup(mapper => mapper.Map<RequestAddShift, Shift>(It.IsAny<RequestAddShift>())).
            Returns(new Shift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = DateTime.Parse(timeIn),
                TimeOut = DateTime.Parse(timeOut)
            });

            //Act
            var result = shiftService.AddShift(requestAddShift, userId, initializer.token).Result;

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [TestCase("WP-001", "Dummy Description", "Dummy Status", 3, "2024-08-02T08:00:00", "2024-08-02T17:00:00", "anyForNow")]
        public void Should_Return_True_If_Created_Shift_Retrieved(string code, string description, string status, int numDays, string timeIn, string timeOut, string userId)
        {
            //Arrange
            RequestAddShift requestAddShift = new RequestAddShift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = DateTime.Parse(timeIn),
                TimeOut = DateTime.Parse(timeOut)
            };

            initializer.mockMapper.Setup(mapper => mapper.Map<RequestAddShift, Shift>(It.IsAny<RequestAddShift>())).
            Returns(new Shift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = DateTime.Parse(timeIn),
                TimeOut = DateTime.Parse(timeOut)
            });

            var result = shiftService.AddShift(requestAddShift, userId, initializer.token).Result;

            // Act
            var shifts = shiftService.ListWithDetails(CancellationToken.None).Result;

            // Assert
            var retrievedShift = shifts.FirstOrDefault(s => s.Code == code);
            Assert.That(code, Is.EqualTo(retrievedShift.Code));
        }

        [Test]
        public async Task Should_Return_Response_When_Update_Succeeds()
        {
            // Arrange
            var request = new RequestUpdateShift
            {
                Code = "SH-001",
                Description = "Updated Description",
                Status = "Updated Status"
            };
            var userId = "anyUserId";

            Expression<Func<Shift, bool>> filter = x => x.IsActive && x.Code == request.Code;
            Expression<Func<SetPropertyCalls<Shift>, SetPropertyCalls<Shift>>> setPropertyCalls = x => x
                .SetProperty(s => s.Description, request.Description ?? AttendanceServices.EnumsAndConstants.Constant.KConstantCommon.UseNA)
                .SetProperty(s => s.Status, request.Status ?? AttendanceServices.EnumsAndConstants.Constant.KConstantCommon.UseNA)
                .SetProperty(s => s.UpdatedBy, userId)
                .SetProperty(s => s.UpdatedDate, DateTime.Now);

            var mockShiftRepo = new Mock<IGenericRepository<Shift, string>>();
            mockShiftRepo.Setup(repo => repo.UpdateOnConditionAsync(
                It.IsAny<Expression<Func<Shift, bool>>>(),
                It.IsAny<Expression<Func<SetPropertyCalls<Shift>, SetPropertyCalls<Shift>>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SetterResult { Message = "Success", Result = true, IsException = false });

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.shiftRepo).Returns(mockShiftRepo.Object);
            var shiftService = new ShiftService(mockUnitOfWork.Object);

            // Act
            var result = await shiftService.UpdateShift(request, userId, CancellationToken.None);

            // Assert
            Assert.That(result.First().Code, Is.EqualTo(request.Code));
        }

        [Test]
        public async Task DeleteShift_Should_Return_Response_When_Delete_Succeeds()
        {
            // Arrange
            var request = new RequestDeleteShift
            {
                Code = "SH-001"
            };
            var userId = "anyUserId";

            var shift = new Shift
            {
                Code = request.Code,
                IsActive = true
            };

            var mockShiftRepo = new Mock<IGenericRepository<Shift, string>>();
            mockShiftRepo.Setup(repo => repo.GetSingleAsync(
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<Shift, bool>>>(),
                It.IsAny<string>() // Explicitly include the optional parameter with a default value
            )).ReturnsAsync(new GetterResult<Shift> { Data = shift, Status = true });

            mockShiftRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Shift>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new SetterResult { Result = true, Message = "Success", IsException = false });

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.shiftRepo).Returns(mockShiftRepo.Object);
            var shiftService = new ShiftService(mockUnitOfWork.Object);

            // Act
            var result = await shiftService.DeleteShift(request, userId, CancellationToken.None);

            // Assert
            Assert.That(result.First().Code, Is.EqualTo(request.Code));
        }


    }
}