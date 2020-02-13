using Nancy;

namespace CoreSelfHostedNancy.Modules
{
    public class Home : NancyModule
    {
        public Home()
        {
            Get("/", (p) => {
                return View["index.html"];
            });
        }
    }
}
