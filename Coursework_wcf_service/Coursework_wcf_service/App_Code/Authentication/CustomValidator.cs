using Coursework_wcf_service.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace Coursework_wcf_service.App_Code.Authentication
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            AccountModel acc = new AccountModel();
            if (acc.login(userName, password))
                return;
            throw new SecurityTokenException("Account's  invalid");
        }
    }
}