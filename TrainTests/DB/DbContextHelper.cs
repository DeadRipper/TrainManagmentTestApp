using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;

namespace TrainTests.DB
{
    public static class DbContextHelper
    {
        public static TrainDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<TrainDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new TrainDbContext(options);
            context.Database.EnsureCreated();

            context.Components.Add(new TrainComponent
            {
                Id = 31,
                Name = "Wheel",
                UniqueNumber = "WHL101",
                CanAssignQuantity = "Yes",
                Quantity = 100
            });
            context.Components.Add(new TrainComponent
            {
                Id = 32,
                Name = "Engine",
                UniqueNumber = "ENG123",
                CanAssignQuantity = "No"
            });
            context.SaveChanges();

            return context;
        }
    }
}