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
        public void Should_Return_True_When_Working_Profile_Is_Created(string code, string description, string status, int numDays, string timeIn, string timeOut, string userId)
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
    }
}