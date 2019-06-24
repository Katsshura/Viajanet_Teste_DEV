using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApi.Client.Infrastructure;


namespace WebApi.Client.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        RabbitClient client = new RabbitClient();

        [HttpPost]
        public async Task<ActionResult<string>> SendJsonOverRabbitQueueAsync()
        {
            ///<summary> Using StreamReader to get body from request
            ///<para>this fix the problem when request come in xml format and [FromBody] cant resolve it</para>
            ///</summary>

            string value;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                value = await reader.ReadToEndAsync();
            }

            if (value != null)
            {
                client.SendMessageToQueue(value.ToString(), RabbitRoutesUtillity.User_Route);
                return CreatedAtAction(nameof(SendJsonOverRabbitQueueAsync), value);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
