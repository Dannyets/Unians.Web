using GraphQL.Types;
using System.Collections.Generic;
using Unians.Web.Api.GraphQL.Data.Types;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Api.GraphQL.Data.Queries
{
    public class UniversityQuery : ObjectGraphType<object>
    {
        public UniversityQuery(IUniversityApiClient client)
        {
            Name = "UniversityQuery";

            Field<UniversityType>(
                "university", 
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "id of university" }),
                resolve: context => {
                    var id = context.GetArgument<int>("id");

                    return client.GetUniversityByIdAsync(id).Result;
                }
            );

            Field<ListGraphType<UniversityType>>(
                "universities",
                resolve: context => client.GetUniversitiesAsync().Result
            );
        }
    }
}
