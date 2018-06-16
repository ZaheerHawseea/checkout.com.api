using checkout.com.api.Entities.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace checkout.com.api.test.Client.Dto
{
    public class EntityResponse<T>
        where T : IEntity
    {
        [JsonProperty("@odata.context")]
        public string Odata { get; set; }

        [JsonProperty("value")]
        public List<T> Value { get; set; }
    }
}
