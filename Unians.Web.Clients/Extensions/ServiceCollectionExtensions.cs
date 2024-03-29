﻿using Amazon.ServiceDiscovery;
using Amazon.ServiceDiscovery.Model;
using De.Amazon.Configuration.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Unians.Web.Clients.Interfaces;
using Unians.Web.Interfaces;

namespace Unians.Web.Clients.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IUniversityApiClient, UniversityApiClient>()
                .AddPolicyHandler(GetRetryPolicy)
                .AddPolicyHandler(arg => GetCircuitBreakerPatternPolicy(arg, configuration));

            services.AddHttpClient<IFacultyApiClient, FacultyApiClient>()
                .AddPolicyHandler(GetRetryPolicy)
                .AddPolicyHandler(arg => GetCircuitBreakerPatternPolicy(arg, configuration));

            services.AddHttpClient<ICourseApiClient, CourseApiClient>()
                .AddPolicyHandler(GetRetryPolicy)
                .AddPolicyHandler(arg => GetCircuitBreakerPatternPolicy(arg, configuration));

            services.AddHttpClient<ISemesterApiClient, SemesterApiClient>()
                .AddPolicyHandler(GetRetryPolicy)
                .AddPolicyHandler(arg => GetCircuitBreakerPatternPolicy(arg, configuration));

            services.AddHttpClient<IExerciseApiClient, ExerciseApiClient>()
                .AddPolicyHandler(GetRetryPolicy)
                .AddPolicyHandler(arg => GetCircuitBreakerPatternPolicy(arg, configuration));
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(HttpRequestMessage arg)
        {
            return HttpPolicyExtensions.HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPatternPolicy(HttpRequestMessage arg, IConfiguration configuration)
        {
            var section = configuration.GetSection("CircuitBreaker");
            var breakTime = section.GetValue<int>("BreakTime");
            var retries = section.GetValue<int>("RetriesBeforeBreak");

            return HttpPolicyExtensions.HandleTransientHttpError()
                .CircuitBreakerAsync(retries, TimeSpan.FromSeconds(breakTime));
        }
    }
}
