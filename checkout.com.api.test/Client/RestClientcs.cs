using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.test.Client
{
    public class RestClient : IRestClient
    {
        public async Task<HttpResponseMessage> PostAsync<T>(HttpClient httpClient, string uri, T entity)
            where T : class
        {
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

            return await httpClient.PostAsync<T>(uri, entity, formatter);
        }

        public async Task<HttpResponseMessage> GetAsync(HttpClient httpClient, string uri)
        {
            return await httpClient.GetAsync(uri);
        }
    }
}
