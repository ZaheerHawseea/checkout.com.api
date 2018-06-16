using Microsoft.AspNetCore;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace checkout.com.api.test.Service
{
    public class TestService
    {
        private readonly TestServer httpServer;
        private readonly HttpClient httpClient;

        public TestService()
        {
            this.httpServer = new TestServer(WebHost.CreateDefaultBuilder<TestStartup>(null));
            this.httpClient = httpServer.CreateClient();
        }

        public HttpClient GetClient()
        {
            return this.httpClient;
        }
    }
}
