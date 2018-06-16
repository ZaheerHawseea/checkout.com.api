using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.test.Client
{
    public interface IRestClient
    {
        Task<HttpResponseMessage> PostAsync<T>(HttpClient httpClient, string uri, T entity) where T : class;
        Task<HttpResponseMessage> GetAsync(HttpClient httpClient, string uri);
    }
}