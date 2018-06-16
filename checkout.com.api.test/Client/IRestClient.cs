using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using checkout.com.api.Entities.Meta;

namespace checkout.com.api.test.Client
{
    /// <summary>
    /// The rest client for creating http requests
    /// </summary>
    public interface IRestClient
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
        Task<HttpResponseMessage> GetAsync(HttpClient httpClient, string uri);

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
        Task<HttpResponseMessage> PostAsync<T>(HttpClient httpClient, string uri, T entity) where T : class;

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
        Task<HttpResponseMessage> PatchAsync<T>(HttpClient httpClient, string uri, T entity) where T : class;
    }
}