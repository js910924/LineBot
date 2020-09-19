using Newtonsoft.Json;

namespace LineBot.API.Model
{
    public class LineMessage
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}