using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cellar.Api.Models;

namespace Cellar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Reception")]
    public class ReceptionController : ControllerBase
    {

        [HttpGet("{roomId},{cleanType}")]
        [Route("CallForClean/{roomId}/{cleanType}")]
        public bool CallForClean(string roomId, string cleanType)
        {
            return true;
        }

        [HttpGet("{roomId}")]
        [Route("CallForClean/{roomId}")]
        public bool CallReception(string roomId)
        {
            return true;
        }

        [HttpPost("{roomId}")]
        [Route("SomethingElse/{roomId}")]
        public bool SomethingElse(string roomId, [FromBody]string value)
        {
            return true;
        }

        [HttpGet("{roomId}")]
        [Route("GetSortiment/{roomId}")]
        public object GetSortiment(string roomId)
        {
            return true;
        }

        [HttpPost("{roomId}")]
        [Route("PlaceOrder/{roomId}")]
        public bool PlaceOrder(string roomId, [FromBody]string value)
        {
            return true;
        }

        [HttpPost]
        [Route("ValidatePin")]
        public bool ValidatePin([FromBody]string value)
        {
            return true;
        }

    }
}