﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Acme.HelpDesk
{
    public class HelpDeskWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<HelpDeskWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}