using System;
using System.Collections.Generic;
using System.Text;
using WorkTool;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace WorkToolNTest
{
    public class ServicesBuilder
    {
        IWebHost _webHost;
        public ServicesBuilder()
        {
            _webHost = WebHost.CreateDefaultBuilder()
            .UseStartup<Startup>()
            .Build();
        }
        public T GerService <T>()
        {
            var scope = _webHost.Services.CreateScope();
            return scope.ServiceProvider.GetRequiredService<T>();
        }
    }
}
