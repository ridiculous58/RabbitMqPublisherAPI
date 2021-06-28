using Infrastructure.Utilities.IoC;
using Newtonsoft.Json;
using Serilog;

namespace Infrastructure.CrossCuttingConcerns.Logging.ElasticSearch
{
    public class ElasticLogger : ILoggerService
    {
        private ILogger _logger;
        public ElasticLogger()
        {
            _logger = (ILogger)ServiceTool.ServiceProvider.GetService(typeof(ILogger));

        }
        public void Info(object logMessage)
        {
           
             _logger.Information(GetStringFromObject(logMessage));
        }
        private string GetStringFromObject(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public void Debug(object logMessage)
        {

            _logger.Debug(GetStringFromObject(logMessage));
        }

        public void Warn(object logMessage)
        {

            _logger.Warning(GetStringFromObject(logMessage));
        }

        public void Fatal(object logMessage)
        {
            _logger.Fatal(GetStringFromObject(logMessage));
        }

        public void Error(object logMessage)
        {
            _logger.Error(GetStringFromObject(logMessage));
        }
    }
}
