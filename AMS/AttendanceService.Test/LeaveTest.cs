using AttendanceServices.Services.LeaveService;
using AttendanceServices.Services.LeaveService.Models.Request;
using AttendanceServices.Services.ShiftManagementService.Models;
using DA;
using DA.Models.DomainModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceService.Test
{
    public class LeaveTest
    {
        private Initializer initializer;
        private UnitOfWork unitOfWork;
        private LeaveService leaveService;

        [SetUp]
        public void Setup()
        {
            initializer = new Initializer();
            unitOfWork = new UnitOfWork(initializer._dbContext);
            leaveService = new LeaveService(unitOfWork);
        }
        [TestCase("LEV-011", "Sick Leave", "Dummy Data", 2,"anyfornow")]
        public void Should_Return_True_Leave_Is_Created(string code, string name, string description, int companyId, string userId)
        {
            // Arrange
            var requestAddLeave = new RequestAddLeave
            {
                Code = code,
                Name = name,
                Description = description,
                CompanyId = companyId
            };
            initializer.mockMapper.Setup(mapper => mapper.Map<RequestAddLeave, Leave>(It.IsAny<RequestAddLeave>())).
            Returns((RequestAddLeave src) => new Leave
            {
                Code = src.Code,
                Name = src.Name,
                Description = src.Description,
                CompanyId = src.CompanyId
            });

            //Act
            var result = leaveService.AddLeave(requestAddLeave, userId, initializer.token).Result;

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
