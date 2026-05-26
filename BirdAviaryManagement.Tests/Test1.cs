using BirdAviaryManagement.Models;
using BirdAviaryManagement.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BirdAviaryManagement.Tests;

[TestClass]
public class BirdServiceTests
{
    [TestMethod]
    public void AddBird_WhenHealthServiceReturnsTrue_ShouldSetBirdForSaleTrue()
    {
        // Arrange
        Mock<IHealthService> mockHealthService =
            new Mock<IHealthService>();

        mockHealthService
            .Setup(
                x => x.IsBirdHealthy("123")
            )
            .Returns(true);

        BirdService service =
            new BirdService(
                mockHealthService.Object
            );

        Bird bird =
            new Bird
            (
                "123",
                "Rio",
                2,
                "Parrot",
                "Green",
                "In Aviary",
                false
            );

        // Act
        service.AddBird(bird);

        // Assert
        Assert.IsTrue(
            bird.IsForSale
        );
    }

    [TestMethod]
    public void AddBird_WhenHealthServiceReturnsFalse_ShouldSetBirdForSaleFalse()
    {
        // Arrange
        Mock<IHealthService> mockHealthService =
            new Mock<IHealthService>();

        mockHealthService
            .Setup(
                x => x.IsBirdHealthy("999")
            )
            .Returns(false);

        BirdService service =
            new BirdService(
                mockHealthService.Object
            );

        Bird bird =
            new Bird
            (
                "999",
                "Max",
                3,
                "Eagle",
                "Black",
                "In Aviary",
                true
            );

        // Act
        service.AddBird(bird);

        // Assert
        Assert.IsFalse(
            bird.IsForSale
        );
    }

    [TestMethod]
    public void GetBirdCount_ShouldReturnCorrectCount()
    {
        // Arrange
        Mock<IHealthService> mockHealthService =
            new Mock<IHealthService>();

        mockHealthService
            .Setup(
                x => x.IsBirdHealthy(
                    It.IsAny<string>()
                )
            )
            .Returns(true);

        BirdService service =
            new BirdService(
                mockHealthService.Object
            );

        Bird bird1 =
            new Bird
            (
                "1",
                "Bird1",
                1,
                "Parrot",
                "Blue",
                "In Aviary",
                true
            );

        Bird bird2 =
            new Bird
            (
                "2",
                "Bird2",
                2,
                "Eagle",
                "White",
                "Sold",
                true
            );

        // Act
        service.AddBird(bird1);

        service.AddBird(bird2);

        // Assert
        Assert.AreEqual(
            2,
            service.GetBirdCount()
        );
    }
}