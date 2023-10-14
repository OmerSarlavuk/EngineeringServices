using Microsoft.Extensions.Logging;

namespace Infrastructure.Log
{
    public static class LogBs
    {
        public static void Time(ILogger _logger)
        {
            DateTime dateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            _logger.LogInformation(dateTime + "This method was accessed at this date and time.!!");
        }
        public static void Info(string name, ILogger _logger)
        {
            _logger.LogInformation($"The user named {name} accessed with this method");
        }
        public static void Error(ILogger logger, string message)
        {
            logger.LogError($"When the method encounters an error: {message}");
        }
    }
}
