using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cellar.Api.Models.Requests.Reception;
using Cellar.Api.Business.Reception.Api;
using Cellar.Api.ActionFilters.Authentication;
using Cellar.Api.ActionFilters.Logging;

namespace Cellar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Reception")]
    [ServiceFilter(typeof(AuthenticatedRequestFilter))]
    [ServiceFilter(typeof(LogActionFilter))]
    public class ReceptionController : ControllerBase
    {
        #region --- injected resources ------------------------------------------------------------
        private readonly IReceptionManagement receptionManagement;
        #endregion

        #region --- ctor --------------------------------------------------------------------------
        public ReceptionController(IReceptionManagement receptionManagement) 
        {
            this.receptionManagement = receptionManagement;
        }
        #endregion

        #region --- ReceptionController API -------------------------------------------------------
        [HttpPost("{roomId}")]
        [Route("CallForClean/{roomId}/{cleanType}")]
        public IActionResult CallForClean(string roomId, [FromBody]CallForCleanRequest request)
        {
            if (string.IsNullOrEmpty(roomId) || request == null || !ModelState.IsValid)
            {
                //Bad request
                return StatusCode(400);
            }

            try
            {
                var result = receptionManagement.CallForClean(roomId, request.CleanType);

                if (result)
                {
                    // 201 OK - Created
                    return StatusCode(201);
                }

                // 500 ERR - Internal server error
                return StatusCode(500);
            }
            catch
            {
                // 500 ERR - Internal server error
                return StatusCode(500);
            }
        }

        [HttpGet("{roomId}")]
        [Route("CallForClean/{roomId}")]
        public IActionResult CallReception(string roomId)
        {
            if (string.IsNullOrWhiteSpace(roomId))
            {
                //Bad request
                return StatusCode(400);
            }

            try
            {
                var result = receptionManagement.CallReception(roomId);

                if (result)
                {
                    // 201 OK - Created
                    return StatusCode(201);
                }

                // 500 ERR - Internal server error
                return StatusCode(500);
            }
            catch
            {
                // 500 ERR - Internal server error
                return StatusCode(500);
            }
        }

        [HttpPost("{roomId}")]
        [Route("SomethingElse/{roomId}")]
        public IActionResult SomethingElse(string roomId, [FromBody]SomethingElseRequest request)
        {
            if (string.IsNullOrEmpty(roomId) || request == null || !ModelState.IsValid)
            {
                //Bad request
                return StatusCode(400);
            }

            try
            {
                var result = receptionManagement.SomethingElse(roomId, request.Message);

                if (result)
                {
                    // 201 OK - Created
                    return StatusCode(201);
                }

                // 500 ERR - Internal server error
                return StatusCode(500);
            }
            catch
            {
                // 500 ERR - Internal server error
                return StatusCode(500);
            }
        }

        [HttpGet("{roomId}")]
        [Route("GetSortiment/{roomId}")]
        public IActionResult GetSortiment(string roomId)
        {
            if (string.IsNullOrEmpty(roomId))
            {
                //Bad request
                return StatusCode(400);
            }

            try
            {
                var mongoItems = receptionManagement.GetSortiment(roomId);
                var sortiment = DummyDataProvider.GetSortiment();
                
                // 200 OK
                return Ok(sortiment);
            }
            catch
            {
                // 500 ERR - Internal server error
                return StatusCode(500);
            }
            
        }

        [HttpPost("{roomId}")]
        [Route("PlaceOrder/{roomId}")]
        public IActionResult PlaceOrder(string roomId, [FromBody]PlaceOrderRequest request)
        {
            if (string.IsNullOrEmpty(roomId) || request == null || !ModelState.IsValid)
            {
                //Bad request
                return StatusCode(400);
            }

            try
            {
                var result = receptionManagement.PlaceOrder(roomId, request);

                if (result)
                {
                    // 201 OK - Created
                    return StatusCode(201);
                }

                // 500 ERR - Internal server error
                return StatusCode(500);
            }
            catch
            {
                // 500 ERR - Internal server error
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("ValidatePin")]
        public IActionResult ValidatePin([FromBody]ValidatePinRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                //Bad request
                return StatusCode(400);
            }

            try
            {
                var result = receptionManagement.ValidatePin(request.Pin);

                if (result)
                {
                    // 200 OK - Created
                    return StatusCode(200);
                }

                // 500 ERR - Internal server error
                return StatusCode(500);
            }
            catch
            {
                // 500 ERR - Internal server error
                return StatusCode(500);
            }
        }
        #endregion
    }
}