﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            Detail = modelState.FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors
                .FirstOrDefault().ErrorMessage;
        }


        public string Message { get; set; }
        public string Detail { get; set; }


        // Disapear if StackTrace is null
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue("")]
        public string StackTrace { get; set; }

    }
}
