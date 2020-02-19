using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace CoreSelfHostedNancy.Auth
{
    public class Authenticator
    {
        public static ClaimsPrincipal AuthenticateToken(string token, string key)
        {
            string unhashedCredential = "9A1FDFA98342EDC4B9F453238EEB11B09E40BA3B8B560C13F30F73E3B30D5E96";
            // string susi = "$2a$10$GMVW4wPrudwOb70DnjB0zO";

            // var hashed = BCrypt.Net.BCrypt.HashPassword(unhashedCredential, key);
            // var lol = BCrypt.Net.BCrypt.HashString("9A1FDFA98342EDC4B9F453238EEB11B09E40BA3B8B560C13F30F73E3B30D5E96");


            bool isValid = BCrypt.Net.BCrypt.Verify(unhashedCredential, token);

            if (token != "validated-TOKEN-ggness")
            {
                return null;
            }

            return new ClaimsPrincipal(new GenericIdentity(token, "stateless"));
        }
    }
}
