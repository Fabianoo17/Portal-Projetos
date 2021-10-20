using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Core.Business.Helpers
{
    public static class ConfigurationBuilderHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .Build();

            return configuration;
        }
    }
}