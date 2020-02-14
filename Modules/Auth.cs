using System;
using Nancy.ModelBinding;
using Nancy;
using CoreSelfHostedNancy.Models;
using System.Linq;

namespace CoreSelfHostedNancy.Modules
{
    public class Auth : NancyModule
    {
        public Auth() : base("auth")
        {
            // post route with custom headers
            Post("/custom", (args) => {
                Console.WriteLine(args);
                Console.WriteLine(this.Request.Headers.Authorization);

                string xToken = this.Request.Headers["x-token"].FirstOrDefault();
                string xKey = this.Request.Headers["x-key"].FirstOrDefault();

                var xAuth = this.BindTo(
                        new
                        {
                            XToken = xToken,
                            XKey = xKey
                        }
                    );

                return Response.AsJson(xAuth)
                                .WithHeader("Foo", "Bar");
            });

            Post("/create_user", args =>
            {
                Tuple<string, string> user = UserDatabase.CreateUser(this.Context.Request.Form["username"], this.Context.Request.Form["password"]);
                return this.Response.AsJson(new { username = user.Item1 });
            });

            // The Post["/login"] method is used mainly to fetch the api key for subsequent calls
            Post("/login", args =>
            {
                var apiKey = UserDatabase.ValidateUser(
                    (string)this.Request.Form.Username,
                    (string)this.Request.Form.Password);

                return string.IsNullOrEmpty(apiKey)
                    ? new Response { StatusCode = HttpStatusCode.Unauthorized }
                    : this.Response.AsJson(new { ApiKey = apiKey });
            });

            //do something to destroy the api key, maybe?
            Delete("/delete/{userId}", args =>
            {
                var apiKey = (string)this.Request.Form.ApiKey;
                UserDatabase.RemoveApiKey(apiKey);
                return new Response { StatusCode = HttpStatusCode.OK };
            });
        }
    }
}
