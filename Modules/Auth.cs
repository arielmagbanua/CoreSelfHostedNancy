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
        }
    }
}
