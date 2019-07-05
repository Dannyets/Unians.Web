using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Unians.Web.Api.GraphQL.Data.Queries;
using Unians.Web.Api.GraphQL.Data.Schemes;
using Unians.Web.Api.GraphQL.Data.Types;

namespace Unians.Web.Api.GraphQL.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGraphQLDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            //ADD QUERIES
            services.AddSingleton<UniversityQuery>();

            //ADD TYPES
            services.AddSingleton<UniversityType>();
            services.AddSingleton<FacultyType>();
            services.AddSingleton<CourseType>();
            services.AddSingleton<SemesterType>();

            //ADD SCHEMAS
            services.AddSingleton<ISchema, UniversitySchema>();

            var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = isDevelopment;
                })
                .AddDataLoader();
        }
    }
}
