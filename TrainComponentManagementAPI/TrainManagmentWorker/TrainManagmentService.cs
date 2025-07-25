using Microsoft.EntityFrameworkCore;
using System.Threading;
using TrainComponentManagementAPI.Handlers;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;

namespace TrainComponentManagementAPI.TrainManagmentWorker
{
    public class TrainManagmentService(ILogger<TrainManagmentService> log) : ITrainManagmentService
    {
        /// <summary>
        /// Save context in MSSQL 
        /// </summary>
        /// <param name="context">MSSQL context</param>
        /// <returns>if save successfull - true, else - false</returns>
        public async Task<bool> SavedContextInDB(TrainDbContext context)
        {
            var policy = PolicyHandler.GetDbRetryPolicy("Call SaveContext", log);
            try
            {
                var result = await policy.ExecuteAndCaptureAsync(
                    async () =>
                    await context.SaveChangesAsync());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to find component in MSSQL
        /// </summary>
        /// <param name="context">MSSQL context</param>
        /// <param name="id">id of element in table</param>
        /// <returns>DTO object from DB with information about a product by id</returns>
        public async Task<TrainComponent> FindComponent(TrainDbContext context, int id)
        {
            var result = await PolicyHandler.GetDbRetryPolicy("Call FindComponent", log).ExecuteAndCaptureAsync(
                async () =>
                await context.Components.FindAsync(id));
            return result?.Result;
        }

        /// <summary>
        /// Method to get all components from DB
        /// </summary>
        /// <param name="context">MSSQL context</param>
        /// <returns>all components from DB</returns>
        public async Task<List<TrainComponent>> GetAllComponents(TrainDbContext context)
        {
            var result = await PolicyHandler.GetDbRetryPolicy("Call GetAllComponents", log).ExecuteAndCaptureAsync(
                async () =>
                await context.Components
                .Select(c => new TrainComponent
                {
                    Id = c.Id,
                    Name = c.Name,
                    UniqueNumber = c.UniqueNumber,
                    CanAssignQuantity = c.CanAssignQuantity,
                    Quantity = c.Quantity
                }).ToListAsync());
            return result?.Result;
        }

        /// <summary>
        /// Method to check if value from DB is not null and has not empty fields
        /// </summary>
        /// <param name="component">TrainComponent component object</param>
        /// <returns>true if item valid else false</returns>
        public async Task<bool> CheckIfComponentIsNotEmpty(int componentId, TrainComponent component)
        {
            if (component == null || component.Id != componentId || string.IsNullOrWhiteSpace(component.Name) || string.IsNullOrWhiteSpace(component.UniqueNumber) || string.IsNullOrWhiteSpace(component.CanAssignQuantity))
            {
                return false;
            }
            
            return true;
        }
    }
}