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
using TrainComponentManagementAPI.Handlers;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;
using TrainComponentManagementAPI.TrainManagmentWorker;
using TrainTests.DB;

namespace TrainTests.ControllerTests
{
    public class UpdateComponentTests
    {
        private TrainDbContext _context;
        private Mock<ITrainManagmentService> _serviceMoq;
        private ITrainManagmentService _service;
        private IPolicyHandler _policyHandler;

        [SetUp]
        public void Setup()
        {
            _context = DbContextHelper.GetInMemoryDbContext();
            _serviceMoq = new Mock<ITrainManagmentService>();
            _policyHandler = new PolicyHandlerWrapper();
            _service = new TrainManagmentService(_policyHandler, new Mock<ILogger<TrainManagmentService>>().Object);
        }

        [Test]
        public async Task SuccessUpdateComponent()
        {
            var json = JsonConvert.DeserializeObject<TrainComponent>(
                File.ReadAllText(
                Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\ControllerTests\UpdateComponentRequestBody\SuccessRequest.json"))));
            var result = await new ComponentsController(_context, _service).
                UpdateComponent(json);
            var okResult = result as OkResult;
            Assert.That(okResult.StatusCode == 200);

            var itemContext = await _context.Components.FindAsync(json.Id);
            Assert.That(itemContext != null);
            Assert.That(string.Compare(itemContext.CanAssignQuantity, "Yes", StringComparison.Ordinal) == 0);
            Assert.That(itemContext.Quantity == json.Quantity);
        }

        [Test]
        public async Task UpdateComponentCanAssignQuantityLowerCaseError()
        {
            var json = JsonConvert.DeserializeObject<TrainComponent>(
                File.ReadAllText(
                Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\ControllerTests\UpdateComponentRequestBody\CanAssignQuantityLowerCase.json"))));
            var result = await new ComponentsController(_context, _service).
                UpdateComponent(json);
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