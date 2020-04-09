using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq;

namespace Applebrie.WebApi.Models
{
    public class ApiError
    {
        public ApiError()
        {

        }

        public ApiError(string message)
        {

        }

        public ApiError(ModelStateDictionary modelState)
        {
            Message = "Invalid Parameters.";
            Detail = string.Join(", ", modelState.SelectMany(m => m.Value.Errors)
                .Select(m => m.ErrorMessage));
        }


        public string Message { get; set; }
        public string Detail { get; set; }


        // Disapear if StackTrace is null
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue("")]
        public string StackTrace { get; set; }

    }
}
