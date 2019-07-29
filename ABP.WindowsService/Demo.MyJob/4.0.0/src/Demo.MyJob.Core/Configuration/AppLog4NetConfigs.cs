using Abp.Extensions;
using System.Collections.Concurrent;
using System.IO;

namespace Demo.MyJob.Configuration
{
    public static class AppLog4NetConfigs
    {
        private static readonly ConcurrentDictionary<string, string> Log4NetConfigCache;

        static AppLog4NetConfigs()
        {
            Log4NetConfigCache = new ConcurrentDictionary<string, string>();
        }

        public static void AddProperty(string key, string value)
        {
            log4net.GlobalContext.Properties[key] = value;
        }

        public static string Get(string path, string environmentName = null)
        {
            var cacheKey = path + "#" + environmentName;

            return Log4NetConfigCache.GetOrAdd(
                cacheKey,
                _ => BuildLog4NetConfig(path, environmentName)
            );
        }

        private static string BuildLog4NetConfig(string path, string environmentName = null)
        {
            var configFile = Path.Combine(path, "log4net.config");

            if (environmentName.IsNullOrWhiteSpace())
            {
                return configFile;
            }

            var tempPath = Path.Combine(path, $"log4net.{environmentName}.config");
            if (File.Exists(tempPath))
            {
                configFile = tempPath;
            }

            return configFile;
        }
    }
}
