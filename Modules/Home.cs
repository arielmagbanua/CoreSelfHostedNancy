using ibsgateway831;
using Nancy;

namespace CoreSelfHostedNancy.Modules
{
    public class Home : NancyModule
    {
        GatewayClass gw = new GatewayClass();

        public Home()
        {
            Get("/", (p) => {
                return View["index.html"];
            });

            Get("/customers", (p) =>
            {
                gw.setpath("D:\\Apps\\Infusion\\--DEMO--");
                gw.login("Test Program");

                gw.Open("Customer", "all_customers");
                gw.Select("all_customers");
                var count = gw.Reccount();

                return Response.AsJson(new
                {
                    totalCount = count
                });
            });
        }
    }
}
