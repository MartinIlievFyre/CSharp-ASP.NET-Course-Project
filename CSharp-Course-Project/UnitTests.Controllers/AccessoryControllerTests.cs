namespace UnitTests.Controllers
{
    using Moq;
    using NUnit.Framework;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using GymApp.ViewModels;
    using GymApp.Controllers;
    using GymApp.Services.Data.Interfaces;
    using Xunit;
    using System;
    using System.Collections.Generic;
    using static GymApp.Common.ExceptionMessages;

    [TestFixture]
    public class AccessoryControllerTests
    {
        private HomeController _homeController;

        [OneTimeSetUp]
        public void SetUp()
        {
            _homeController = new HomeController();
        }
        [Test]
        public async Task Accessories_ValidData_ReturnsViewWithViewModels()
        {
            // Arrange
            var accessoryServiceMock = new Mock<IAccessoryService>();
            var controller = new AccessoryController(accessoryServiceMock.Object);

            var accessoryViewModels = new List<AccessoryViewModel>
            {
                new AccessoryViewModel {
                 Id = 1,
                 Name = "Test",
                 Manufacturer = "Test",
                 Price = 9.99m,
                 Description = "Test",
                 Benefits = "Test",
                 ImageUrl = "Test",
                 Type = "Test"
                },
                new AccessoryViewModel {
                 Id = 2,
                 Name = "Test2",
                 Manufacturer = "Test2",
                 Price = 9.99m,
                 Description = "Test2",
                 Benefits = "Test2",
                 ImageUrl = "Test2",
                 Type = "Test2"
                }
            };

            accessoryServiceMock.Setup(service => service.AllAccessoriesAsync()).ReturnsAsync(accessoryViewModels);

            // Act
            var result = await controller.Accessories();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(accessoryViewModels, viewResult.Model);

        }
    }
}
