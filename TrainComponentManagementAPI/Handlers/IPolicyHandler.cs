using Polly.Retry;

namespace TrainComponentManagementAPI.Handlers
{
    public interface IPolicyHandler
    {
        AsyncRetryPolicy GetDbRetryPolicy(string logMessage, ILogger logger);
    }
}