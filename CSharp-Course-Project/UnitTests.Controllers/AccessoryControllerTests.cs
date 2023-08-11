using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymApp.Controllers;
using GymApp.Services.Data.Interfaces;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.ContentModel;
using NUnit.Framework;

namespace UnitTests.Controllers
{
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

        [Test]
        public async Task Accessories_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var accessoryServiceMock = new Mock<IAccessoryService>();
            var controller = new AccessoryController(accessoryServiceMock.Object);

            var errorMessage = "Sample error message";
            accessoryServiceMock.Setup(service => service.AllAccessoriesAsync()).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.Accessories();

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
            Assert.AreEqual("Home", redirectToActionResult.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }
    }
}
