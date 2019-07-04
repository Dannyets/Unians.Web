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
        public FacultyType(IFacultyApiClient facultyApiClient)
        {
            Name = "Faculty";

            Field(u => u.Id).Description("Id of faculty");
            Field(u => u.Name).Description("Name of faculty");
        }
    }
}
