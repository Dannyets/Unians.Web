using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Unians.University.Api.Data.Models;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Api.GraphQL.Data.Types
{
    public class UniversityType : ObjectGraphType<ApiUniversity>
    {
        public UniversityType()
        {
            Name = "University";

            Field(u => u.Id).Description("Id of university");
            Field(u => u.Name).Description("Name of university");
        }
    }
}
