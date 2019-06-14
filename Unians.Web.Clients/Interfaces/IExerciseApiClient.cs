using BaseRepositories.Models;
using System.Threading.Tasks;
using Unians.Web.ViewModels.Exercise;

namespace Unians.Web.Interfaces
{
    public interface IExerciseApiClient
    {
        Task<CreateExerciseViewModel> CreateExercise(CreateExerciseViewModel exerciseViewModel);
    }
}
