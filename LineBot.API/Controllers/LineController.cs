using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using LineBot.API.Model;

namespace LineBot.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LineController : ControllerBase
    {

        private readonly ILogger<LineController> _logger;

        public LineController(ILogger<LineController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult PushMessage()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "YvWZ+lhw4mBszIb4cuow/211m0BvEDX2AB5auS3IwkzkN1POJ3ej4Gw20tX17/hL/3PN0wKXlHl4xeFcySt4TbhujKQWqUlcuJhnIeI84xb3kHagP3gIwEoHppOvugwexZeNAPc14O0fbX7Stek35QdB04t89/1O/w1cDnyilFU=");

            var linePostData = new LinePostData()
            {
                To = "U4a9545acb96cec83be20f9839fa79e88",
                Messages = new List<LineMessage>()
                {
                    new LineMessage()
                    {
                        Type = "text",
                        Text = "Hello World"
                    }
                },
            };

            var json = JsonConvert.SerializeObject(linePostData);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://api.line.me/v2/bot/message/push", stringContent).GetAwaiter().GetResult();

            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return Ok(content);
        }
    }
}
