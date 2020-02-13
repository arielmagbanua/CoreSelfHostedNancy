using Nancy;
using CoreSelfHostedNancy.Models;
using Nancy.ModelBinding;
using System.Threading.Tasks;

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
            Get("/regular/user", (args) => {
                User user = new User()
                {
                    Name = "Ariel Magbanua",
                    Address = "Dash10 Building"
                };

                return Response.AsJson(user);
            });

            Get("/bind/user", (args) => {
                User user = new User()
                {
                    Name = "Ariel Magbanua",
                    Address = "Dash10 Building"
                };

                var companyUser = this.BindTo(
                        new {
                            Company = "Zeald",
                            User = user
                        }
                    );

                return Response.AsJson(companyUser);
            });

            // Async route
            Get("/async/user", async (args, ct) => {
                User user = new User()
                {
                    Name = "Ariel Magbanua",
                    Address = "Dash10 Building"
                };

                user.Name = await this.GetFooName();

                return Response.AsJson(user);
            });
        }

        private async Task<string> GetFooName()
        {
            return "Foo Name";
        }
    }
}
