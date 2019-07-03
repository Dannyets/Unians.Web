using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Unians.Web.Api.GraphQL.Data.Queries;

namespace Unians.Web.Api.GraphQL.Data.Schemes
{
    public class UniversityScheme : Schema
    {
        public UniversityScheme(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<UniversitiesQuery>();
        }
    }
}
