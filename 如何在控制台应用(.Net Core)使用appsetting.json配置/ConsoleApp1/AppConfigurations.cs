//=====================================================

//Copyright (C) 2016-2019 Fanjia

//All rights reserved

//CLR版 本:    4.0.30319.42000

//创建时间:     2019/2/18 16:38:41

//创 建 人:   徐晓航

//======================================================

using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    /// <summary>
    /// 该类来自Abp框架 <see cref="https://aspnetboilerplate.com"/>
    /// Abp的实现非常值得借用和学习
    /// </summary>
    public static class AppConfigurations
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> ConfigurationCache;

        static AppConfigurations()
        {
            ConfigurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfigurationRoot Get(string path, string environmentName = null)
        {
            var cacheKey = path + "#" + environmentName;
            return ConfigurationCache.GetOrAdd(
                cacheKey,
                _ => BuildConfiguration(path, environmentName)
            );
        }

        private static IConfigurationRoot BuildConfiguration(string path, string environmentName = null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!string.IsNullOrWhiteSpace(environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            builder = builder.AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
