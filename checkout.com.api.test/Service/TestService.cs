using Microsoft.AspNetCore;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace checkout.com.api.test.Service
{
    /// <summary>
    /// Test service used to simulate a test server
    /// </summary>
    public class TestService
    {
        /// <summary>
        /// The <see cref="TestServer"/>
        /// </summary>
        private readonly TestServer httpServer;

        /// <summary>
        /// The <see cref="HttpClient"/>
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initialise a new <see cref="TestService"/> instance
        /// </summary>
        public TestService()
        {
            this.httpServer = new TestServer(WebHost.CreateDefaultBuilder<TestStartup>(null));
            this.httpClient = httpServer.CreateClient();
        }

        /// <summary>
        /// Gets the http client
        /// </summary>
        /// <returns>
        /// The <see cref="HttpClient"/>
        /// </returns>
        public HttpClient GetClient()
        {
            return this.httpClient;
        }
    }
}
