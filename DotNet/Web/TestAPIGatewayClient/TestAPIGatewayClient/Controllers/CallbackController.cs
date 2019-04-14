using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAPIGatewayClient.Controllers
{
    [Route("callback")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        public object Get() {

            return Ok(new CallbackResponse{Message = "Success"});
        }
    }
}