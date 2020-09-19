using System.Collections.Generic;
using Newtonsoft.Json;

namespace LineBot.API.Model
{
    public class LinePostData
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("messages")]
        public List<LineMessage> Messages { get; set; }
    }
}