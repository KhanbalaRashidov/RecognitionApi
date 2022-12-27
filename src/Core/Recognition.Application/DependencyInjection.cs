using Hangfire;
using Hangfire.MemoryStorage;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Recognition.Application.Features.PaddleOCR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());



            services.AddTransient<IInvoiceOCRJob, InvoiceOCRJob>();
            services.AddHangfire(options =>
            {
                options.UseMemoryStorage();

            });
            services.AddHangfireServer(options => {
                options.WorkerCount = 1;
            });

            services.AddHttpClient("ocr", c =>
            {
                c.BaseAddress = new Uri("https://paddleocr.i247365.net/predict/ocr_system");
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            })
           .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1000))); ;
            return services;

        }
    }
}
