using Moq;
using TrainComponentManagementAPI.Controllers;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentWorker;

namespace TrainTests.DB
{
    public class Tests
    {
        private TrainDbContext _context;
        private Mock<ITrainManagmentService> serviceMoq;

        [SetUp]
        public void Setup()
        {
            _context = DbContextHelper.GetInMemoryDbContext();
        }

        [Test]
        public async Task CheckGetComponentsGetElements()
        {
            serviceMoq = new Mock<ITrainManagmentService>();
            serviceMoq.Setup(x =>
            x.GetAllComponents(It.IsAny<TrainDbContext>()))
                .Returns(
                Task.FromResult(
                    new List<TrainComponentManagementAPI.TrainManagmentDTO.TrainComponent>()
                    {
                        new TrainComponentManagementAPI.TrainManagmentDTO.TrainComponent()
                        {
                            Id = 1,
                        }
                    }));
            var result = await new ComponentsController(_context, serviceMoq.Object).GetComponents();
            Assert.That(result.Result.ExecuteResult(), Has.Count.EqualTo(1));
        }

        [TearDown]
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}