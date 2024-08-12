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
using AttendanceServices.Services.ShiftManagementService.Models.Request;
using DA.Models.RepoResultModels;
using DA.Repositories.CommonRepositories;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using AttendanceServices.Services.ShiftManagementService.Models.Response;
using AttendanceServices.Services.ShiftManagementService;
using System.Threading;
using System.Timers;

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

        [TestCase("WP-001", "Dummy Description", "Dummy Status" , 3, "08:00:00", "17:00:00", "anyForNow")]
        public void AddShift_Should_Return_True_When_Shift_Is_Created(string code, string description, string status, int numDays, string timeIn, string timeOut, string userId)
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
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            });

            //Act
            var result = shiftService.AddShift(requestAddShift, userId, initializer.token).Result;

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [TestCase("WP-001", "Dummy Description", "Dummy Status", 3, "08:00:00", "17:00:00", "anyForNow")]
        public void ListWithDetails_Should_Return_True_If_Created_Shift_Retrieved(string code, string description, string status, int numDays, string timeIn, string timeOut, string userId)
        {
            //Arrange
            RequestAddShift requestAddShift = new RequestAddShift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            };

            initializer.mockMapper.Setup(mapper => mapper.Map<RequestAddShift, Shift>(It.IsAny<RequestAddShift>())).
            Returns(new Shift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            });

            var result = shiftService.AddShift(requestAddShift, userId, initializer.token).Result;

            // Act
            var shifts = shiftService.ListWithDetails(CancellationToken.None).Result;

            // Assert
            var retrievedShift = shifts.FirstOrDefault(s => s.Code == code);
            Assert.That(code, Is.EqualTo(retrievedShift.Code));
        }

        [TestCase("WP-001", "Updated Description", "Updated Status", 4, "09:00:00", "18:00:00", "anyForNow")]
        public void UpdateShift_Should_Return_Response_When_Update_Succeeds(string code, string description, string status, int numDays, string timeIn, string timeOut, string userId)
        {
            // Arrange
            RequestAddShift requestAddShift = new RequestAddShift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            };

            initializer.mockMapper.Setup(mapper => mapper.Map<RequestAddShift, Shift>(It.IsAny<RequestAddShift>())).
            Returns(new Shift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            });

            var existingShift = shiftService.AddShift(requestAddShift, userId, initializer.token).Result;

            RequestUpdateShift updateRequest = new RequestUpdateShift
            {
                Code = "updatedCode",
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            };

            // Act
            var result = shiftService.UpdateShift(updateRequest, userId, initializer.token).Result;

            // Assert
            Assert.That(result.First().Code, Is.EqualTo(updateRequest.Code));
        }


        [TestCase("WP-001", "Dummy Description", "Dummy Status", 3, "08:00:00", "17:00:00", "anyForNow")]
        public void DeleteShift_Should_Return_Response_When_Delete_Succeeds(string code, string description, string status, int numDays, string timeIn, string timeOut, string userId)
        {
            // Arrange
            RequestAddShift requestAddShift = new RequestAddShift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            };

            initializer.mockMapper.Setup(mapper => mapper.Map<RequestAddShift, Shift>(It.IsAny<RequestAddShift>())).
            Returns(new Shift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            });

            var existingShift = shiftService.AddShift(requestAddShift, userId, initializer.token).Result;

            RequestDeleteShift deleteRequest = new RequestDeleteShift
            {
                Code = code
            };

            // Act
            var result = shiftService.DeleteShift(deleteRequest, userId, initializer.token).Result;

            // Assert
            Assert.That(result.First().Code, Is.EqualTo(deleteRequest.Code));
        }


        [TestCase("WP-001", "Dummy Description", "Dummy Status", 3, "08:00:00", "17:00:00", "anyForNow")]
        public void SingleWithDetails_Should_Return_ShiftDetails_When_ShiftExists(string code, string description, string status, int numDays, string timeIn, string timeOut, string userId)
        {
            //Arrange
            RequestAddShift requestAddShift = new RequestAddShift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            };

            initializer.mockMapper.Setup(mapper => mapper.Map<RequestAddShift, Shift>(It.IsAny<RequestAddShift>())).
            Returns(new Shift
            {
                Code = code,
                Description = description,
                Status = status,
                NumDays = numDays,
                TimeIn = TimeOnly.Parse(timeIn),
                TimeOut = TimeOnly.Parse(timeOut)
            });

            var result = shiftService.AddShift(requestAddShift, userId, initializer.token).Result;

            // Act
            var shift = shiftService.ListWithDetails(CancellationToken.None).Result;
            var retrievedShift = shift.FirstOrDefault(s => s.Code == code);

            // Assert
            Assert.That(code, Is.EqualTo(retrievedShift.Code));
        }
    }
}