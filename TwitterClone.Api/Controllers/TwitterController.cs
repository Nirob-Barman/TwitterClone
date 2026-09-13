using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TwitterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet("tweets")]
        public IActionResult GetTweets()
        {
            var maxTweetLength = _configuration.GetValue<int>("TwitterSettings:MaxTweetLength");

            var response = new
            {
                maxLenth = maxTweetLength,
                tweets = new[]
                {
                    new { Id = 1, Text = "Exploring Web API development with ASP.NET Core" },
                    new { Id = 2, Text = "Learning how to build RESTful APIs using C#" }

                }
            };

            return Ok(response);
        }

        [HttpGet("app-info")]
        public IActionResult GetAppInfo()
        {
            var appName = _configuration.GetValue<string>("AppName");
            return Ok(new { AppName = appName });
        }

    }
}
