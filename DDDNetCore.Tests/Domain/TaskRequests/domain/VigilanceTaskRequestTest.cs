using System;
using DDDNetCore.Domain.TaskRequests.domain;
using DDDSample1.Domain.Shared;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDNetCore.Tests.Domain.TaskRequests.domain;

[TestClass]
[TestSubject(typeof(VigilanceTaskRequest))]
public class VigilanceTaskRequestTest
{

     private const string ValidDescription = "Sample description";
        private const string ValidUser = "Sample user";
        private const string ValidRoomDest = "Destination room";
        private const string ValidRoomOrig = "Origin room";
        private const string ValidRequestName = "John Doe";
        private const string ValidRequestPhoneNumber = "1234567890";

        [TestMethod]
        public void Constructor_WithValidParameters_ShouldCreateInstance()
        {
            // Act
            var vigilanceTaskRequest = new VigilanceTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
                ValidRequestName, ValidRequestPhoneNumber);

            // Assert
            Assert.IsNotNull(vigilanceTaskRequest);
            Assert.AreEqual(ValidDescription, vigilanceTaskRequest.Description);
            Assert.AreEqual(ValidUser, vigilanceTaskRequest.User);
            Assert.AreEqual(ValidRoomDest, vigilanceTaskRequest.RoomDest);
            Assert.AreEqual(ValidRoomOrig, vigilanceTaskRequest.RoomOrig);
            Assert.AreEqual(ValidRequestName, vigilanceTaskRequest.RequestName.ToString());
            Assert.AreEqual(ValidRequestPhoneNumber, vigilanceTaskRequest.RequestNumber.ToString());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithInvalidDescription_ShouldThrowException()
        {
            // Arrange
            var invalidDescription = "";
            
            // Act
            var vigilanceTaskRequest = new VigilanceTaskRequest(invalidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
                ValidRequestName, ValidRequestPhoneNumber);
        }
        
        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithInvalidUser_ShouldThrowException()
        {
            // Arrange
            var invalidUser = "";
            
            // Act
            var vigilanceTaskRequest = new VigilanceTaskRequest(ValidDescription, invalidUser, ValidRoomDest, ValidRoomOrig,
                ValidRequestName, ValidRequestPhoneNumber);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithInvalidRoomDest_ShouldThrowException()
        {
            // Arrange
            var invalidRoomDest = "";
            
            // Act
            var vigilanceTaskRequest = new VigilanceTaskRequest(ValidDescription, ValidUser, invalidRoomDest, ValidRoomOrig,
                ValidRequestName, ValidRequestPhoneNumber);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithInvalidRoomOrig_ShouldThrowException()
        {
            // Arrange
            var invalidRoomOrig = "";
            
            // Act
            var vigilanceTaskRequest = new VigilanceTaskRequest(ValidDescription, ValidUser, ValidRoomDest, invalidRoomOrig,
                ValidRequestName, ValidRequestPhoneNumber);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithInvalidRequestName_ShouldThrowException()
        {
            // Arrange
            var invalidRequestName = "";
            
            // Act
            var vigilanceTaskRequest = new VigilanceTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
                invalidRequestName, ValidRequestPhoneNumber);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithInvalidRequestPhoneNumber_ShouldThrowException()
        {
            // Arrange
            var invalidRequestPhoneNumber = "";
            
            // Act
            var vigilanceTaskRequest = new VigilanceTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
                ValidRequestName, invalidRequestPhoneNumber);
        }
        

        [TestMethod]
        public void Approve_WhenCalled_ShouldSetRequestAsApproved()
        {
            // Arrange
            var vigilanceTaskRequest = new VigilanceTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
                ValidRequestName, ValidRequestPhoneNumber);

            // Act
            vigilanceTaskRequest.approve();

            // Assert
            Assert.AreEqual(States.Accepted.ToString(), vigilanceTaskRequest.State);
        }

        [TestMethod]
        public void Reject_WhenCalled_ShouldSetRequestAsRejected()
        {
            // Arrange
            var vigilanceTaskRequest = new VigilanceTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig,
                ValidRequestName, ValidRequestPhoneNumber);

            // Act
            vigilanceTaskRequest.reject();

            // Assert
            Assert.IsTrue(vigilanceTaskRequest.State.Equals(States.Rejected.ToString()));
        }
}