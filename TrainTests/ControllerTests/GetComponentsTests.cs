using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Net;
using TrainComponentManagementAPI.Controllers;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;
using TrainComponentManagementAPI.TrainManagmentWorker;
using TrainTests.DB;

namespace TrainTests.ControllerTests
{
    public class GetComponentsTests
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

        //check if data from real in answer and httpStatusCode is 200 and list in response contains elements
        [Test]
        public async Task SuccessGetComponentsGetDBElements()
        {
            var result = await new ComponentsController(_context, _service).GetComponents();
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult != null);
            Assert.That(okResult?.StatusCode.GetValueOrDefault(0), Is.EqualTo(200));
            Assert.That(okResult.Value is List<TrainComponent>);
            var okresultList = (List<TrainComponent>)okResult?.Value;
            Assert.That(okresultList.Count == 32);
        }

        //check if data from moq in answer is null and httpStatusCode is 404
        [Test]
        public async Task GetComponentsGetNoElements()
        {
            var result = await new ComponentsController(_context, _serviceMoq.Object).GetComponents();
            var notFoundResult = result.Result as NotFoundResult;
            Assert.That(notFoundResult != null);
            Assert.That(notFoundResult?.StatusCode, Is.EqualTo(404));
        }

        //check if data from moq in answer is count == 0 and httpStatusCode is 404
        [Test]
        public async Task GetComponentsGetEmptyElements()
        {
            //set moq of empty list
            _serviceMoq.Setup(x => x.GetAllComponents(_context))
                .Returns(Task.FromResult(new List<TrainComponent>()));
            //place moq in call of controller _serviceMoq.Object
            var result = await new ComponentsController(_context, _serviceMoq.Object).GetComponents();
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