using AutoMapper;
using Exercise.Api.Models;
using Unians.Web.ViewModels.Exercise;

namespace Unians.Web.Clients.Mapper
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<CreateExerciseViewModel, ExerciseApiModel>().ReverseMap();
        }
    }
}
