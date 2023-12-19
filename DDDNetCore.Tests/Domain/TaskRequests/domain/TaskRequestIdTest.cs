using System;
using DDDNetCore.Domain.TaskRequests.domain;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDNetCore.Tests.Domain.TaskRequests.domain;

[TestClass]
[TestSubject(typeof(TaskRequestId))]
public class TaskRequestIdTest
{

    [TestMethod]
    public void GuidConstructor_ShouldCreateInstance()
    {
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var taskRequestId = new TaskRequestId(guid);

        // Assert
        Assert.AreEqual(guid, taskRequestId.AsGuid());
        Assert.AreEqual(guid.ToString(), taskRequestId.AsString());
    }

    [TestMethod]
    public void StringConstructor_ShouldCreateInstance()
    {
        // Arrange
        var guidString = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        // Act
        var taskRequestId = new TaskRequestId(guidString);

        // Assert
        Assert.AreEqual(Guid.Parse(guidString), taskRequestId.AsGuid());
        Assert.AreEqual(guidString, taskRequestId.AsString());
    }

    [TestMethod]
    public void AsGuid_ShouldReturnGuid()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var taskRequestId = new TaskRequestId(guid);

        // Act
        var result = taskRequestId.AsGuid();

        // Assert
        Assert.AreEqual(guid, result);
    }

    [TestMethod]
    public void AsString_ShouldReturnStringRepresentation()
    {
        // Arrange
        var guidString = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        var taskRequestId = new TaskRequestId(guidString);

        // Act
        var result = taskRequestId.AsString();

        // Assert
        Assert.AreEqual(guidString, result);
    }
}