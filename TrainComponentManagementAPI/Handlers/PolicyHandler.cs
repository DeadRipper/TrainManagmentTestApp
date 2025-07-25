using Polly;
using Polly.Retry;

namespace TrainComponentManagementAPI.Handlers
{
    //class with policy for retry
    public static class PolicyHandler
    {
        //set limit to some value
        private static int failCountLimit = 1;
        //set retry timeout between attempts as 300 msec
        private static int retryTimeoutMsec = 300;

        /// <summary>
        /// Retry mechanism for DB
        /// </summary>
        /// <param name="logMessage">set name of func was called</param>
        /// <param name="logger">instance of logger</param>
        /// <returns>true - if exception, if not - result of func excecution</returns>
        public static AsyncRetryPolicy GetDbRetryPolicy(string logMessage, ILogger logger)
        {
            var retryPolicy = Policy
                .Handle<Exception>(ex =>
                {
                    logger.LogWarning($"{logMessage}. Exception: {ex}");
                    //returns when after retry Exception not gone
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