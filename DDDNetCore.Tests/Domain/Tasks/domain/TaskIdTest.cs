using System;
using DDDSample1.Domain.Tasks;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDNetCore.Tests.Domain.Tasks.domain;

[TestClass]
[TestSubject(typeof(TaskId))]
public class TaskIdTest
{

    [TestMethod]
    public void GuidConstructor_ShouldCreateInstance()
    {
        
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var taskId = new TaskId(guid);

        // Assert
        Assert.AreEqual(guid, taskId.AsGuid());
        Assert.AreEqual(guid.ToString(), taskId.AsString());
        
    }
    
    [TestMethod]
    public void StringConstructor_ShouldCreateInstance()
    {
        
        // Arrange
        var guidString = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        // Act
        var taskId = new TaskId(guidString);

        // Assert
        Assert.AreEqual(Guid.Parse(guidString), taskId.AsGuid());
        Assert.AreEqual(guidString, taskId.AsString());
        
    }
    
    [TestMethod]
    public void AsGuid_ShouldReturnGuid()
    {
        
        // Arrange
        var guid = Guid.NewGuid();
        var taskId = new TaskId(guid);

        // Act
        var result = taskId.AsGuid();

        // Assert
        Assert.AreEqual(guid, result);
        
    }
    
    [TestMethod]
    public void AsString_ShouldReturnStringRepresentation()
    {
        
        // Arrange
        var guidString = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        var taskId = new TaskId(guidString);

        // Act
        var result = taskId.AsString();

        // Assert
        Assert.AreEqual(guidString, result);
        
    }
    
    [TestMethod]
    [ExpectedException(typeof(System.FormatException))]
    public void Constructor_WithInvalidGuid_ShouldThrowException()
    {
        // Arrange
        var invalidGuid = "invalidGuid";

        // Act
        var taskId = new TaskId(invalidGuid);
    }
    
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void Constructor_WithNullGuid_ShouldThrowException()
    {
        

        // Act
        var taskId = new TaskId(null);
    }
    
    [TestMethod]
    [ExpectedException(typeof(System.FormatException))]
    public void Constructor_WithEmptyString_ShouldThrowException()
    {
        // Arrange
        var emptyString = "";
        
        // Act
        var taskId = new TaskId(emptyString);
        
       
     
        
    }
    
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void Constructor_WithNullString_ShouldThrowException()
    {
        

        // Act
        var taskId = new TaskId(null);
    }
    
    
    
}