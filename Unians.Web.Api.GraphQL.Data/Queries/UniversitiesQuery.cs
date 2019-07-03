using GraphQL.Types;
using System.Collections.Generic;
using Unians.Web.Api.GraphQL.Data.Types;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Api.GraphQL.Data.Queries
{
    public class UniversitiesQuery : ObjectGraphType<object>
    {
        public UniversitiesQuery(IUniversityApiClient client)
        {
            Name = "Universities";

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
                resolve: context => {
                    //var ids = context.GetArgument<List<int>>("ids");

                    //return client.GetUniversitiesByIdsAsync(ids).Result;

                    return client.GetUniversitiesAsync().Result;
                }
            );
        }
    }
}
