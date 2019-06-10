using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unians.Web.ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }

        public string ResetPasswordToken { get; set; }

        public string NewPassword { get; set; }
    }
}
