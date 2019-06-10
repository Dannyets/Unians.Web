using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Api.Models;
using Microsoft.Extensions.Configuration;
using Unians.Web.Interfaces;
using Unians.Web.ViewModels.Exercise;

namespace Unians.Web.Clients
{
    public class ExerciseApiClient : BaseHttpClient, IExerciseApiClient
    {
        private IMapper _mapper;

        public ExerciseApiClient(IConfiguration configuration,
                                 IMapper mapper,
                                 HttpClient client) : base("Exercise", configuration, client)
        {
            _mapper = mapper;
        }

        public async Task<string> CreateExercise(CreateExerciseViewModel exerciseViewModel)
        {
            var model = _mapper.Map<ExerciseApiModel>(exerciseViewModel);

            var response = await Post<ExerciseApiModel>("Exercise", "Create", body: model);

            return response?.Id;
        }
    }
}
