using System;
using DDDNetCore.Domain.TaskRequests.domain;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDNetCore.Tests.Domain.TaskRequests.domain;

[TestClass]
[TestSubject(typeof(TaskRequest))]
public class TaskRequestTest
{
[TestClass]
    public class TaskRequestTests
    {
        private const string ValidDescription = "Sample description";
        private const string ValidUser = "Sample user";
        private const string ValidRoomDest = "Destination room";
        private const string ValidRoomOrig = "Origin room";

        [TestMethod]
        public void Constructor_WithValidParameters_ShouldCreateInstance()
        {
            // Act
            var taskRequest = new TestTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig);

            // Assert
            Assert.IsNotNull(taskRequest);
            Assert.AreEqual(ValidDescription, taskRequest.Description);
            Assert.AreEqual(ValidUser, taskRequest.User);
            Assert.AreEqual(ValidRoomDest, taskRequest.RoomDest);
            Assert.AreEqual(ValidRoomOrig, taskRequest.RoomOrig);
            Assert.AreEqual("Pending", taskRequest.State);
        }

        [TestMethod]
        public void Constructor_WithInvalidParameters_ShouldThrowException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var taskRequest = new TestTaskRequest("", ValidUser, ValidRoomDest, ValidRoomOrig);
            });
        }
        
        [TestMethod]
        public void Constructor_WithInvalidUser_ShouldThrowException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var taskRequest = new TestTaskRequest(ValidDescription, "", ValidRoomDest, ValidRoomOrig);
            });
        }
        
        
        [TestMethod]
        public void Constructor_WithInvalidRoomDest_ShouldThrowException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var taskRequest = new TestTaskRequest(ValidDescription, ValidUser, "", ValidRoomOrig);
            });
        }
        
        [TestMethod]
        public void Constructor_WithInvalidRoomOrig_ShouldThrowException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var taskRequest = new TestTaskRequest(ValidDescription, ValidUser, ValidRoomDest, "");
            });
        }
        
        
        
        
        
        [TestMethod]
        public void TestAproveRequest_ShouldSetStateToAccepted()
        {
            // Arrange
            var taskRequest = new TestTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig);

            // Act
            taskRequest.TestAproveRequest();

            // Assert
            Assert.AreEqual("Accepted", taskRequest.State);
        }
        
        [TestMethod]
        public void TestRejectRequest_ShouldSetStateToRejected()
        {
            // Arrange
            var taskRequest = new TestTaskRequest(ValidDescription, ValidUser, ValidRoomDest, ValidRoomOrig);

            // Act
            taskRequest.TestRejectRequest();

            // Assert
            Assert.AreEqual("Rejected", taskRequest.State);
        }
        
        
        

        
    }

    // Creating a mock class inheriting from TaskRequest for testing purposes
    public class TestTaskRequest : TaskRequest
    {
        public TestTaskRequest(string description, string user, string roomDest, string roomOrig)
            : base(description, user, roomDest, roomOrig)
        {
            
        }
        public void TestAproveRequest()
        {
            aproveRequest();
        }

        public void TestRejectRequest()
        {
            rejectRequest();
        }
    }
    
        
}