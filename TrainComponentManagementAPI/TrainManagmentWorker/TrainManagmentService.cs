using Microsoft.EntityFrameworkCore;
using Polly;
using System.Threading;
using TrainComponentManagementAPI.Handlers;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;

namespace TrainComponentManagementAPI.TrainManagmentWorker
{
    public class TrainManagmentService : ITrainManagmentService
    {
        private readonly IPolicyHandler? _policyHandler;
        private readonly ILogger<TrainManagmentService>? _log;

        public TrainManagmentService(IPolicyHandler policyHandler, ILogger<TrainManagmentService> log)
        {
            _policyHandler = policyHandler;
            _log = log;
        }
        /// <summary>
        /// Save context in MSSQL 
        /// </summary>
        /// <param name="context">MSSQL context</param>
        /// <returns>if save successfull - true, else - false</returns>
        public async Task<bool> SavedContextInDB(TrainDbContext context)
        {
            var policy = _policyHandler.GetDbRetryPolicy("Call SaveContext", _log);
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
            var result = await _policyHandler.GetDbRetryPolicy("Call FindComponent", _log).ExecuteAndCaptureAsync(
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
            var result = await _policyHandler.GetDbRetryPolicy("Call GetAllComponents", _log).ExecuteAndCaptureAsync(
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

        /// <summary>
        /// Method for updating component
        /// </summary>
        /// <param name="context">MSSQL context</param>
        /// <param name="id">id of element in table</param>
        /// <returns>updated entity of component</returns>
        public async Task<TrainComponent> UpdateComponent(TrainDbContext context, TrainComponent component)
        {
            try
            {
                var componentSearch = await FindComponent(context, component.Id);
                if (componentSearch == null || !await CheckIfComponentIsNotEmpty(componentSearch.Id, componentSearch))
                    throw new Exception("NotFound component in DB");

                componentSearch.UniqueNumber = component.UniqueNumber;
                componentSearch.Quantity = component.Quantity;
                componentSearch.Name = component.Name;
                //make StringComparison.Ordinal to compare lower\upper case of Yes and No. By task Yas and No always in uppercase
                if (string.Compare(component.CanAssignQuantity, "Yes", StringComparison.Ordinal) != 0 && string.Compare(component.CanAssignQuantity, "No", StringComparison.Ordinal) != 0)
                {
                    throw new Exception("CanAssignQuantity invalid");
                }

                componentSearch.CanAssignQuantity = component.CanAssignQuantity;

                await SavedContextInDB(context);

                return component;
            }
            catch (Exception ex)
            {
                _log.LogError($"UpdateComponent :: {ex}");
                return null;
            }

        }
    }
}