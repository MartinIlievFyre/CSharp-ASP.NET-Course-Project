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
using Xunit;
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

        
    }
}
