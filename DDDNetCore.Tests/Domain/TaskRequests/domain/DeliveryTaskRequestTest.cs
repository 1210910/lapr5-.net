using System;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDSample1.Domain.Shared;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDNetCore.Tests.Domain.TaskRequests.domain;

[TestClass]
[TestSubject(typeof(DeliveryTaskRequest))]
public class DeliveryTaskRequestTest
{
    private static readonly string ValidDescription = "Sample description";
    private static readonly string ValidUser = "Sample user";
    private static readonly string ValidRoomDest = "Destination room";
    private static readonly string ValidRoomOrig = "Origin room";
    private static readonly string ValidDestName = "Destination Name";
    private static readonly string ValidOrigName = "Origin Name";
    private static readonly string ValidDestPhoneNumber = "123456789"; // Valid phone number
    private static readonly string ValidOrigPhoneNumber = "987654321"; // Valid phone number
    private static readonly string ValidCode = "12345";
    
    [TestMethod]
    public void Constructor_WithValidParameters_ShouldCreateInstance()
    {
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
            ValidDestName, ValidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);

        // Assert
        Assert.IsNotNull(deliveryTaskRequest);
        Assert.AreEqual(ValidDescription, deliveryTaskRequest.Description);
        Assert.AreEqual(ValidUser, deliveryTaskRequest.User);
        Assert.AreEqual(ValidRoomDest, deliveryTaskRequest.RoomDest);
        Assert.AreEqual(ValidRoomOrig, deliveryTaskRequest.RoomOrig);
        Assert.AreEqual(ValidDestName, deliveryTaskRequest.DestName.ToString());
        Assert.AreEqual(ValidOrigName, deliveryTaskRequest.OrigName.ToString());
        Assert.AreEqual(ValidDestPhoneNumber, deliveryTaskRequest.DestPhoneNumber.ToString());
        Assert.AreEqual(ValidOrigPhoneNumber, deliveryTaskRequest.OrigPhoneNumber.ToString());
        Assert.AreEqual(ValidCode, deliveryTaskRequest.ConfirmationCode.Value);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidDescription_ShouldThrowException()
    {
        // Arrange
        var invalidDescription = "";
        
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(invalidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
            ValidDestName, ValidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidUser_ShouldThrowException()
    {
        // Arrange
        var invalidUser = "";
        
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, invalidUser, ValidRoomDest, ValidRoomOrig,
            ValidDestName, ValidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidRoomDest_ShouldThrowException()
    {
        // Arrange
        var invalidRoomDest = "";
        
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, invalidRoomDest, ValidRoomOrig,
            ValidDestName, ValidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidRoomOrig_ShouldThrowException()
    {
        // Arrange
        var invalidRoomOrig = "";
        
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, ValidRoomDest, invalidRoomOrig,
            ValidDestName, ValidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidDestName_ShouldThrowException()
    {
        // Arrange
        var invalidDestName = "";
        
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
            invalidDestName, ValidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidOrigName_ShouldThrowException()
    {
        // Arrange
        var invalidOrigName = "";
        
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
            ValidDestName, invalidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidDestPhoneNumber_ShouldThrowException()
    {
        // Arrange
        var invalidDestPhoneNumber = "";
        
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
            ValidDestName, ValidOrigName, invalidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidOrigPhoneNumber_ShouldThrowException()
    {
        // Arrange
        var invalidOrigPhoneNumber = "";
        
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
            ValidDestName, ValidOrigName, ValidDestPhoneNumber, invalidOrigPhoneNumber, ValidCode);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Constructor_WithInvalidCode_ShouldThrowException()
    {
        // Arrange
        var invalidCode = "111111111";
        
        // Act
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
            ValidDestName, ValidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, invalidCode);
    }
    
    [TestMethod]
    public void AproveRequest_WithValidParameters_ShouldChangeState()
    {
        // Arrange
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
            ValidDestName, ValidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);
        
        // Act
        deliveryTaskRequest.aproveRequest();
        
        // Assert
        Assert.AreEqual(States.Accepted.ToString(), deliveryTaskRequest.State);
    }
    
    [TestMethod]
    public void RejectRequest_WithValidParameters_ShouldChangeState()
    {
        // Arrange
        var deliveryTaskRequest = new DeliveryTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
            ValidDestName, ValidOrigName, ValidDestPhoneNumber, ValidOrigPhoneNumber, ValidCode);
        
        // Act
        deliveryTaskRequest.rejectRequest();
        
        // Assert
        Assert.AreEqual(States.Rejected.ToString(), deliveryTaskRequest.State);
    }
        
}