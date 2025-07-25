using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponentManagementAPI.Controllers;
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
        private Mock<TrainDbContext> _contextMock;

        [SetUp]
        public void Setup()
        {
            _context = DbContextHelper.GetInMemoryDbContext();
            _serviceMoq = new Mock<ITrainManagmentService>();
            _service = new TrainManagmentService(new Mock<ILogger<TrainManagmentService>>().Object);
            _contextMock = new Mock<TrainDbContext>();
        }

        [Test]
        public async Task RetryCheckerSuccessCountedRetry()
        {
            _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).Throws(new Exception());
            _serviceMoq.Setup(x => x.SavedContextInDB(It.IsAny<TrainDbContext>())).Returns(Task.FromResult(true));
            _serviceMoq.Setup(x => x.FindComponent(It.IsAny<TrainDbContext>(), It.IsAny<int>())).Returns(Task.FromResult(new TrainComponent()
            {
                Id = 1,
                CanAssignQuantity = "Yes",
                Name = "1",
                Quantity = null,
                UniqueNumber = "1"
            }));
            _serviceMoq.Setup(x => x.CheckIfComponentIsNotEmpty(It.IsAny<int>(), It.IsAny<TrainComponent>())).Returns(Task.FromResult(true));

            var result = await new ComponentsController(_contextMock.Object, _serviceMoq.Object).
                AssignQuantity(1,
                new AssignQuantity() { Quantity=1 });

            _serviceMoq.Verify(x => x.SavedContextInDB(It.IsAny<TrainDbContext>()), Times.Exactly(4));
        }

        [TearDown]
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}