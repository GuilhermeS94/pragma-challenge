using System;
using Newtonsoft.Json;

namespace DotNetCodeChallenge.CustomExceptions
{
    public class MyGlobalExceptionModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
