using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace CoreSelfHostedNancy.Auth
{
    public class Authenticator
    {
        public static ClaimsPrincipal AuthenticateToken(string token)
        {
            if (token != "validated-TOKEN-ggness")
            {
                return null;
            }

            return new ClaimsPrincipal(new GenericIdentity(token, "stateless"));
        }
    }
}
