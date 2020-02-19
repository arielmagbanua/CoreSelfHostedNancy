using ibsgateway831;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSelfHostedNancy.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Username { get; private set; }

        public User(string username = null)
        {
            Username = username;
        }

        public GatewayClass CreateGateway()
        {
            GatewayClass gw = new GatewayClass();
            gw.setpath("D:\\Apps\\Infusion\\--DEMO--");

            return gw;
        }
    }
}
