using GraphQL.Types;
using Unians.University.Api.Data.Models;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Api.GraphQL.Data.Types
{
    public class UniversityType : ObjectGraphType<ApiUniversity>
    {
        public UniversityType(IFacultyApiClient facultyApiClient)
        {
            Name = "University";

            Field(u => u.Id).Description("Id of university");
            Field(u => u.Name).Description("Name of university");

            Field<FacultyType>(
                "faculty",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "id of faculty" }),
                resolve: context => facultyApiClient.GetFaculty(1).Result
            );

            Field<ListGraphType<FacultyType>>(
                "faculties",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "universityId", Description = "id of university" }),
                resolve: context =>
                {
                    var universityId = context.GetArgument<int>("universityId");

                    return facultyApiClient.GetFacultiesForUniversity(universityId).Result;
                }
            );
        }
    }
}
