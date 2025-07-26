using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework.Internal;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponentManagementAPI.Controllers;
using TrainComponentManagementAPI.Handlers;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;
using TrainComponentManagementAPI.TrainManagmentWorker;

namespace TrainTests.DB
{
    public class DBRetryTests
    {
        private TrainDbContext _context;
        private Mock<ITrainManagmentService> _serviceMoq;
        private ITrainManagmentService _service;
        private Mock<IPolicyHandler> _policyHandler;

        [SetUp]
        public void Setup()
        {
            _context = DbContextHelper.GetInMemoryDbContext();
            _serviceMoq = new Mock<ITrainManagmentService>();
            _policyHandler = new Mock<IPolicyHandler>();
            _service = new TrainManagmentService(_policyHandler.Object, new Mock<ILogger<TrainManagmentService>>().Object);
        }

        [Test]
        public async Task SavedContextInDB_RetriesAndSucceeds()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TrainDbContext>()
                .UseInMemoryDatabase(databaseName: "RetryTestDB")
                .Options;

            var loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger<TrainManagmentService>>(); // or ILogger<MyService>

            // Real Polly retry policy: retry 3 times
            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromMilliseconds(10));

            var policyHandlerMock = new Mock<IPolicyHandler>();
            policyHandlerMock
                .Setup(x => x.GetDbRetryPolicy(It.IsAny<string>(), It.IsAny<Microsoft.Extensions.Logging.ILogger<TrainManagmentService>>()))
                .Returns(retryPolicy);

            // Use a DB context that fails twice before succeeding
            var context = new RetryTestDbContext(options, failLimit: 2);

            var service = new TrainManagmentService(policyHandlerMock.Object, loggerMock.Object);

            // Act
            var result = await service.SavedContextInDB(context);

            // Assert
            Assert.That(result == true); // Should return true after retries
        }


        [TearDown]
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}