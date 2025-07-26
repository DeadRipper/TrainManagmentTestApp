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
        public async Task RetryCheckerSuccessCountedRetry()
        {
            //_contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Throws(new Exception());
            ////_serviceMoq.Setup(x => x.SavedContextInDB(It.IsAny<TrainDbContext>())).Returns(Task.FromResult(true));
            //_serviceMoq.Setup(x => x.FindComponent(It.IsAny<TrainDbContext>(), It.IsAny<int>())).Returns(Task.FromResult(new TrainComponent()
            //{
            //    Id = 1,
            //    CanAssignQuantity = "Yes",
            //    Name = "1",
            //    Quantity = null,
            //    UniqueNumber = "1"
            //}));
            //_serviceMoq.Setup(x => x.CheckIfComponentIsNotEmpty(It.IsAny<int>(), It.IsAny<TrainComponent>())).Returns(Task.FromResult(true));

            var ffffffff = await new ComponentsController(_context, _service).
                AssignQuantity(1,
                new AssignQuantity() { Quantity=1 });

            //_serviceMoq.Verify(x => x.SavedContextInDB(It.IsAny<TrainDbContext>()), Times.Exactly(4));
        }

        [TearDown]
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}