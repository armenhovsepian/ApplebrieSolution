using Newtonsoft.Json;
using System.ComponentModel;

namespace Applebrie.WebApi.Models
{
    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }


        // Disapear if StackTrace is null
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue("")]
        public string StackTrace { get; set; }

    }
}
