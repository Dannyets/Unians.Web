using GraphQL;
using GraphQL.Http;
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
        public static void AddGraphQL(this IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<UniversitiesQuery>();
            services.AddSingleton<UniversityType>();
            services.AddSingleton<ISchema, UniversityScheme>();
        }
    }
}
