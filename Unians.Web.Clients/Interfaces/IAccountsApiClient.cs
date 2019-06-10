using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unians.Web.ViewModels.Account;

namespace Unians.Web.Clients.Interfaces
{
    public interface IAccountsApiClient
    {
        Task SignUp(SignUpViewModel model);

        Task Login(LoginViewModel model);

        Task ForgotPassword(ForgotPasswordViewModel model);

        Task ResetPassword(ResetPasswordViewModel model);
    }
}
