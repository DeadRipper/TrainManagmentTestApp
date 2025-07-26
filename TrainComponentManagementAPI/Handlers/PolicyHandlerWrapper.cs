using Polly.Retry;

namespace TrainComponentManagementAPI.Handlers
{
    public class PolicyHandlerWrapper : IPolicyHandler
    {
        public AsyncRetryPolicy GetDbRetryPolicy(string logMessage, ILogger logger)
        {
            return PolicyHandler.GetDbRetryPolicy(logMessage, logger);
        }
    }
}