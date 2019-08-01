using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace api.configuration
{
    public class DataInitStartupFilter : IStartupFilter
    {
        private readonly ILogger _logger;
        public DataInitStartupFilter(ILogger<DataInitStartupFilter> logger)
        {
            _logger = logger;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            _logger.LogWarning("Configure stuff");
            return builder =>
            {

                // builder.UseMiddleware<RequestServicesContainerMiddleware>();
                next(builder);
            };
        }
    }
}
