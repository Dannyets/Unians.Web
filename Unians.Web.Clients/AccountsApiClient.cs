using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Accounts.Api.Models;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Unians.Web.Clients.Interfaces;
using Unians.Web.ViewModels.Account;

namespace Unians.Web.Clients
{
    public class AccountsApiClient : BaseHttpClient, IAccountsApiClient
    {
        private readonly IMapper _mapper;

        public AccountsApiClient(IMapper mapper,
                                IConfiguration configuration, 
                                HttpClient client) : base("Accounts", configuration, client)
        {
            _mapper = mapper;
        }

        public async Task ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            var model = _mapper.Map<ForgotPasswordModel>(viewModel);

            await Post("Accounts", "ForgotPassword", body: model);
        }

        public async Task Login(LoginViewModel viewModel)
        {
            var model = _mapper.Map<LoginModel>(viewModel);

            await Post("Accounts", "Login", body: model);
        }

        public async Task ResetPassword(ResetPasswordViewModel viewModel)
        {
            var model = _mapper.Map<ResetPasswordModel>(viewModel);

            await Post("Accounts", "ResetPassword", body: model);
        }

        public async Task SignUp(SignUpViewModel viewModel)
        {
            var model = _mapper.Map<SignUpModel>(viewModel);

            await Post("Accounts", "SignUp", body: model);
        }
    }
}
