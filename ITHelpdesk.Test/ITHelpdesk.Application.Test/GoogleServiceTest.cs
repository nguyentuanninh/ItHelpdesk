using ITHelpdesk.Application.Interfaces;
using ITHelpdesk.Application.Service;
using ITHelpdesk.Domain.Entities;
using ITHelpdesk.Infrastructure.UnitOfWork;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITHelpdesk.Test.ITHelpdesk.Application.Test
{
    [TestFixture]
    public class GoogleServiceTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private GoogleService _googleService;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _googleService = new GoogleService(_mockUnitOfWork.Object);
        }

        [Test]
        public async Task CreateGoogleAccountAsync_ShouldReturnCorrectEmail_WhenNoDuplicateExists()
        {
            // Arrange
            string fullName = "Nguyen Tuan Ninh";
            string expectedEmail = "ninh.nguyen@seta-international.vn";

            _mockUnitOfWork
                .Setup(s => s.Employee.FindAsync(It.IsAny<Expression<Func<Employee, bool>>>(), It.IsAny<bool>(), It.IsAny<string>()))
                .ReturnsAsync(new List<Employee>()); 

            // Act
            var result = await _googleService.CreateGoogleAccountAsync(fullName);

            // Assert
            ClassicAssert.AreEqual(expectedEmail, result, "error");
        }

        [Test]
        public async Task CreateGoogleAccountAsync_ShouldReturnEmailWithNumber_WhenDuplicateExists()
        {
            // Arrange
            string fullName = "Nguyen Tuan Ninh";
            string baseEmail = "ninh.nguyen@seta-international.vn";
            string expectedEmail = "ninh.nguyen01@seta-international.vn"; 

            var existingEmployees = new List<Employee>
            {
                new Employee { Email = baseEmail } 
            };

            _mockUnitOfWork
                .Setup(s => s.Employee.FindAsync(It.IsAny<Expression<Func<Employee, bool>>>(), It.IsAny<bool>(), It.IsAny<string>()))
                .ReturnsAsync(existingEmployees);

            // Act
            var result = await _googleService.CreateGoogleAccountAsync(fullName);

            // Assert
            ClassicAssert.AreEqual(expectedEmail, result);
        }

        [Test]
        public async Task CreateGoogleAccountAsync_ShouldReturnEmailWithIncrementingNumber_WhenMultipleDuplicatesExist()
        {
            // Arrange
            string fullName = "Nguyen Tuan Ninh";
            string expectedEmail = "ninh.nguyen03@seta-international.vn";

            var existingEmployees = new List<Employee>
            {
                new Employee { Email = "ninh.nguyen@seta-international.vn" },
                new Employee { Email = "ninh.nguyen01@seta-international.vn" },
                new Employee { Email = "ninh.nguyen02@seta-international.vn" }
            };

            _mockUnitOfWork
                .Setup(s => s.Employee.FindAsync(It.IsAny<Expression<Func<Employee, bool>>>(), It.IsAny<bool>(), It.IsAny<string>()))
                .ReturnsAsync(existingEmployees);

            // Act
            var result = await _googleService.CreateGoogleAccountAsync(fullName);

            // Assert
            ClassicAssert.AreEqual(expectedEmail, result);
        }

        [Test]
        public void CreateGoogleAccountAsync_ShouldThrowException_WhenFullNameIsEmpty()
        {
            // Arrange
            string fullName = "";

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _googleService.CreateGoogleAccountAsync(fullName));
            ClassicAssert.AreEqual("Full name cannot be empty. (Parameter 'fullName')", ex.Message);
        }

        [Test]
        public void CreateGoogleAccountAsync_ShouldThrowException_WhenFullNameIsSingleWord()
        {
            // Arrange
            string fullName = "Ninh";

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _googleService.CreateGoogleAccountAsync(fullName));
            ClassicAssert.AreEqual("Full name must contain at least first name and last name.", ex.Message);
        }

    }
}
