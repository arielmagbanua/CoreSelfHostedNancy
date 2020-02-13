using Nancy;
using CoreSelfHostedNancy.Models;

namespace CoreSelfHostedNancy.Modules
{
    public class Api : NancyModule
    {
        public Api() : base("api")
        {
            Get("/", (p) => {
                return View["api.html"];
            });

            // Returning RAW json string as json response.
            Get("/raw", (p) => {
                string data = "{ \"foo\" : \"BAR\" }";

                return Response.AsText(data, "application/json");
            });

            // Returning model instances as json response using dynamic
            Get("/dynamic/user", (p) => {
                dynamic user = new User()
                {
                    Name = "Ariel Magbanua",
                    Address = "Dash10 Building"
                };

                return Response.AsJson((object)user);
            });
        }
    }
}
