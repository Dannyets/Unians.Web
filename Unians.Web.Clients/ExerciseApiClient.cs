using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using De.Amazon.Configuration.Models;
using Exercise.Api.Models;
using Microsoft.Extensions.Configuration;
using Unians.Web.Interfaces;
using Unians.Web.ViewModels.Exercise;

namespace Unians.Web.Clients
{
    public class ExerciseApiClient : BaseAmazonDiscoveryHttpClient, IExerciseApiClient
    {
        private IMapper _mapper;

        public ExerciseApiClient(AmazonConfiguration amazonConfiguration,
                                 IMapper mapper,
                                 HttpClient client) : base("unians", "exercise-api", amazonConfiguration, client)
        {
            _mapper = mapper;
        }

        public async Task<CreateExerciseViewModel> CreateExercise(CreateExerciseViewModel exerciseViewModel)
        {
            var model = _mapper.Map<ExerciseApiModel>(exerciseViewModel);

            var response = await Post<ExerciseApiModel>("api/v1/Exercise", "Create", body: model);

            exerciseViewModel = _mapper.Map<CreateExerciseViewModel>(response);

            return exerciseViewModel;
        }
    }
}
