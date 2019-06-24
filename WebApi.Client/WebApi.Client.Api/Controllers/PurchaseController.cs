using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApi.Client.Infrastructure;

namespace WebApi.Client.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        RabbitClient client = new RabbitClient();

        [HttpPost]
        public async Task<ActionResult<string>> SendJsonOverRabbitQueueAsync()
        {

            string value;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                value = await reader.ReadToEndAsync();
            }

            if (value != null)
            {
                client.SendMessageToQueue(value.ToString(), RabbitRoutesUtillity.Purchase_Route);
                return CreatedAtAction(nameof(SendJsonOverRabbitQueueAsync), value);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
