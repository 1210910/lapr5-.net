using System;
using DDDSample1.Domain.Tasks;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDNetCore.Tests.Domain.Tasks.domain;

[TestClass]
[TestSubject(typeof(Task))]
public class TaskTest
{
    private static readonly string ValidDescription = "Sample description";
    private static readonly string ValidUser = "Sample user";
    private static readonly string ValidRoomDest = "Destination room";
    private static readonly string ValidRoomOrig = "Origin room";

    [TestMethod]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {

        // Act
        var task = new TestTask(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig);

        // Assert
        Assert.IsNotNull(task);
        Assert.AreEqual(ValidDescription, task.Description);
        Assert.AreEqual(ValidUser, task.User);
        Assert.AreEqual(ValidRoomDest, task.RoomDest);
        Assert.AreEqual(ValidRoomOrig, task.RoomOrig);


    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidDescription_ShouldThrowException()
    {
        // Arrange
        var invalidDescription = "";

        // Act
        var task = new TestTask(invalidDescription, ValidUser, ValidRoomDest, ValidRoomOrig);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidUser_ShouldThrowException()
    {
        // Arrange
        var invalidUser = "";

        // Act
        var task = new TestTask(ValidDescription, invalidUser, ValidRoomDest, ValidRoomOrig);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidRoomDest_ShouldThrowException()
    {
        // Arrange
        var invalidRoomDest = "";

        // Act
        var task = new TestTask(ValidDescription, ValidUser, invalidRoomDest, ValidRoomOrig);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidRoomOrig_ShouldThrowException()
    {
        // Arrange
        var invalidRoomOrig = "";

        // Act
        var task = new TestTask(ValidDescription, ValidUser, ValidRoomDest, invalidRoomOrig);
    }
    
    // test if id is created
    [TestMethod]
    public void Constructor_WithValidParameters_ShouldCreateId()
    {
        // Arrange
        var task = new TestTask(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig);

        // Act
        var id = task.Id;

        // Assert
        Assert.IsNotNull(id);
    }


public class TestTask : Task
    {
        public TestTask(string description, string user, string roomDest, string roomOrig) : base(description, user, roomDest, roomOrig)
        {
        }
    }
}