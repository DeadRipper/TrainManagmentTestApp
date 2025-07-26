using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentDTO;

namespace TrainComponentManagementAPI.TrainManagmentWorker
{
    public interface ITrainManagmentService
    {
        /// <summary>
        /// Save context in MSSQL 
        /// </summary>
        /// <param name="context">MSSQL context</param>
        /// <returns>if save successfull - true, else - false</returns>
        public Task<bool> SavedContextInDB(TrainDbContext context);
        /// <summary>
        /// Method to find component in MSSQL
        /// </summary>
        /// <param name="context">MSSQL context</param>
        /// <param name="id">id of element in table</param>
        /// <returns>DTO object from DB with information about a product by id</returns>
        public Task<TrainComponent> FindComponent(TrainDbContext context, int id);
        /// <summary>
        /// Method to get all components from DB
        /// </summary>
        /// <param name="context">MSSQL context</param>
        /// <returns>all components from DB</returns>
        public Task<List<TrainComponent>> GetAllComponents(TrainDbContext context);
        /// <summary>
        /// Method to check if value from DB is not null and has not empty fields
        /// </summary>
        /// <param name="component">TrainComponent component object</param>
        /// <returns>true if item valid else false</returns>
        public Task<bool> CheckIfComponentIsNotEmpty(int componentId, TrainComponent component);
        /// <summary>
        /// Method for updating component
        /// </summary>
        /// <param name="context">MSSQL context</param>
        /// <param name="id">id of element in table</param>
        /// <returns>updated entity of component</returns>
        public Task<TrainComponent> UpdateComponent(TrainDbContext context, TrainComponent componentFromRequest);
    }
}