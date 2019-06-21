using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApi.Client.Infrastructure;

namespace WebApi.Client.Api.Controllers
{
    //Handle browser informations and send it to RabbitMQ Queue

    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrowserController : ControllerBase
    {
        RabbitClient client = new RabbitClient();

        [HttpPost]
        public ActionResult<string> SendJsonOverRabbitQueue([FromBody] JObject value)
        {
            if(value != null)
            {
                client.SendMessageToQueue(value.ToString());
                return CreatedAtAction(nameof(SendJsonOverRabbitQueue), value);
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}
