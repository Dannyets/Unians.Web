using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Unians.Course.Api.Data.Models;

namespace Unians.Web.Api.GraphQL.Data.Types
{
    public class CourseType : ObjectGraphType<ApiCourse>
    {
        public CourseType()
        {
            Name = "Course";

            Field(u => u.Id).Description("Id of course");
            Field(u => u.CourseNumber).Description("Course number");
            Field(u => u.Name).Description("Name of course");
            Field(u => u.FacultyId).Description("Id of parent faculty");
        }
    }
}
