using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unians.Web.Api.GraphQL.Data.Models;
using Unians.Web.Api.GraphQL.Data.Queries;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Api.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : Controller
    {
        private readonly IUniversityApiClient _universityApiClient;

        public GraphQLController(IUniversityApiClient universityApiClient)
        {
            _universityApiClient = universityApiClient;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLRequest query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema
            {
                Query = new UniversitiesQuery(_universityApiClient)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
