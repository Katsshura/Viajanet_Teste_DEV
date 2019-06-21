﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApi.Client.Infrastructure;

namespace WebApi.Client.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        RabbitClient client = new RabbitClient();

        [HttpPost]
        public ActionResult<string> SendJsonOverRabbitQueue([FromBody] JObject value)
        {
            if (value != null)
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