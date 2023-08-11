using System;
using GymApp.Controllers;
using GymApp.Data.Models;
using GymApp.Services.Data.Interfaces;
using GymApp.ViewModels;
using GymApp.ViewModels.Accessory;
using GymApp.ViewModels.Clothing;
using GymApp.ViewModels.Supplement;
using GymApp.ViewModels.WearCategory;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

using static GymApp.Common.NotificationMessagesConstants;

namespace UnitTests.Controllers
{
    [TestFixture]
    public class AdminControllerTests
    {
        private HomeController? _homeController;

        [OneTimeSetUp]
        public void SetUp()
        {
            _homeController = new HomeController();
        }
        //AddAccessory - GET
        [Test]
        public void AddAccessory_ValidData_ReturnsViewWithModel()
        {
            // Arrange
            var categoryServiceMock = new Mock<ICategoryService>();
            var adminServiceMock = new Mock<IAdminService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var addAccessoryViewModel = new AddAccessoryViewModel
            {
                // Initialize properties if needed
            };

            adminServiceMock.Setup(service => service.CreateAddAccessoryViewModel()).Returns(addAccessoryViewModel);

            // Act
            var result = controller.AddAccessory();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(addAccessoryViewModel, viewResult?.Model);
        }

        [Test]
        public void AddAccessory_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var categoryServiceMock = new Mock<ICategoryService>();
            var adminServiceMock = new Mock<IAdminService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.CreateAddAccessoryViewModel()).Throws(new ArgumentException(errorMessage));

            // Act
            var result = controller.AddAccessory();

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //AddAccessory - POST
        [Test]
        public async Task AddAccessory_ValidModel_RedirectsToAccessories()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new AddAccessoryViewModel
            {
                // Initialize valid model properties
            };

            adminServiceMock.Setup(service => service.CreateAccessoryAsync(It.IsAny<AddAccessoryViewModel>())).ReturnsAsync(new Accessory());

            // Act
            var result = await controller.AddAccessory(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Accessories", redirectToActionResult?.ActionName);
            Assert.AreEqual("Accessory", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully created accessory.", tempData["Success"]);
        }

        [Test]
        public async Task AddAccessory_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var invalidModel = new AddAccessoryViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.AddAccessory(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.CreateAccessoryAsync(It.IsAny<AddAccessoryViewModel>()), Times.Never);
        }

        [Test]
        public async Task AddAccessory_ThrowsArgumentException_RedirectsToAdminAddAccessoryWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.CreateAccessoryAsync(It.IsAny<AddAccessoryViewModel>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new AddAccessoryViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.AddAccessory(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("AddAccessory", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }
        //EditAccessory - GET
        [Test]
        public async Task EditAccessory_ValidId_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int accessoryId = 1;
            var accessory = new Accessory { Id = accessoryId };
            var editAccessoryViewModel = new EditAccessoryViewModel
            {
                // Initialize properties if needed
            };

            adminServiceMock.Setup(service => service.GetAccessoryByIdAsync(accessoryId)).ReturnsAsync(accessory);
            adminServiceMock.Setup(service => service.CreateEditAccessoryViewModel(accessory)).Returns(editAccessoryViewModel);

            // Act
            var result = await controller.EditAccessory(accessoryId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(editAccessoryViewModel, viewResult.Model);
        }

        [Test]
        public async Task EditAccessory_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int accessoryId = 1;
            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetAccessoryByIdAsync(accessoryId)).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.EditAccessory(accessoryId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //EditAccessory - POST
        [Test]
        public async Task EditAccessory_ValidModel_RedirectsToAccessories()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new EditAccessoryViewModel
            {
                // Initialize properties if needed
            };

            var accessory = new Accessory { Id = validModel.Id };

            adminServiceMock.Setup(service => service.GetAccessoryByIdAsync(validModel.Id)).ReturnsAsync(accessory);

            // Act
            var result = await controller.EditAccessory(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Accessories", redirectToActionResult?.ActionName);
            Assert.AreEqual("Accessory", redirectToActionResult.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully edited accessory.", tempData["Success"]);
        }

        [Test]
        public async Task EditAccessory_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var invalidModel = new EditAccessoryViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.EditAccessory(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.GetAccessoryByIdAsync(It.IsAny<int>()), Times.Never);
            adminServiceMock.Verify(service => service.EditingInformationAboutAccessoryAsync(It.IsAny<Accessory>(), It.IsAny<EditAccessoryViewModel>()), Times.Never);
        }

        [Test]
        public async Task EditAccessory_ThrowsArgumentException_RedirectsToAdminEditAccessoryWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetAccessoryByIdAsync(It.IsAny<int>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new EditAccessoryViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.EditAccessory(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("EditAccessory", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //DeleteAccessory
        [Test]
        public async Task DeleteAccessory_ValidId_RedirectsToAccessories()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int accessoryId = 1;
            var accessory = new Accessory { Id = accessoryId };

            adminServiceMock.Setup(service => service.GetAccessoryByIdAsync(accessoryId)).ReturnsAsync(accessory);

            // Act
            var result = await controller.DeleteAccessory(accessoryId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Accessories", redirectToActionResult?.ActionName);
            Assert.AreEqual("Accessory", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual("Successfully deleted accessory.", tempData["Error"]);

            adminServiceMock.Verify(service => service.DeleteAccessoryAsync(accessory), Times.Once);
        }

        [Test]
        public async Task DeleteAccessory_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int accessoryId = 1;
            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetAccessoryByIdAsync(accessoryId)).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.DeleteAccessory(accessoryId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //AddSupplement - GET
        [Test]
        public void AddSupplement_ValidData_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var addSupplementViewModel = new AddSupplementViewModel
            {
                // Initialize properties if needed
            };

            adminServiceMock.Setup(service => service.CreateAddSupplementViewModel()).Returns(addSupplementViewModel);

            // Act
            var result = controller.AddSupplement();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(addSupplementViewModel, viewResult?.Model);
        }

        [Test]
        public void AddSupplement_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.CreateAddSupplementViewModel()).Throws(new ArgumentException(errorMessage));

            // Act
            var result = controller.AddSupplement();

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //AddSupplement - POST
        [Test]
        public async Task AddSupplement_ValidModel_RedirectsToSupplements()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new AddSupplementViewModel
            {
                // Initialize valid model properties
            };

            adminServiceMock.Setup(service => service.CreateSupplementAsync(It.IsAny<AddSupplementViewModel>())).ReturnsAsync(new Supplement());

            // Act
            var result = await controller.AddSupplement(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Supplements", redirectToActionResult?.ActionName);
            Assert.AreEqual("Supplement", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully created supplement.", tempData["Success"]);
        }

        [Test]
        public async Task AddSupplement_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var invalidModel = new AddSupplementViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.AddSupplement(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.CreateSupplementAsync(It.IsAny<AddSupplementViewModel>()), Times.Never);
        }

        [Test]
        public async Task AddSupplement_ThrowsArgumentException_RedirectsToAdminAddSupplementWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.CreateSupplementAsync(It.IsAny<AddSupplementViewModel>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new AddSupplementViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.AddSupplement(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("AddSupplement", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //EditSupplement - GET
        [Test]
        public async Task EditSupplement_ValidId_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int supplementId = 1;
            var supplement = new Supplement { Id = supplementId };
            var editSupplementViewModel = new EditSupplementViewModel
            {
                // Initialize properties if needed
            };

            adminServiceMock.Setup(service => service.GetSupplementByIdAsync(supplementId)).ReturnsAsync(supplement);
            adminServiceMock.Setup(service => service.CreateEditSupplementViewModel(supplement)).Returns(editSupplementViewModel);

            // Act
            var result = await controller.EditSupplement(supplementId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(editSupplementViewModel, viewResult?.Model);
        }

        [Test]
        public async Task EditSupplement_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int supplementId = 1;
            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetSupplementByIdAsync(supplementId)).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.EditSupplement(supplementId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }
        
        //EditSupplement - POST
        [Test]
        public async Task EditSupplement_ValidModel_RedirectsToSupplements()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new EditSupplementViewModel
            {
                // Initialize valid model properties
            };

            var supplement = new Supplement { Id = validModel.Id };

            adminServiceMock.Setup(service => service.GetSupplementByIdAsync(validModel.Id)).ReturnsAsync(supplement);

            // Act
            var result = await controller.EditSupplement(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Supplements", redirectToActionResult?.ActionName);
            Assert.AreEqual("Supplement", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully edited supplement.", tempData["Success"]);

            adminServiceMock.Verify(service => service.EditingInformationAboutSupplementAsync(supplement, validModel), Times.Once);
        }

        [Test]
        public async Task EditSupplement_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var invalidModel = new EditSupplementViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.EditSupplement(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.GetSupplementByIdAsync(It.IsAny<int>()), Times.Never);
            adminServiceMock.Verify(service => service.EditingInformationAboutSupplementAsync(It.IsAny<Supplement>(), It.IsAny<EditSupplementViewModel>()), Times.Never);
        }

        [Test]
        public async Task EditSupplement_ThrowsArgumentException_RedirectsToAdminEditSupplementWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetSupplementByIdAsync(It.IsAny<int>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new EditSupplementViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.EditSupplement(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("EditSupplement", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //DeleteSupplement
        [Test]
        public async Task DeleteSupplement_ValidId_RedirectsToSupplements()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int supplementId = 1;
            var supplement = new Supplement { Id = supplementId };

            adminServiceMock.Setup(service => service.GetSupplementByIdAsync(supplementId)).ReturnsAsync(supplement);

            // Act
            var result = await controller.DeleteSupplement(supplementId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Supplements", redirectToActionResult?.ActionName);
            Assert.AreEqual("Supplement", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual("Successfully deleted supplement.", tempData["Error"]);

            adminServiceMock.Verify(service => service.DeleteSupplementAsync(supplement), Times.Once);
        }

        [Test]
        public async Task DeleteSupplement_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int supplementId = 1;
            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetSupplementByIdAsync(supplementId)).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.DeleteSupplement(supplementId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //AddWear - GET
        [Test]
        public async Task AddWear_ValidData_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var wearCategories = new List<WearCategoryViewModel>
            {
                new WearCategoryViewModel { Id = 1, Name = "Category1" },
                new WearCategoryViewModel { Id = 2, Name = "Category2" }
            };

            categoryServiceMock.Setup(service => service.AllWearCategoriesAsync()).ReturnsAsync(wearCategories);

            var addWearViewModel = new AddWearViewModel
            {
                // Initialize properties if needed
            };

            adminServiceMock.Setup(service => service.CreateAddWearViewModel(wearCategories)).Returns(addWearViewModel);

            // Act
            var result = await controller.AddWear();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(addWearViewModel, viewResult.Model);
        }

        [Test]
        public async Task AddWear_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            categoryServiceMock.Setup(service => service.AllWearCategoriesAsync()).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.AddWear();

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //AddWear - POST
        [Test]
        public async Task AddWear_ValidModel_RedirectsToClothes()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new AddWearViewModel
            {
                // Initialize valid model properties
            };

            var wear = new Wear();

            adminServiceMock.Setup(service => service.CreateWearAsync(validModel)).ReturnsAsync(wear);

            // Act
            var result = await controller.AddWear(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Clothes", redirectToActionResult?.ActionName);
            Assert.AreEqual("Clothing", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully created clothing.", tempData["Success"]);

            adminServiceMock.Verify(service => service.CreateWearAsync(validModel), Times.Once);
        }

        [Test]
        public async Task AddWear_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var invalidModel = new AddWearViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.AddWear(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.CreateWearAsync(It.IsAny<AddWearViewModel>()), Times.Never);
        }

        [Test]
        public async Task AddWear_ThrowsArgumentException_RedirectsToAdminAddWearWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.CreateWearAsync(It.IsAny<AddWearViewModel>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new AddWearViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.AddWear(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("AddWear", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //EditWear - GET
        [Test]
        public async Task EditWear_ValidId_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int wearId = 1;
            var wearCategories = new List<WearCategoryViewModel>
            {
                new WearCategoryViewModel { Id = 1, Name = "Category1" },
                new WearCategoryViewModel { Id = 2, Name = "Category2" }
            };
            var wear = new Wear { Id = wearId };

            categoryServiceMock.Setup(service => service.AllWearCategoriesAsync()).ReturnsAsync(wearCategories);
            adminServiceMock.Setup(service => service.GetWearByIdAsync(wearId)).ReturnsAsync(wear);

            var editWearViewModel = new EditWearViewModel
            {
                // Initialize properties if needed
            };

            adminServiceMock.Setup(service => service.CreateEditWearViewModel(wear, wearCategories)).Returns(editWearViewModel);

            // Act
            var result = await controller.EditWear(wearId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(editWearViewModel, viewResult?.Model);
        }

        [Test]
        public async Task EditWear_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int wearId = 1;
            var errorMessage = "Sample error message";
            categoryServiceMock.Setup(service => service.AllWearCategoriesAsync()).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.EditWear(wearId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //EditWear - POST
        [Test]
        public async Task EditWear_ValidModel_RedirectsToGetClothing()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new EditWearViewModel
            {
                // Initialize valid model properties
            };

            int categoryId = 1;
            var categories = new List<WearCategoryViewModel>
            {
                new WearCategoryViewModel { Id = categoryId, Name = "Category1" },
                new WearCategoryViewModel { Id = 2, Name = "Category2" }
            };
            var wear = new Wear { Id = validModel.Id, WearCategoryId = categoryId };

            categoryServiceMock.Setup(service => service.AllWearCategoriesAsync()).ReturnsAsync(categories);
            adminServiceMock.Setup(service => service.GetWearByIdAsync(validModel.Id)).ReturnsAsync(wear);

            // Act
            var result = await controller.EditWear(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("GetClothing", redirectToActionResult?.ActionName);
            Assert.AreEqual("Clothing", redirectToActionResult?.ControllerName);
            Assert.AreEqual(categoryId, redirectToActionResult?.RouteValues?["id"]);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully edited wear.", tempData["Success"]);

            adminServiceMock.Verify(service => service.EditingInformationAboutWearAsync(wear, validModel), Times.Once);
        }

        [Test]
        public async Task EditWear_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var invalidModel = new EditWearViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.EditWear(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.GetWearByIdAsync(It.IsAny<int>()), Times.Never);
            adminServiceMock.Verify(service => service.EditingInformationAboutWearAsync(It.IsAny<Wear>(), It.IsAny<EditWearViewModel>()), Times.Never);
        }

        [Test]
        public async Task EditWear_ThrowsArgumentException_RedirectsToAdminEditWearWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetWearByIdAsync(It.IsAny<int>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new EditWearViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.EditWear(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("EditWear", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //DeleteWear
        [Test]
        public async Task DeleteWear_ValidId_RedirectsToClothes()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int wearId = 1;
            var wear = new Wear { Id = wearId };

            adminServiceMock.Setup(service => service.GetWearByIdAsync(wearId)).ReturnsAsync(wear);

            // Act
            var result = await controller.DeleteWear(wearId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Clothes", redirectToActionResult?.ActionName);
            Assert.AreEqual("Clothing", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual("Successfully deleted wear.", tempData["Error"]);

            adminServiceMock.Verify(service => service.DeleteWearAsync(wear), Times.Once);
        }

        [Test]
        public async Task DeleteWear_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int wearId = 1;
            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetWearByIdAsync(wearId)).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.DeleteWear(wearId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //AddExercise - GET
        [Test]
        public async Task AddExercise_ValidData_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = 1, Name = "Category1" },
                new CategoryViewModel { Id = 2, Name = "Category2" }
            };

            categoryServiceMock.Setup(service => service.AllCategoriesAsync()).ReturnsAsync(categories);

            var addExerciseViewModel = new AddExerciseViewModel
            {
                // Initialize properties if needed
            };

            adminServiceMock.Setup(service => service.CreateAddExerciseViewModel(categories)).Returns(addExerciseViewModel);

            // Act
            var result = await controller.AddExercise();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(addExerciseViewModel, viewResult?.Model);
        }

        [Test]
        public async Task AddExercise_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            categoryServiceMock.Setup(service => service.AllCategoriesAsync()).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.AddExercise();

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //AddExercise - POST
        [Test]
        public async Task AddExercise_ValidModel_RedirectsToExercises()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new AddExerciseViewModel
            {
                // Initialize valid model properties
            };

            var exercise = new Exercise
            {
                // Initialize exercise properties based on model
            };

            adminServiceMock.Setup(service => service.CreateExerciseAsync(validModel)).ReturnsAsync(exercise);

            // Act
            var result = await controller.AddExercise(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Exercises", redirectToActionResult?.ActionName);
            Assert.AreEqual("Gym", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully created exercise.", tempData["Success"]);

            adminServiceMock.Verify(service => service.CreateExerciseAsync(validModel), Times.Once);
        }

        [Test]
        public async Task AddExercise_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var invalidModel = new AddExerciseViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.AddExercise(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.CreateExerciseAsync(It.IsAny<AddExerciseViewModel>()), Times.Never);
        }

        [Test]
        public async Task AddExercise_ThrowsArgumentException_RedirectsToAddExerciseWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.CreateExerciseAsync(It.IsAny<AddExerciseViewModel>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new AddExerciseViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.AddExercise(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("AddExercise", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //EditExercise - GET
        [Test]
        public async Task EditExercise_ValidId_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int exerciseId = 1;
            var categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = 1, Name = "Category1" },
                new CategoryViewModel { Id = 2, Name = "Category2" }
            };

            categoryServiceMock.Setup(service => service.AllCategoriesAsync()).ReturnsAsync(categories);

            var exercise = new Exercise
            {
                Id = exerciseId,
                // Initialize exercise properties based on your logic
            };

            adminServiceMock.Setup(service => service.GetExerciseByIdAsync(exerciseId)).ReturnsAsync(exercise);

            var editExerciseViewModel = new EditExerciseViewModel
            {
                // Initialize properties if needed
            };

            adminServiceMock.Setup(service => service.CreateEditExerciseViewModel(exercise, categories)).Returns(editExerciseViewModel);

            // Act
            var result = await controller.EditExercise(exerciseId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(editExerciseViewModel, viewResult?.Model);
        }

        [Test]
        public async Task EditExercise_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            int exerciseId = 1;
            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetExerciseByIdAsync(exerciseId)).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.EditExercise(exerciseId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //EditExercise - POST
        [Test]
        public async Task EditExercise_ValidModel_RedirectsToExerciseDetails()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new EditExerciseViewModel
            {
                // Initialize valid model properties
            };

            int exerciseId = 1;
            var exercise = new Exercise
            {
                Id = exerciseId,
                // Initialize exercise properties based on your logic
            };

            IEnumerable<CategoryViewModel> categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = 1, Name = "Category1" },
                new CategoryViewModel { Id = 2, Name = "Category2" }
            };

            adminServiceMock.Setup(service => service.GetExerciseByIdAsync(validModel.Id)).ReturnsAsync(exercise);
            adminServiceMock.Setup(service => service.EditingInformationAboutExerciseAsync(exercise, validModel)).Returns(Task.CompletedTask);
            categoryServiceMock.Setup(service => service.AllCategoriesAsync()).ReturnsAsync(categories);

            // Act
            var result = await controller.EditExercise(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("ExerciseDetails", redirectToActionResult?.ActionName);
            Assert.AreEqual(exerciseId, redirectToActionResult?.RouteValues?["id"]);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully edited exercise.", tempData["Success"]);

            adminServiceMock.Verify(service => service.EditingInformationAboutExerciseAsync(exercise, validModel), Times.Once);
        }

        [Test]
        public async Task EditExercise_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var invalidModel = new EditExerciseViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.EditExercise(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.EditingInformationAboutExerciseAsync(It.IsAny<Exercise>(), It.IsAny<EditExerciseViewModel>()), Times.Never);
        }

        [Test]
        public async Task EditExercise_ThrowsArgumentException_RedirectsToEditExerciseWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.EditingInformationAboutExerciseAsync(It.IsAny<Exercise>(), It.IsAny<EditExerciseViewModel>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new EditExerciseViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.EditExercise(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("EditExercise", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //DeleteExercise
        [Test]
        public async Task DeleteExercise_ValidId_RedirectsToExercises()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var controller = new AdminController(null, adminServiceMock.Object);

            int exerciseId = 1;
            var exercise = new Exercise
            {
                // Initialize exercise properties based on your logic
            };

            adminServiceMock.Setup(service => service.GetExerciseByIdAsync(exerciseId)).ReturnsAsync(exercise);
            adminServiceMock.Setup(service => service.DeleteExerciseAsync(exercise)).Returns(Task.CompletedTask);

            // Act
            var result = await controller.DeleteExercise(exerciseId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Exercises", redirectToActionResult?.ActionName);
            Assert.AreEqual("Gym", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual("Successfully deleted exercise.", tempData["Error"]);

            adminServiceMock.Verify(service => service.DeleteExerciseAsync(exercise), Times.Once);
        }

        [Test]
        public async Task DeleteExercise_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var controller = new AdminController(null, adminServiceMock.Object);

            int exerciseId = 1;
            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetExerciseByIdAsync(exerciseId)).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.DeleteExercise(exerciseId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //AddTrainingPlan - GET
        [Test]
        public async Task AddTrainingPlan_ValidData_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = 1, Name = "Category1" },
                new CategoryViewModel { Id = 2, Name = "Category2" }
            };

            categoryServiceMock.Setup(service => service.AllCategoriesAsync()).ReturnsAsync(categories);

            var addTrainingPlanViewModel = new AddTrainingPlanViewModel
            {
                // Initialize properties if needed
            };

            adminServiceMock.Setup(service => service.CreateAddTrainingPlanViewModel(categories)).Returns(addTrainingPlanViewModel);

            // Act
            var result = await controller.AddTrainingPlan();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(addTrainingPlanViewModel, viewResult?.Model);
        }

        [Test]
        public async Task AddTrainingPlan_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.CreateAddTrainingPlanViewModel(It.IsAny<List<CategoryViewModel>>())).Throws(new ArgumentException(errorMessage));

            // Act
            var result = await controller.AddTrainingPlan();

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //AddTrainingPlan - POST
        [Test]
        public async Task AddTrainingPlan_ValidModel_RedirectsToTrainingPlans()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new AddTrainingPlanViewModel
            {
                // Initialize valid model properties
            };

            var trainingPlan = new TrainingPlan
            {
                // Initialize training plan properties based on your logic
            };

            adminServiceMock.Setup(service => service.CreateTrainingPlanAsync(validModel)).ReturnsAsync(trainingPlan);

            // Act
            var result = await controller.AddTrainingPlan(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("TrainingPlans", redirectToActionResult?.ActionName);
            Assert.AreEqual("TrainingPlan", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully created training plan.", tempData["Success"]);

            adminServiceMock.Verify(service => service.CreateTrainingPlanAsync(validModel), Times.Once);
        }

        [Test]
        public async Task AddTrainingPlan_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var controller = new AdminController(null, adminServiceMock.Object);

            var invalidModel = new AddTrainingPlanViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.AddTrainingPlan(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.CreateTrainingPlanAsync(It.IsAny<AddTrainingPlanViewModel>()), Times.Never);
        }

        [Test]
        public async Task AddTrainingPlan_ThrowsArgumentException_RedirectsToAddTrainingPlanWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var controller = new AdminController(null, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.CreateTrainingPlanAsync(It.IsAny<AddTrainingPlanViewModel>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new AddTrainingPlanViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.AddTrainingPlan(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("AddTrainingPlan", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //EditTrainingPlan - GET
        [Test]
        public async Task EditTrainingPlan_ValidId_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = 1, Name = "Category1" },
                new CategoryViewModel { Id = 2, Name = "Category2" }
            };

            categoryServiceMock.Setup(service => service.AllCategoriesAsync()).ReturnsAsync(categories);

            int trainingPlanId = 1;
            var trainingPlan = new TrainingPlan
            {
                // Initialize training plan properties based on your logic
            };

            adminServiceMock.Setup(service => service.GetTrainingPlanByIdAsync(trainingPlanId)).ReturnsAsync(trainingPlan);
            var editTrainingPlanViewModel = new EditTrainingPlanViewModel
            {
                // Initialize properties if needed
            };
            adminServiceMock.Setup(service => service.CreateEditTrainingPlanViewModel(trainingPlan, categories)).Returns(editTrainingPlanViewModel);

            // Act
            var result = await controller.EditTrainingPlan(trainingPlanId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(editTrainingPlanViewModel, viewResult?.Model);
        }

        [Test]
        public async Task EditTrainingPlan_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.CreateEditTrainingPlanViewModel(It.IsAny<TrainingPlan>(), It.IsAny<IEnumerable<CategoryViewModel>>())).Throws(new ArgumentException(errorMessage));

            int trainingPlanId = 1;

            // Act
            var result = await controller.EditTrainingPlan(trainingPlanId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //EditTrainingPlan - POST
        [Test]
        public async Task EditTrainingPlan_ValidModel_RedirectsToTrainingPlanDetails()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var validModel = new EditTrainingPlanViewModel
            {
                // Initialize valid model properties
            };

            var categories = new List<CategoryViewModel>
            {
                new CategoryViewModel { Id = 1, Name = "Category1" },
                new CategoryViewModel { Id = 2, Name = "Category2" }
            };

            categoryServiceMock.Setup(service => service.AllCategoriesAsync()).ReturnsAsync(categories);

            var trainingPlan = new TrainingPlan
            {
                // Initialize training plan properties based on your logic
            };

            adminServiceMock.Setup(service => service.GetTrainingPlanByIdAsync(validModel.Id)).ReturnsAsync(trainingPlan);

            // Act
            var result = await controller.EditTrainingPlan(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("GetTrainingPlan", redirectToActionResult?.ActionName);
            Assert.AreEqual("TrainingPlan", redirectToActionResult?.ControllerName);
            Assert.AreEqual(validModel.CategoryId, redirectToActionResult?.RouteValues?["id"]);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual("Successfully edited training plan.", tempData["Success"]);

            adminServiceMock.Verify(service => service.EditingInformationAboutTrainingPlanAsync(trainingPlan, validModel), Times.Once);
        }

        [Test]
        public async Task EditTrainingPlan_InvalidModel_ReturnsViewWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var invalidModel = new EditTrainingPlanViewModel
            {
                // Initialize invalid model properties
            };

            controller.ModelState.AddModelError("propertyName", "Error message");

            // Act
            var result = await controller.EditTrainingPlan(invalidModel);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(invalidModel, viewResult?.Model);

            adminServiceMock.Verify(service => service.EditingInformationAboutTrainingPlanAsync(It.IsAny<TrainingPlan>(), It.IsAny<EditTrainingPlanViewModel>()), Times.Never);
        }

        [Test]
        public async Task EditTrainingPlan_ThrowsArgumentException_RedirectsToEditTrainingPlanWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.EditingInformationAboutTrainingPlanAsync(It.IsAny<TrainingPlan>(), It.IsAny<EditTrainingPlanViewModel>())).ThrowsAsync(new ArgumentException(errorMessage));

            var validModel = new EditTrainingPlanViewModel
            {
                // Initialize valid model properties
            };

            // Act
            var result = await controller.EditTrainingPlan(validModel);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("EditTrainingPlan", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //DeleteTrainingPlan
        [Test]
        public async Task DeleteTrainingPlan_ValidId_RedirectsToTrainingPlans()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var controller = new AdminController(null, adminServiceMock.Object);

            int trainingPlanId = 1;
            var trainingPlan = new TrainingPlan
            {
                // Initialize training plan properties based on your logic
            };

            adminServiceMock.Setup(service => service.GetTrainingPlanByIdAsync(trainingPlanId)).ReturnsAsync(trainingPlan);

            // Act
            var result = await controller.DeleteTrainingPlan(trainingPlanId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("TrainingPlans", redirectToActionResult?.ActionName);
            Assert.AreEqual("TrainingPlan", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual("Successfully deleted training plan.", tempData["Error"]);

            adminServiceMock.Verify(service => service.DeleteTrainingPlanAsync(trainingPlan), Times.Once);
        }

        [Test]
        public async Task DeleteTrainingPlan_ThrowsArgumentException_RedirectsToHomeIndexWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetTrainingPlanByIdAsync(It.IsAny<int>())).ThrowsAsync(new ArgumentException(errorMessage));

            int trainingPlanId = 1;

            // Act
            var result = await controller.DeleteTrainingPlan(trainingPlanId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("Index", redirectToActionResult?.ActionName);
            Assert.AreEqual("Home", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //UserList - GET
        [Test]
        public async Task UserList_ValidData_ReturnsViewWithModel()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Id = new Guid(), UserName = "User1" },
                new ApplicationUser { Id = new Guid(), UserName = "User2" }
            };

            adminServiceMock.Setup(service => service.UsersListAsync()).ReturnsAsync(users);

            // Act
            var result = await controller.UserList();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(users, viewResult?.Model);
        }

        [Test]
        public async Task UserList_ThrowsException_RedirectsToUserListWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.UsersListAsync()).ThrowsAsync(new Exception(errorMessage));

            // Act
            var result = await controller.UserList();

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);
            Assert.AreEqual("Admin", redirectToActionResult?.ControllerName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //UserList - POST
        [Test]
        public async Task UserList_NoSearchInput_ReturnsViewWithAllUsers()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Id = new Guid(), UserName = "User1" },
                new ApplicationUser { Id = new Guid(), UserName = "User2" }
            };

            adminServiceMock.Setup(service => service.UsersListAsync()).ReturnsAsync(users);

            // Act
            var result = await controller.UserList(null);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(users, viewResult?.Model);
        }

        [Test]
        public async Task UserList_WithSearchInput_ReturnsViewWithFilteredUsers()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var searchInput = "User1";
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Id = new Guid(), UserName = "User1" },
                new ApplicationUser { Id = new Guid(), UserName = "User2" }
            };

            adminServiceMock.Setup(service => service.UserInListByUsernameAsync(searchInput)).ReturnsAsync(users);

            // Act
            var result = await controller.UserList(searchInput);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.AreEqual(users, viewResult?.Model);
        }

        //DeleteUser - POST
        [Test]
        public async Task DeleteUser_ValidId_NotDeleted_ReturnsRedirectToUserListWithSuccessMessage()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId, IsDeleted = false };

            adminServiceMock.Setup(service => service.GetApplicationUserByIdAsync(userId.ToString())).ReturnsAsync(user);

            // Act
            var result = await controller.DeleteUser(userId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual(SuccessfullyDeletedUser, tempData["Success"]);
        }

        [Test]
        public async Task DeleteUser_ValidId_AlreadyDeleted_ReturnsRedirectToUserListWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId, IsDeleted = true };

            adminServiceMock.Setup(service => service.GetApplicationUserByIdAsync(userId.ToString())).ReturnsAsync(user);

            // Act
            var result = await controller.DeleteUser(userId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(ThisUserIsAlreadyDeleted, tempData["Error"]);
        }

        [Test]
        public async Task DeleteUser_ThrowsArgumentException_ReturnsRedirectToUserListWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetApplicationUserByIdAsync(It.IsAny<string>())).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.DeleteUser(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //PromoteUserToAdmin - POST
        [Test]
        public async Task PromoteUserToAdmin_ValidId_NotAdmin_ReturnsRedirectToUserListWithSuccessMessage()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId, IsModerator = false };

            adminServiceMock.Setup(service => service.GetApplicationUserByIdAsync(userId.ToString())).ReturnsAsync(user);

            // Act
            var result = await controller.PromoteUserToAdmin(userId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual(SuccessfullyPromotedUserToAdmin, tempData["Success"]);
        }

        [Test]
        public async Task PromoteUserToAdmin_ValidId_AlreadyAdmin_ReturnsRedirectToUserListWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId, IsModerator = true };

            adminServiceMock.Setup(service => service.GetApplicationUserByIdAsync(userId.ToString())).ReturnsAsync(user);

            // Act
            var result = await controller.PromoteUserToAdmin(userId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(GymApp.Common.ExceptionMessages.ThisUserHasAlreadyRoleAdmin, tempData["Error"]);
        }

        [Test]
        public async Task PromoteUserToAdmin_ThrowsArgumentException_ReturnsRedirectToUserListWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetApplicationUserByIdAsync(It.IsAny<string>())).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.PromoteUserToAdmin(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }

        //DemoteUser - POST
        [Test]
        public async Task DemoteUser_ValidId_IsModerator_ReturnsRedirectToUserListWithSuccessMessage()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId, IsModerator = true };

            adminServiceMock.Setup(service => service.GetApplicationUserByIdAsync(userId.ToString())).ReturnsAsync(user);

            // Act
            var result = await controller.DemoteUser(userId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Success"));
            Assert.AreEqual(SuccessfullyDemotedUser, tempData["Success"]);
        }

        [Test]
        public async Task DemoteUser_ValidId_NotModerator_ReturnsRedirectToUserListWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var userId = Guid.NewGuid();
            var user = new ApplicationUser { Id = userId, IsModerator = false };

            adminServiceMock.Setup(service => service.GetApplicationUserByIdAsync(userId.ToString())).ReturnsAsync(user);

            // Act
            var result = await controller.DemoteUser(userId);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(ThisUserHasAlreadyRoleUser, tempData["Error"]);
        }

        [Test]
        public async Task DemoteUser_ThrowsArgumentException_ReturnsRedirectToUserListWithError()
        {
            // Arrange
            var adminServiceMock = new Mock<IAdminService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var controller = new AdminController(categoryServiceMock.Object, adminServiceMock.Object);

            var errorMessage = "Sample error message";
            adminServiceMock.Setup(service => service.GetApplicationUserByIdAsync(It.IsAny<string>())).ThrowsAsync(new ArgumentException(errorMessage));

            // Act
            var result = await controller.DemoteUser(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("UserList", redirectToActionResult?.ActionName);

            var tempData = controller.TempData;
            Assert.IsTrue(tempData.ContainsKey("Error"));
            Assert.AreEqual(errorMessage, tempData["Error"]);
        }
    }
}
