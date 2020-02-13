using Nancy;
using CoreSelfHostedNancy.Models;
using Nancy.ModelBinding;

namespace CoreSelfHostedNancy.Modules
{
    public class Api : NancyModule
    {
        public Api() : base("api")
        {
            Get("/", (args) => {
                return View["api.html"];
            });

            // Returning RAW json string as json response.
            Get("/raw", (p) => {
                string data = "{ \"foo\" : \"BAR\" }";

                return Response.AsText(data, "application/json");
            });

            // Returning model instances as json response using dynamic
            Get("/dynamic/user", (args) => {
                dynamic user = new User()
                {
                    Name = "Ariel Magbanua",
                    Address = "Dash10 Building"
                };

                return Response.AsJson((object)user);
            });

            // Returning model instances as json.
            Get("/bind/user", (args) => {
                User user = new User()
                {
                    Name = "Ariel Magbanua",
                    Address = "Dash10 Building"
                };

                return Response.AsJson(user);
            });
        }
    }
}
