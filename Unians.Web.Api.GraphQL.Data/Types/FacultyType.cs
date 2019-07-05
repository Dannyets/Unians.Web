using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Unians.Faculty.Api.Data.Models;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Api.GraphQL.Data.Types
{
    public class FacultyType : ObjectGraphType<ApiFaculty>
    {
        public FacultyType(ICourseApiClient courseApiClient)
        {
            Name = "Faculty";

            Field(u => u.Id).Description("Id of faculty");
            Field(u => u.Name).Description("Name of faculty");

            Field<CourseType>(
                "course",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "id of course" }),
                resolve: context => {
                    var id = context.GetArgument<int>("id");

                    return courseApiClient.GetCourse(id).Result;
                }
            );

            Field<ListGraphType<CourseType>>(
                "courses",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "facultyId", Description = "id of faculty" }),
                resolve: context =>
                {
                    var facultyId = context.GetArgument<int>("facultyId");

                    return courseApiClient.GetCoursesForFaculty(facultyId).Result;
                }
            );
        }
    }
}
