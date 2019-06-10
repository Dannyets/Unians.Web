using Accounts.Api.Models;
using AutoMapper;
using Unians.Web.ViewModels.Account;

namespace Unians.Web.Clients.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<SignUpViewModel, SignUpModel>().ReverseMap();
            CreateMap<LoginViewModel, LoginModel>().ReverseMap();
            CreateMap<ForgotPasswordViewModel, ForgotPasswordModel>().ReverseMap();
            CreateMap<ResetPasswordViewModel, ResetPasswordModel>().ReverseMap();
        }
    }
}
