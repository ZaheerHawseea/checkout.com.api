using checkout.com.api.Entities.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace checkout.com.api.test.Client.Dto
{
    /// <summary>
    /// The odata response for entity list
    /// </summary>
    /// <typeparam name="T">
    /// The type of <see cref="IEntity"/>
    /// </typeparam>
    public class EntityResponse<T>
        where T : IEntity
    {
        [JsonProperty("@odata.context")]
        public string Odata { get; set; }

        [JsonProperty("value")]
        public List<T> Value { get; set; }
    }
}
