using Nancy;

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
        }
    }
}
