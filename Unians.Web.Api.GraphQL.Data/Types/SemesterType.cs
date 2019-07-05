using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Unians.Semester.Api.Data.Models;

namespace Unians.Web.Api.GraphQL.Data.Types
{
    public class SemesterType : ObjectGraphType<ApiSemester>
    {
        public SemesterType()
        {
            Name = "Semester";

            Field(p => p.Id).Description("Id of semester");
            Field(p => p.Name).Description("Name of semester");
            Field(p => p.UniversityId).Description("University id that semester belongs to");
            Field(p => p.StartDate).Description("The date that semester starts in");
            Field(p => p.EndDate).Description("The date that semester ends in");
        }
    }
}
