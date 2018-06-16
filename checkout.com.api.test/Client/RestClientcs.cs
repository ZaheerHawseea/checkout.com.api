using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.test.Client
{
    /// <summary>
    /// The default rest client for creating http requests
    /// </summary>
    public class RestClient : IRestClient
    {
        /// <summary>
        /// Execute GET operation
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="HttpClient"/>
        /// </param>
        /// <param name="uri">
        /// The endpoint uri
        /// </param>
        /// <returns>
        /// Asynchronous task
        /// </returns>
        public async Task<HttpResponseMessage> GetAsync(HttpClient httpClient, string uri)
        {
            return await httpClient.GetAsync(uri);
        }

        /// <summary>
        /// Exectute POST operation
        /// </summary>
        /// <typeparam name="T">
        /// Entity type to send
        /// </typeparam>
        /// <param name="httpClient">
        /// The <see cref="HttpClient"/>
        /// </param>
        /// <param name="uri">
        /// The endpoint uri
        /// </param>
        /// <param name="entity">
        /// The value to send
        /// </param>
        /// <returns>
        /// Asynchronous task
        /// </returns>
        public async Task<HttpResponseMessage> PostAsync<T>(HttpClient httpClient, string uri, T entity)
            where T : class
        {
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

            return await httpClient.PostAsync<T>(uri, entity, formatter);
        }

        /// <summary>
        /// Exectute PATCH operation
        /// </summary>
        /// <typeparam name="T">
        /// Entity type to send
        /// </typeparam>
        /// <param name="httpClient">
        /// The <see cref="HttpClient"/>
        /// </param>
        /// <param name="uri">
        /// The endpoint uri
        /// </param>
        /// <param name="entity">
        /// The value to send
        /// </param>
        /// <returns>
        /// Asynchronous task
        /// </returns>
        public async Task<HttpResponseMessage> PatchAsync<T>(HttpClient httpClient, string uri, T entity)
            where T : class
        {
            var formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

            var content = new ObjectContent<T>(entity, formatter);

            return await httpClient.PatchAsync(uri, content);
        }
    }
}
