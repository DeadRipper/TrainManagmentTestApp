using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponentManagementAPI.Controllers;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;
using TrainComponentManagementAPI.TrainManagmentWorker;
using TrainTests.DB;

namespace TrainTests.ControllerTests
{
    public class GetComponentTests
    {
        private TrainDbContext _context;
        private Mock<ITrainManagmentService> _serviceMoq;
        private ITrainManagmentService _service;

        [SetUp]
        public void Setup()
        {
            _context = DbContextHelper.GetInMemoryDbContext();
            _serviceMoq = new Mock<ITrainManagmentService>();
            _service = new TrainManagmentService(new Mock<ILogger<TrainManagmentService>>().Object);
        }

        [Test]
        [TestCase(5)]
        public async Task SuccessGetComponentFindElementInDB(int elementId)
        {
            var result = await new ComponentsController(_context, _service).GetComponent(elementId);
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult != null);
            Assert.That(okResult?.StatusCode.GetValueOrDefault(0), Is.EqualTo(200));
            Assert.That(okResult.Value is TrainComponent);
            var okResultValue = (TrainComponent)okResult?.Value;
            Assert.That(okResultValue.Id == elementId);
            Assert.That(okResultValue.UniqueNumber, !Is.EqualTo(string.Empty));
            Assert.That(okResultValue.CanAssignQuantity, !Is.EqualTo(string.Empty));
            Assert.That(okResultValue.Name, !Is.EqualTo(string.Empty));
        }

        //check if data from moq in answer is null and httpStatusCode is 404
        [Test]
        [TestCase(33)]
        public async Task GetComponentFindNoElementInDB(int elementId)
        {
            var result = await new ComponentsController(_context, _serviceMoq.Object).GetComponent(elementId);
            var notFoundResult = result.Result as NotFoundResult;
            Assert.That(notFoundResult != null);
            Assert.That(notFoundResult?.StatusCode, Is.EqualTo(404));
        }

        //check if data from moq in answer is count == 0 and httpStatusCode is 404
        [Test]
        [TestCase(25)]
        public async Task GetComponentFindEmptyElementInDB(int elementId)
        {
            //set moq of empty component
            _serviceMoq.Setup(x => x.FindComponent(_context, elementId))
                .Returns(Task.FromResult(new TrainComponent()));
            //place moq in call of controller _serviceMoq.Object
            var result = await new ComponentsController(_context, _serviceMoq.Object).GetComponent(elementId);
            var notFoundResult = result.Result as NotFoundResult;
            Assert.That(notFoundResult != null);
            Assert.That(notFoundResult?.StatusCode, Is.EqualTo(404));
        }

        [TearDown]
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}