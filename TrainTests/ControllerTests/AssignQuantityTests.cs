using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrainComponentManagementAPI.Controllers;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;
using TrainComponentManagementAPI.TrainManagmentWorker;
using TrainTests.DB;

namespace TrainTests.ControllerTests
{
    public class AssignQuantityTests
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
        public async Task SuccessAssignQuantity(int elementId)
        {
            var json = JsonConvert.DeserializeObject<AssignQuantity>(
                File.ReadAllText(
                Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\ControllerTests\AssignQuantityRequestBody\SuccessRequest.json"))));
            var result = await new ComponentsController(_context, _service).
                AssignQuantity(elementId,
                json);
            var okResult = result as OkResult;
            Assert.That(okResult.StatusCode == 200);

            var itemContext = await _context.Components.FindAsync(elementId);
            Assert.That(itemContext != null);
            Assert.That(string.Compare(itemContext.CanAssignQuantity, "yes", StringComparison.OrdinalIgnoreCase) == 0);
            Assert.That(itemContext.Quantity == json.Quantity);
        }

        //check body validation for decimal. test will show how validation by middlleware will parse request body
        [Test]
        public async Task AssignQuantityDecimalInRequest()
        {
            Assert.Catch(() => JsonConvert.DeserializeObject<AssignQuantity>(
                File.ReadAllText(
                Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\ControllerTests\AssignQuantityRequestBody\RequestWithDecimal.json")))));
        }

        //check body validation for negative. test will show how negative value, because it int will switch logic
        [Test]
        [TestCase(5)]
        public async Task AssignQuantityNegativeInRequest(int elementId)
        {
            var json = JsonConvert.DeserializeObject<AssignQuantity>(
                File.ReadAllText(
                Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\ControllerTests\AssignQuantityRequestBody\RequestWithNegative.json"))));
            var result = await new ComponentsController(_context, _service).
                AssignQuantity(elementId,
                json);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult.StatusCode == 400);
            Assert.That(badRequestResult.Value, !Is.EqualTo(string.Empty));
        }

        [Test]
        public async Task AssignQuantityNoNodeInRequest()
        {
            Assert.Catch(() => JsonConvert.DeserializeObject<AssignQuantity>(
                File.ReadAllText(
                Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\ControllerTests\AssignQuantityRequestBody\RequestWithNull.json")))));
        }

        //check if data from moq in answer is null and httpStatusCode is 404
        [Test]
        [TestCase(33)]
        public async Task AssignQuantityFindNoElementInDB(int elementId)
        {
            var result = await new ComponentsController(_context, _serviceMoq.Object).AssignQuantity(elementId, new AssignQuantity() { Quantity = 1 });
            var notFoundResult = result as NotFoundResult;
            Assert.That(notFoundResult != null);
            Assert.That(notFoundResult?.StatusCode, Is.EqualTo(404));
        }

        //check if data from moq in answer is count == 0 and httpStatusCode is 404
        [Test]
        [TestCase(33)]
        public async Task AssignQuantityFindEmptyElementInDB(int elementId)
        {
            //set moq of empty component
            _serviceMoq.Setup(x => x.FindComponent(_context, elementId))
                .Returns(Task.FromResult(new TrainComponent()));
            //place moq in call of controller _serviceMoq.Object
            var result = await new ComponentsController(_context, _serviceMoq.Object).AssignQuantity(elementId, new AssignQuantity() { Quantity = 1 });
            var notFoundResult = result as NotFoundResult;
            Assert.That(notFoundResult != null);
            Assert.That(notFoundResult?.StatusCode, Is.EqualTo(404));
        }

        [Test]
        [TestCase(1)]
        public async Task NotAssignQuantityForItem(int elementId)
        {
            var json = JsonConvert.DeserializeObject<AssignQuantity>(
                File.ReadAllText(
                Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\ControllerTests\AssignQuantityRequestBody\SuccessRequest.json"))));
            var result = await new ComponentsController(_context, _service).
                AssignQuantity(elementId,
                json);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult.StatusCode == 400);
            Assert.That(badRequestResult.Value, !Is.EqualTo(string.Empty));
        }

        [TearDown]
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}