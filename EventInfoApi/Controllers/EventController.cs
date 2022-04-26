using ConsumeAPI;
using EventInfoApi.DataAccessLayer;
using EventInfoApi.Helper;
using EventInfoAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace EventInfoApi.Controllers
{

    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly DbData dbData = new DbData();
        public EventController(IConfiguration configuration)
        {
            Util.configuration = configuration;
            DbConnection.configuration = configuration;
            DBSqlConnection.configuration = configuration;
        }

        [HttpGet]
        [Route("v1/GetEventInfo")]
        public ActionResult GetEventInfo(int eventId)
        {
            string result = string.Empty;
            try
            {
                if (HeaderValidation.ValidateHeaders(this.Request.Headers, "X"))
                {
                    DbConnection.headerData = this.Request.Headers;
                    if (AuthenticateUser.ValidateUser(this.Request.Headers))
                    {
                        result = dbData.GetEventData(eventId);
                    }
                    else
                    {
                        result = "unauthorized user";
                    }
                }
                else
                {
                    result = "unauthorized user";
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.Info(">>> EventInfoController Exception occured: " + ex.Message);
                result = ex.Message;
                return BadRequest(result);
            }//catch          

        }

    }
}