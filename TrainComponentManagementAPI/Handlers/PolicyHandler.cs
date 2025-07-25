using Polly;
using Polly.Retry;

namespace TrainComponentManagementAPI.Handlers
{
    public static class PolicyHandler
    {
        private static int failCountLimit = 3;
        private static int retryTimeoutMsec = 300;

        public static AsyncRetryPolicy GetDbRetryPolicy(string logMessage, ILogger logger)
        {
            var retryPolicy = Policy
                .Handle<Exception>(ex =>
                {
                    logger.LogWarning($"{logMessage}. Exception: {ex}");
                    return true;
                })
                .WaitAndRetryAsync(failCountLimit, attempt =>
                {
                    logger.LogInformation($"{logMessage}. Attempt = {attempt}/{failCountLimit}.");
                    return TimeSpan.FromMilliseconds(retryTimeoutMsec);
                });

            return retryPolicy;
        }
    }
}